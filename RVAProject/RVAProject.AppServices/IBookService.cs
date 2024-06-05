using RVAProject.Common;
using RVAProject.Common.DTOs.BookDTO;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace RVAProject.AppServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBookService" in both code and config file together.
    [ServiceContract]
    public interface IBookService
    {
        [OperationContract]
        [FaultContract(typeof(CustomAppException))]
        Task<BookInfo> GetBookByIdAsync(Guid id, string token);
        [OperationContract]
        Task<IEnumerable<BookInfo>> GetAllAsync(string token);
        [OperationContract]
        [FaultContract(typeof(CustomAppException))]
        Task<BookInfo> GetBookByPartialNameAsync(string partialName, string token);
        [OperationContract]
        [FaultContract(typeof(CustomAppException))]
        Task CreateBookAsync(CreateBookRequest createBookRequest, string token);
        [OperationContract]
        [FaultContract(typeof(CustomAppException))]
        Task DeleteBookAsync(Guid id, string token);
        [OperationContract]
        [FaultContract(typeof(CustomAppException))]
        Task UpdateBookAsync(UpdateBookRequest updateBookRequest, string token);
    }
}
