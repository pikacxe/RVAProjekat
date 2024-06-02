using RVAProject.Common.Entities;
using System;
using System.Threading.Tasks;

namespace RVAProject.Common.Repositories
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        Task SaveChangesUser();
        Task<User> GetUserById(Guid id);
        Task<User> GetUserByUsername(string username);
    }
}
