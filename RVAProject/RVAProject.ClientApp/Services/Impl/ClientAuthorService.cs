using RVAProject.ClientApp.AuthorService;
using RVAProject.Common.DTOs.AuthorDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVAProject.ClientApp.Services.Impl
{
    public class ClientAuthorService : IClientAuthorService
    {
        private readonly AuthorServiceClient _client;

        public ClientAuthorService()
        {
            _client = new AuthorServiceClient();
        }

        public async Task CreateAuthorAsync(AuthorRequest request)
        {
            await _client.AddAuthorAsync(request);
        }

        public async Task DeleteAuthorAsync(Guid id)
        {
            await _client.DeleteAuthorAsync(id);
        }

        public async Task<IEnumerable<AuthorInfo>> GetAllAuthorsAsync()
        {
           return await _client.GetAllAuthorsAsync();
        }

        public async Task<AuthorInfo> GetAuthorAsync(Guid id)
        {
            return await _client.GetAuthorByIdAsync(id);
        }

        public async Task UpdateAuthorAsync(UpdateAuthorRequest request)
        {
            await _client.UpdateAuthorAsync(request);
        }
    }
}
