using RVAProject.Common.DTOs.AuthorDTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RVAProject.ClientApp.Services
{
    public interface IClientAuthorService
    {
        
        Task CreateAuthorAsync(AuthorRequest request, string token);
        Task UpdateAuthorAsync(UpdateAuthorRequest request, string token); 
        Task DeleteAuthorAsync(Guid id, string token);
        Task<AuthorInfo> GetAuthorAsync(Guid id, string token);
        Task<IEnumerable<AuthorInfo>> GetAllAuthorsAsync(string token);
    }
}
