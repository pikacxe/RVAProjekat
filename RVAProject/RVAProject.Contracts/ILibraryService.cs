using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace RVAProject.Contracts
{
    [ServiceContract]
    public interface ILibraryService
    {
        [OperationContract]
        [FaultContract(typeof(ApplicationException))]
        Task<string> HelloWorldAsync();
    }
}
