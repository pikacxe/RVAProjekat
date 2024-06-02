using RVAProject.Common.DTOs.BookDTO;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using RVAProject.Common;

namespace RVAProject.AppServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBookService" in both code and config file together.
    [ServiceContract]
    public interface IBookService
    {
        [OperationContract]
        [FaultContract(typeof(CustomAppException))]
        Task<BookInfo> GetBookByIdAsync(Guid id);
        [OperationContract]
        Task<IEnumerable<BookInfo>> GetAllAsync();
        [OperationContract]
        [FaultContract(typeof(CustomAppException))]
        Task<BookInfo> GetBookByPartialNameAsync(string partialName);
        [OperationContract]
        [FaultContract(typeof(CustomAppException))]
        Task CreateBookAsync(CreateBookRequest createBookRequest);
        [OperationContract]
        [FaultContract(typeof(CustomAppException))]
        Task DeleteBookAsync(Guid id);
        [OperationContract]
        [FaultContract(typeof(CustomAppException))]
        Task UpdateBookAsync(UpdateBookRequest updateBookRequest);
    }
}
