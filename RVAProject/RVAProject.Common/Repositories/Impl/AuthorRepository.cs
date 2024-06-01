using RVAProject.Common.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace RVAProject.Common.Repositories.Impl
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryDbContext _dbContext;

        public AuthorRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAuthor(Author author)
        {
            _dbContext.Authors.Add(author);
            await SaveChangesAuthor();
        }

        public async Task DeleteAuthor(Author author)
        {
            _dbContext.Authors.Remove(author);
            await SaveChangesAuthor();
        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await _dbContext.Authors.ToListAsync();
        }

        public async Task<Author> GetAuthorById(Guid id)
        {
            return await _dbContext.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == id);
        }


        public async Task SaveChangesAuthor()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
