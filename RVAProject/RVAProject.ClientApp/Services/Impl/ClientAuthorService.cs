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

        public async Task CreateAuthorAsync(AuthorRequest request, string token)
        {
            await _client.AddAuthorAsync(request, token);
        }

        public async Task DeleteAuthorAsync(Guid id, string token)
        {
            await _client.DeleteAuthorAsync(id, token);
        }

        public async Task<IEnumerable<AuthorInfo>> GetAllAuthorsAsync(string token)
        {
           return await _client.GetAllAuthorsAsync(token);
        }

        public async Task<AuthorInfo> GetAuthorAsync(Guid id, string token)
        {
            return await _client.GetAuthorByIdAsync(id, token);
        }

        public async Task UpdateAuthorAsync(UpdateAuthorRequest request, string token)
        {
            await _client.UpdateAuthorAsync(request, token);
        }
    }
}
