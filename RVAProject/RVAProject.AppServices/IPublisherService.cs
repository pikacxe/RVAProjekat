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
        Task AddPublisher(PublisherRequest publisherRequest);

        [OperationContract]
        [FaultContract(typeof(CustomAppException))]
        Task<IEnumerable<PublisherInfo>> GetAllPublishers();

        [OperationContract]
        [FaultContract(typeof(CustomAppException))]
        Task<PublisherInfo> GetPublisherById(Guid id);

        [OperationContract]
        [FaultContract(typeof(CustomAppException))]
        Task UpdatePublisher(UpdatePublisherRequest updatePublisherRequest);

        [OperationContract]
        [FaultContract(typeof(CustomAppException))]
        Task DeletePublisher(Guid id);

    }
}
