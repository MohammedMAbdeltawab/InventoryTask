using System.Security.Claims;

namespace InventoryTask.Authentication.Interfaces
{
    public interface ITokenManagment
    {
        string GenerateToken(List<Claim> claims);
        List<Claim> GetClaimsFromToken(string token);
        string GetUserIdFromToken(string token);
        bool ValidateToken(string token);
    }
}
