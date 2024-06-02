using RVAProject.Common.Entities;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace RVAProject.Common.Repositories.Impl
{
    public class UserRepository : IUserRepository
    {
        private readonly LibraryDbContext _dbContext;

        public UserRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddUser(User user)
        {
            _dbContext.Users.Add(user);
            await SaveChangesUser();
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task SaveChangesUser()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
