using InventoryTask.Authentication.Interfaces;
using InventoryTask.Data;
using InventoryTask.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace InventoryTask.Authentication.Repositories
{
    public class UserManagment(IRoleManagment roleManagment, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
      ApplicationDbContext context) : IUserManagment
    {
        public async Task<(bool Success, List<string> Error)> CreateUser(AppUser user)
        {
            var existingUser = await GetUserByEmail(user.Email!);
            if (existingUser != null)
            {
                // User already exists
                return (false, new List<string> { "Email is Already Exist" });
            }

            // Attempt to create the user
            var result = await userManager.CreateAsync(user, user.PasswordHash!);

            // Log errors if creation fails
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description).ToList();
                return (false, errors);
            }

            return (true, new List<string>());
        }

        public async Task<int> DeleteUserByEmail(string email)
        {
            var _user = await GetUserByEmail(email);
            if (_user != null)
            {
                return -1;
            }

            context.Users.Remove(_user);
            return await context.SaveChangesAsync();
        }


        public async Task<IEnumerable<AppUser?>> GetAllUsers() =>
           await context.AppUsers.ToListAsync();


        public async Task<AppUser?> GetUserByEmail(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            return user;
        }

        public async Task<AppUser?> GetUserById(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            return user;
        }

        public async Task<List<Claim>> GetUserClaims(string email)
        {
            var user = await GetUserByEmail(email);
            string? roleName = await roleManagment.GetUserRole(email);
            List<Claim> claims =
           [
           new Claim("FullName",user!.FullName),
           new Claim(JwtRegisteredClaimNames.Sub,user!.Id),
           new Claim( JwtRegisteredClaimNames.Email,user.Email!),
           new Claim("role",roleName!)

           ];
            return claims;
        }

        public async Task<(bool Success, string? Error)> LoginUser(AppUser user,string password)
        {
            var _user = await GetUserByEmail(user.Email!);
            if (_user == null) return (false, "Invalid email.");
            var _role = await roleManagment.GetUserRole(user.Email!);
            if (string.IsNullOrEmpty(_role)) return (false, "User role not assigned or invalid.");
             var res = await userManager.CheckPasswordAsync(_user, password);
            return (res, null);
        }
        public async Task LogOut()
        {
            await signInManager.SignOutAsync();

        }

    }
}
