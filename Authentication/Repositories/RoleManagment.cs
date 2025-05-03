using InventoryTask.Authentication.Interfaces;
using InventoryTask.Entities;
using Microsoft.AspNetCore.Identity;

namespace InventoryTask.Authentication.Repositories
{
    public class RoleManagment(UserManager<AppUser> userManager) : IRoleManagment
    {
        public async Task<bool> AddUserRole(AppUser user, string roleName)
        {
            bool result = (await userManager.AddToRoleAsync(user, roleName)).Succeeded;
            return result;
        }

        public async Task<string?> GetUserRole(string userEmail)
        {
            var user = await userManager.FindByEmailAsync(userEmail);
            return (await userManager.GetRolesAsync(user!)).FirstOrDefault();
        }
    }
}
