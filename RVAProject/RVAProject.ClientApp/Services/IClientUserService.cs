using RVAProject.Common.DTOs.UserDTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RVAProject.ClientApp.Services
{
    public interface IClientUserService
    {
        Task<string> LoginAsync(LogInRequest loginRequest);
        Task AddUserAsync(UserRequest userRequest, string token);
        Task UpdateUserAsync(UpdateUserRequest userRequest, string token);
        Task<UserInfo> GetUserByIdAsync(string token);
    }
}
