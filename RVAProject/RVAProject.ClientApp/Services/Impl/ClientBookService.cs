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
        public async Task CreateBookAsync(CreateBookRequest request)
        {
            await _client.CreateBookAsync(request);
        }
        public async Task DeleteBookAsync(Guid id)
        {
            await _client.DeleteBookAsync(id);
        }
        public async Task<IEnumerable<BookInfo>> GetAllBooksAsync()
        {
            return await _client.GetAllAsync();
        }
        public async Task<BookInfo> GetBookAsync(Guid id)
        {
            return await _client.GetBookByIdAsync(id);
        }
        public async Task<IEnumerable<BookInfo>> GetBookForPublisherAsync(Guid publisherId)
        {
            return await _client.GetAllAsync();
        }
        public async Task UpdateBookAsync(UpdateBookRequest request)
        {
            await _client.UpdateBookAsync(request);
        }
    }
}
