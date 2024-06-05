using RVAProject.ClientApp.Helpers;
using RVAProject.ClientApp.Modules;
using RVAProject.ClientApp.UserService;
using RVAProject.Common.DTOs.UserDTO;
using System;
using System.Threading.Tasks;

namespace RVAProject.ClientApp.ViewModels
{
    internal class UserFormViewModel : BindableBase
    {
        private UserServiceClient _client = new UserServiceClient();
        private bool isUpdate;
        private UserInfo currentUser;
        public UserInfo CurrentUser
        {
            get { return currentUser; }
            set { SetProperty(ref currentUser, value); }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        public AppAsyncCommand Submit { get; private set; }

        public UserFormViewModel()
        {
            Title = "Add User";
            isUpdate = false;
        }
        public UserFormViewModel(UserInfo userInfo)
        {
            Title = "Edit User";
            isUpdate = true;
            CurrentUser = userInfo;
            Submit = new AppAsyncCommand(OnSubmit);
        }

        private async Task OnSubmit()
        {
            try
            {
                if (isUpdate)
                {
                    await _client.UpdateUserAsync(new UpdateUserRequest()
                    {
                        Id = CurrentUser.Id,
                        FirstName = CurrentUser.FirstName,
                        LastName = CurrentUser.LastName,
                    },NavigationService.Instance.serviceToken);
                    Logger.Info($"User named {CurrentUser.FirstName} updated");
                }
                else
                {
                    await _client.AddUserAsync(new UserRequest()
                    {
                        Username = CurrentUser.Username,
                        Password = Password,
                        FirstName = CurrentUser.FirstName,
                        LastName = CurrentUser.LastName,
                    }, NavigationService.Instance.serviceToken);
                    Logger.Info($"User named {CurrentUser.FirstName} added");
                }
            }
            catch(Exception ex)
            {
                Logger.Error($"User add or update error");
            }
        }
    }
}
