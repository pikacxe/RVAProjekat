using RVAProject.Common;
using RVAProject.Common.DTOs.UserDTO;
using System.ServiceModel;
using System.Threading.Tasks;

namespace RVAProject.AppServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserService" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        [FaultContract(typeof(CustomAppException))]
        Task<string> LogIn(LogInRequest logInData);

        [OperationContract]
        [FaultContract(typeof(CustomAppException))]
        Task AddUser(UserRequest addUserData);

        [OperationContract]
        [FaultContract(typeof(CustomAppException))]
        Task UpdateUser(UpdateUserRequest updateUserData);
    }
}
