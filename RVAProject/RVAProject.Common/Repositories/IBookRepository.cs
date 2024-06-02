using RVAProject.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RVAProject.Common.Repositories
{
    public interface IBookRepository
    {
        Task AddBook(Book book);
        Task SaveChangesBook();
        Task DeleteBook(Book book);
        Task<Book> GetBookById(Guid id);
        Task<Book> GetBook(Expression<Func<Book, bool>> predicate);
        Task<IEnumerable<Book>> GetAllBooks();
        Task<IEnumerable<Book>> GetAllBooks(Expression<Func<Book, bool>> predicate);

    }
}
