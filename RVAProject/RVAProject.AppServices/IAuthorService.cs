using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using RVAProject.Common.DTOs.AuthorDTO;
using RVAProject.Common.DTOs.PublisherDTO;

using RVAProject.Common;

namespace RVAProject.AppServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAuthorService" in both code and config file together.
    [ServiceContract]
    public interface IAuthorService
    {

        [OperationContract]
        [FaultContract(typeof(CustomAppException))]
        Task AddAuthor(AuthorRequest authorRequest);

        [OperationContract]
        [FaultContract(typeof(CustomAppException))]
        Task<IEnumerable<AuthorInfo>> GetAllAuthors();

        [OperationContract]
        [FaultContract(typeof(CustomAppException))]
        Task<AuthorInfo> GetAuthorById(Guid id);

        [OperationContract]
        [FaultContract(typeof(CustomAppException))]
        Task UpdateAuthor(UpdateAuthorRequest updateAuthorRequest);

        [OperationContract]
        [FaultContract(typeof(CustomAppException))]
        Task DeleteAuthor(Guid id);
    }
}
