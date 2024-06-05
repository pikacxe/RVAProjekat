using RVAProject.Common.DTOs.PublisherDTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RVAProject.ClientApp.Services
{
    public interface IClientPublisherService
    {
        Task CreatePublisherAsync(PublisherRequest request);
        Task UpdatePublisherAsync(UpdatePublisherRequest request);
        Task DeletePublisherAsync(Guid id);
        Task<PublisherInfo> GetPublisherAsync(Guid id);
        Task<IEnumerable<PublisherInfo>> GetAllPublishersAsync();
    }
}
