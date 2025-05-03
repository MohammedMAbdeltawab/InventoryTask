using InventoryTask.Entities;

namespace InventoryTask.Authentication.Interfaces
{
    public interface IRoleManagment
    {
        Task<string?> GetUserRole(string userEmail);
        Task<bool> AddUserRole(AppUser user, string roleName);
    }
}
