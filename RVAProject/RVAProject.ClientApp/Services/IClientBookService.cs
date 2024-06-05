using RVAProject.Common.DTOs.BookDTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RVAProject.ClientApp.Services
{
    public interface IClientBookService
    {
        Task CreateBookAsync(CreateBookRequest request);
        Task UpdateBookAsync(UpdateBookRequest request);
        Task DeleteBookAsync(Guid id);
        Task<BookInfo> GetBookAsync(Guid id);
        Task<IEnumerable<BookInfo>> GetAllBooksAsync();
        Task<IEnumerable<BookInfo>> GetBookForPublisherAsync(Guid publisherId);
    }
}
