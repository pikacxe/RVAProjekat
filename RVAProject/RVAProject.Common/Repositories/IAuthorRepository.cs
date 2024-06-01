using RVAProject.Common.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RVAProject.Common.Repositories
{
    public interface IAuthorRepository
    {
        Task AddAuthor(Author author);
        Task SaveChangesAuthor();
        Task DeleteAuthor(Author author);
        Task<Author> GetAuthorById(Guid id);
        Task<IEnumerable<Author>> GetAllAuthors();
    }
}
