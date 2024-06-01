using RVAProject.Common.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RVAProject.Common.Repositories
{
    public interface IBookRepository
    {
        Task AddBook(Book book);
        Task SaveChangesBook();
        Task DeleteBook(Book book);
        Task<Book> GetBookById(Guid id);
        Task<IEnumerable<Book>> GetAllBooks();
    }
}
