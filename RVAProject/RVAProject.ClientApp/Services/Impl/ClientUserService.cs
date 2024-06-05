using RVAProject.ClientApp.UserService;
using RVAProject.Common;
using RVAProject.Common.DTOs.UserDTO;
using RVAProject.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RVAProject.ClientApp.Services.Impl
{
    internal class ClientUserService : IClientUserService
    {
        private readonly UserServiceClient _client;

        public ClientUserService()
        {
            _client = new UserServiceClient();
        }

        public async Task<IEnumerable<UserInfo>> GetAllAsync()
        {
            throw new NotImplementedException();
           //return await _client.GetAllAsync();
        }

        public async Task<UserInfo> GetUserByIdAsync(Guid id)
        {
            return await _client.GetUserByIdAsync(id);
        }

        public async Task AddUserAsync(UserRequest userRequest)
        {
            await _client.AddUserAsync(userRequest);
        }

        public async Task<string> LoginAsync(LogInRequest loginRequest)
        {
            var token = await _client.LogInAsync(loginRequest);
            if (TokenHelper.ValidateToken(token, out ClaimsPrincipal principal))
            {
                var userId = principal.FindFirst("user_id").Value;
                var userRole = principal.FindFirst("user_role").Value;
                return token;
            }
            else
            {
               throw new CustomAppException("Invalid token");
            }
        }

        public async Task UpdateUserAsync(UpdateUserRequest userRequest)
        {
            await _client.UpdateUserAsync(userRequest);
        }
    }
}
