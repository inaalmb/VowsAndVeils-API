using VowsAndVeils.Data;
using VowsAndVeils.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;


namespace VowsAndVeils.Services
{
    public class UserService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IConfiguration _configuration;

        public UserService(DatabaseContext databaseContext, IConfiguration configuration)
        {
            _databaseContext = databaseContext;
            _configuration = configuration;
        }

        public async Task<List<Users>> GetAllUsersAsync()
        {
            return await _databaseContext.Users.ToListAsync();
        }

        public string GenerateToken(Users user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Auth:Secret"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new Claim(Jw)
                })
            }
        }

    }
}
