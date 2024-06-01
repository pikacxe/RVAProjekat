using System;
using System.ServiceModel;

namespace RVAProject.Contracts
{
    [ServiceContract]
    public interface ILibraryService
    {
        [OperationContract]
        [FaultContract(typeof(ApplicationException))]
        string HelloWorld();
    }
}
