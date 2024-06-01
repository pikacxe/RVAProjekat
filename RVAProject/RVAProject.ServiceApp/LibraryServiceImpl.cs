using RVAProject.Common;
using RVAProject.Common.Repositories;
using RVAProject.Common.Repositories.Impl;
using RVAProject.Contracts;
using System.Threading.Tasks;

namespace RVAProject.ServiceApp
{
    public class LibraryServiceImpl : ILibraryService
    {
        private readonly IUserRepository _userRepository;

        public LibraryServiceImpl()
        {
            _userRepository = new UserRepository(new LibraryDbContext());
        }
        public async Task<string> HelloWorldAsync()
        {
            return "Hello world";
        }
    }
}
