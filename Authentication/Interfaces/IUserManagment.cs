using InventoryTask.Entities;
using System.Security.Claims;

namespace InventoryTask.Authentication.Interfaces
{
    public interface IUserManagment
    {
        Task<(bool Success, List<string> Error)> CreateUser(AppUser user);
        Task<(bool Success, string? Error)> LoginUser(AppUser user,string password);
        Task<AppUser?> GetUserByEmail(string email);
        Task<AppUser?> GetUserById(string id);
        Task<IEnumerable<AppUser?>> GetAllUsers();
        Task<int> DeleteUserByEmail(string email);
        Task<List<Claim>> GetUserClaims(string email);
        Task LogOut();
    }
}
