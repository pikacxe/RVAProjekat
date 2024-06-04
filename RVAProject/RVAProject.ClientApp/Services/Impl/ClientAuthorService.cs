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
        //private readonly AuthorServiceClient _client;

        public Task DeleteAuthorAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AuthorInfo>> GetAllAuthorsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AuthorInfo> GetAuthorAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AuthorInfo>> GetAuthorForPublisherAsync(Guid publisherId)
        {
            throw new NotImplementedException();
        }
    }
}
