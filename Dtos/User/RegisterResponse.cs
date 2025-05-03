namespace InventoryTask.Dtos.User
{
    public record RegisterResponse(bool Success = false, List<string> Errors = null!, string Message = null!);
}
