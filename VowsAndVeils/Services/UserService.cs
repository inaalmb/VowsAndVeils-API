﻿using VowsAndVeils.Data;
using VowsAndVeils.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using VowsAndVeils.Interfaces;

namespace StayNest_API.Services
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IConfiguration _configuration;

        public UserService(DatabaseContext databaseContext, IConfiguration configuration)
        {
            _databaseContext = databaseContext;
            _configuration = configuration;
        }

        public async Task<List<Users>> GetAllUserAsync()
        {
            return await _databaseContext.Users.ToListAsync();
        }

        public string GenerateToken(Users users)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Auth:Secret"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[] {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("id", users.Id.ToString()),
                    new Claim("Role", "Administrator"),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(securityToken);
        }

        public string HashPassword(string password)
        {
            if (String.IsNullOrEmpty(password))
            {
                return String.Empty;
            }

            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha.ComputeHash(textBytes);

                string hash = BitConverter
                    .ToString(hashBytes)
                    .Replace("-", String.Empty);

                return hash;
            }
        }
        public async Task AddUserToRole(Users users)
        {
            await _databaseContext.Users.AddAsync(users);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task RegisterUser(Users users)
        {
            await _databaseContext.Users.AddAsync(users);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task CreateRole(UserRole role)
        {
            await _databaseContext.UserRole.AddAsync(role);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<Users?> GetUserByUsername(string username) =>
            await _databaseContext.Users.FirstOrDefaultAsync(x => x.Username == username);

        public Task GetUserByUsername(object username)
        {
            throw new NotImplementedException();
        }

        public string HashPassword(object password)
        {
            throw new NotImplementedException();
        }
    }
}
