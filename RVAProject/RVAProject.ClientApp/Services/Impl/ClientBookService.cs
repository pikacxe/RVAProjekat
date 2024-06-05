using RVAProject.ClientApp.BookService;
using RVAProject.Common.DTOs.BookDTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RVAProject.ClientApp.Services.Impl
{
    public class ClientBookService : IClientBookService
    {
        private readonly BookServiceClient _client;

        public ClientBookService()
        {
            _client = new BookServiceClient();
        }
        public async Task CreateBookAsync(CreateBookRequest request, string token)
        {
            await _client.CreateBookAsync(request, token);
        }
        public async Task DeleteBookAsync(Guid id, string token)
        {
            await _client.DeleteBookAsync(id, token);
        }
        public async Task<IEnumerable<BookInfo>> GetAllBooksAsync(string token)
        {
            return await _client.GetAllAsync(token);
        }
        public async Task<BookInfo> GetBookAsync(Guid id,string token)
        {
            return await _client.GetBookByIdAsync(id, token);
        }
        public async Task<IEnumerable<BookInfo>> GetBookForPublisherAsync(Guid publisherId, string token)
        {
            return await _client.GetAllAsync(token);
        }
        public async Task UpdateBookAsync(UpdateBookRequest request, string token)
        {
            await _client.UpdateBookAsync(request, token);
        }
    }
}
