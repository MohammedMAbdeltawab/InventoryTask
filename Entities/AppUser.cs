using Microsoft.AspNetCore.Identity;

namespace InventoryTask.Entities
{
    public class AppUser : IdentityUser
    {
        public string? FullName { get; set; } 
    }
}
