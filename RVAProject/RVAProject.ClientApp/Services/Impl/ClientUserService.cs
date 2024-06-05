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

        public async Task<UserInfo> GetUserByIdAsync( string token)
        {
            return await _client.GetUserByIdAsync(token);
        }

        public async Task AddUserAsync(UserRequest userRequest, string token)
        {
            await _client.AddUserAsync(userRequest, token);
        }

        public async Task<string> LoginAsync(LogInRequest loginRequest)
        {
            return await _client.LogInAsync(loginRequest);
        }

        public async Task UpdateUserAsync(UpdateUserRequest userRequest, string token)
        {
            await _client.UpdateUserAsync(userRequest, token);
        }
    }
}
