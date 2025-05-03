namespace InventoryTask.Dtos.User
{
    public record LoginResponse(bool Success = false, List<string> Errors = null!, string Token = null!);
}