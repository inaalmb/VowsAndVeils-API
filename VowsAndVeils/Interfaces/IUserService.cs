
using VowsAndVeils.Data.Models;

namespace  VowsAndVeils.Interfaces
{
    public interface IUserService
    {
        Task<List<Users>> GetAllUserAsync();
        string GenerateToken(Users users);
        string HashPassword(string password);
        Task AddUserToRole(Users users);
        Task RegisterUser(Users users);
        Task CreateRole(UserRole role);
        Task <Users?> GetUserByUsername(string username);
        Task GetUserByUsername(object username);
        string HashPassword(object password);
    }
}
