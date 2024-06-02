using RVAProject.Common.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RVAProject.Common.Repositories.Impl
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _dbContext;

        public BookRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddBook(Book book)
        {
            _dbContext.Books.Add(book);
            await SaveChangesBook();
        }

        public async Task DeleteBook(Book book)
        {
            _dbContext.Books.Remove(book);
            await SaveChangesBook();
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetAllBooks(Expression<Func<Book, bool>> predicate)
        {
            return await _dbContext.Books.Where(predicate).ToListAsync();
        }

        public async Task<Book> GetBook(Expression<Func<Book, bool>> predicate)
        {
            return await _dbContext.Books.Include(book => book.Authors)
                .Include(book => book.Publisher).FirstOrDefaultAsync(predicate);
        }

        public async Task<Book> GetBookById(Guid id)
        {
            return await _dbContext.Books.Include(book => book.Authors)
                .Include(book => book.Publisher).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task SaveChangesBook()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
