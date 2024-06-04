using RVAProject.Common.DTOs.AuthorDTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RVAProject.ClientApp.Services
{
    public interface IClientAuthorService
    {
        
        Task CreateAuthorAsync(AuthorRequest request);
        Task UpdateAuthorAsync(UpdateAuthorRequest request); 
        Task DeleteAuthorAsync(Guid id);
        Task<AuthorInfo> GetAuthorAsync(Guid id);
        Task<IEnumerable<AuthorInfo>> GetAllAuthorsAsync();
    }
}
