using RVAProject.Common;
using RVAProject.Common.DTOs.AuthorDTO;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace RVAProject.AppServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAuthorService" in both code and config file together.
    [ServiceContract]
    public interface IAuthorService
    {

        [OperationContract]
        [FaultContract(typeof(CustomAppException))]
        Task AddAuthor(AuthorRequest authorRequest, string token);

        [OperationContract]
        [FaultContract(typeof(CustomAppException))]
        Task<IEnumerable<AuthorInfo>> GetAllAuthors(string token);

        [OperationContract]
        [FaultContract(typeof(CustomAppException))]
        Task<AuthorInfo> GetAuthorById(Guid id, string token);

        [OperationContract]
        [FaultContract(typeof(CustomAppException))]
        Task UpdateAuthor(UpdateAuthorRequest updateAuthorRequest, string token);

        [OperationContract]
        [FaultContract(typeof(CustomAppException))]
        Task DeleteAuthor(Guid id, string token);
    }
}
