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

        public async Task CreatePublisherAsync(PublisherRequest request, string token)
        {
            await _client.AddPublisherAsync(request, token);
        }

        public async Task DeletePublisherAsync(Guid id, string token)
        {
           await _client.DeletePublisherAsync(id, token);
        }

        public async Task<IEnumerable<PublisherInfo>> GetAllPublishersAsync(string token)
        {
            return await _client.GetAllPublishersAsync(token);
        }

        public async Task<PublisherInfo> GetPublisherAsync(Guid id, string token)
        {
            return await _client.GetPublisherByIdAsync(id, token);
        }

        public async Task UpdatePublisherAsync(UpdatePublisherRequest request, string token)
        {
            await _client.UpdatePublisherAsync(request, token);
        }
    }
}
