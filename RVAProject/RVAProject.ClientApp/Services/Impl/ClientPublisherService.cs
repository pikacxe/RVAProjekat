using RVAProject.ClientApp.PublisherService;
using RVAProject.Common.DTOs.PublisherDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVAProject.ClientApp.Services.Impl
{
    public class ClientPublisherService : IClientPublisherService
    {
        private readonly PublisherServiceClient _client;

        public ClientPublisherService()
        {
            _client = new PublisherServiceClient();
        }

        public async Task CreatePublisherAsync(PublisherRequest request)
        {
            await _client.AddPublisherAsync(request);
        }

        public async Task DeletePublisherAsync(Guid id)
        {
           await _client.DeletePublisherAsync(id);
        }

        public async Task<IEnumerable<PublisherInfo>> GetAllPublishersAsync()
        {
            return await _client.GetAllPublishersAsync();
        }

        public async Task<PublisherInfo> GetPublisherAsync(Guid id)
        {
            return await _client.GetPublisherByIdAsync(id);
        }

        public async Task UpdatePublisherAsync(UpdatePublisherRequest request)
        {
           await _client.UpdatePublisherAsync(request);
        }
    }
}
