using RVAProject.Common.DTOs.BookDTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RVAProject.ClientApp.Services
{
    public interface IClientBookService
    {
        Task CreateBookAsync(CreateBookRequest request, string token);
        Task UpdateBookAsync(UpdateBookRequest request, string token);
        Task DeleteBookAsync(Guid id, string token);
        Task<BookInfo> GetBookAsync(Guid id, string token);
        Task<IEnumerable<BookInfo>> GetAllBooksAsync(string token);
        Task<IEnumerable<BookInfo>> GetBookForPublisherAsync(Guid publisherId, string token);
    }
}
