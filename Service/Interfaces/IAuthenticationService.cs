using InventoryTask.Dtos.User;

namespace InventoryTask.Service.Interfaces
{
    public interface IAuthenticationService
    {
        Task<LoginResponse> LoginAsync(LoginUser loginUser);
        Task<RegisterResponse> RegisterAsync(CreateUser createUser);
    }
}
