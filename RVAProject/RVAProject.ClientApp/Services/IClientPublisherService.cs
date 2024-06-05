using RVAProject.Common.DTOs.PublisherDTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RVAProject.ClientApp.Services
{
    public interface IClientPublisherService
    {
        Task CreatePublisherAsync(PublisherRequest request, string token);
        Task UpdatePublisherAsync(UpdatePublisherRequest request, string token);
        Task DeletePublisherAsync(Guid id, string token);
        Task<PublisherInfo> GetPublisherAsync(Guid id, string token);
        Task<IEnumerable<PublisherInfo>> GetAllPublishersAsync(string token);
    }
}
