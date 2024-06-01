using RVAProject.Common.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RVAProject.Common.Repositories
{
    public interface IPublisherRepository
    {
        Task AddPublisher(Publisher publisher);
        Task SaveChangesPublisher();
        Task DeletePublisher(Publisher publisher);
        Task<Publisher> GetPublisherById(Guid id);
        Task<IEnumerable<Publisher>> GetAllPublishers();
    }
}
