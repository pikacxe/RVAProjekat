using RVAProject.Common.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace RVAProject.Common.Repositories.Impl
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly LibraryDbContext _dbContext;

        public PublisherRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddPublisher(Publisher publisher)
        {
            _dbContext.Publishers.Add(publisher);
            await SaveChangesPublisher();
        }

        public async Task DeletePublisher(Publisher publisher)
        {
            _dbContext.Publishers.Remove(publisher);
            await SaveChangesPublisher();
        }

        public async Task<IEnumerable<Publisher>> GetAllPublishers()
        {
            return await _dbContext.Publishers.ToListAsync();
        }

        public async Task<Publisher> GetPublisherById(Guid id)
        {
            return await _dbContext.Publishers.Include(p => p.Books).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Publisher> GetPublisherByPartialName(string name)
        {
            return await _dbContext.Publishers.Include(p => p.Books)
                .FirstOrDefaultAsync(p => p.Name.ToLower().Contains(name.ToLower()));
        }

        public async Task SaveChangesPublisher()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
