using RVAProject.Common.DTOs.UserDTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RVAProject.ClientApp.Services
{
    public interface IClientUserService
    {
        Task<string> LoginAsync(LogInRequest loginRequest);
        Task AddUserAsync(UserRequest userRequest);
        Task UpdateUserAsync(UpdateUserRequest userRequest);
        Task<IEnumerable<UserInfo>> GetAllAsync();
        Task<UserInfo> GetUserByIdAsync(Guid id);
    }
}
