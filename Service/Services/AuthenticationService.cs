using AutoMapper;
using InventoryTask.Authentication.Interfaces;
using InventoryTask.Dtos.User;
using InventoryTask.Entities;
using InventoryTask.Service.Interfaces;

namespace InventoryTask.Service.Services
{
    public class AuthenticationService:IAuthenticationService
    {
        private readonly IUserManagment _userManagment;
        private readonly IRoleManagment _roleManagment;
        private readonly ITokenManagment _tokenManagment;
        private readonly IMapper _mapper;

        public AuthenticationService(
            IUserManagment userManagment,
            IRoleManagment roleManagment,
            ITokenManagment tokenManagment,
            IMapper mapper)
        {
            _userManagment = userManagment;
            _roleManagment = roleManagment;
            _tokenManagment = tokenManagment;
            _mapper = mapper;
        }

        public async Task<RegisterResponse> RegisterAsync(CreateUser createUser)
        {
            if (createUser == null)
            {
                return new RegisterResponse
                {
                    Errors = new List<string> { "Invalid registration data" }
                };
            }

            var mappedModel = _mapper.Map<AppUser>(createUser);
            mappedModel.Email = createUser.Email;
            mappedModel.PasswordHash = createUser.Password;
            mappedModel.UserName = createUser.FullName;

            var res = await _userManagment.CreateUser(mappedModel);
            if (!res.Success)
                return new RegisterResponse { Errors = res.Error };

            var user = await _userManagment.GetUserByEmail(createUser.Email);
            var users = await _userManagment.GetAllUsers();

            bool assignedRole = await _roleManagment.AddUserRole(user!, users!.Count() > 1 ? "User" : "Admin");
            if (!assignedRole)
            {
                var removeRes = await _userManagment.DeleteUserByEmail(createUser.Email);
                if (removeRes < 0)
                {
                    return new RegisterResponse
                    {
                        Errors = new List<string> { "Failed to Create Account" }
                    };
                }
            }

            return new RegisterResponse
            {
                Success = true,
                Message = "Account Created Successfully"
            };
        }

        public async Task<LoginResponse> LoginAsync(LoginUser loginUser)
        {
            if (loginUser == null)
            {
                return new LoginResponse
                {
                    Errors = new List<string> { "Invalid login data" }
                };
            }

            var mappedModel = _mapper.Map<AppUser>(loginUser);
            mappedModel.Email = loginUser.Email;

            var loginRes = await _userManagment.LoginUser(mappedModel,loginUser.Password);
            if (!loginRes.Success)
                return new LoginResponse
                {
                    Success=false,
                    Errors = new List<string> { loginRes.Error! }
                };

            var claims = await _userManagment.GetUserClaims(loginUser.Email);
            var jwtToken = _tokenManagment.GenerateToken(claims);

            return new LoginResponse(true,[], jwtToken);
        }
    }
}
