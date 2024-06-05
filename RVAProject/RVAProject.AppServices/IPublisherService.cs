using RVAProject.Common;
using RVAProject.Common.DTOs.PublisherDTO;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace RVAProject.AppServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPublisherService" in both code and config file together.
    [ServiceContract]
    public interface IPublisherService
    {
        [OperationContract]
        [FaultContract(typeof(CustomAppException))]
        Task AddPublisher(PublisherRequest publisherRequest, string token);

        [OperationContract]
        [FaultContract(typeof(CustomAppException))]
        Task<IEnumerable<PublisherInfo>> GetAllPublishers(string token);

        [OperationContract]
        [FaultContract(typeof(CustomAppException))]
        Task<PublisherInfo> GetPublisherById(Guid id, string token);

        [OperationContract]
        [FaultContract(typeof(CustomAppException))]
        Task<PublisherInfo> GetPublisherByPartialName(string filter, string token);

        [OperationContract]
        [FaultContract(typeof(CustomAppException))]
        Task UpdatePublisher(UpdatePublisherRequest updatePublisherRequest, string token);

        [OperationContract]
        [FaultContract(typeof(CustomAppException))]
        Task DeletePublisher(Guid id, string token);

    }
}
