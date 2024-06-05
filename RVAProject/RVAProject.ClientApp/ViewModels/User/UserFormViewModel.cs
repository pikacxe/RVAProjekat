using RVAProject.ClientApp.Helpers;
using RVAProject.ClientApp.Modules;
using RVAProject.ClientApp.UserService;
using RVAProject.Common;
using RVAProject.Common.DTOs.UserDTO;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows;

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
            set
            {
                SetProperty(ref currentUser, value);
                OnPropertyChanged("isAdmin");
            }
        }

        public Visibility visibilityUpdate => isUpdate ? Visibility.Hidden : Visibility.Visible;
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
            CurrentUser = new UserInfo();
            Submit = new AppAsyncCommand(OnSubmit);
        }
        public UserFormViewModel(bool isEdit)
        {
            Title = "Edit User";
            isUpdate = isEdit;
            CurrentUser = _client.GetUserById(NavigationService.Instance.serviceToken);
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
                    }, NavigationService.Instance.serviceToken);
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
                NavigationService.Instance.NavigateTo("dashboard");
            }
            catch(FaultException fe)
            {
                MessageBox.Show(fe.Message);
                NavigationService.Instance.NavigateTo("dashboard");
            }
            catch (Exception ex)
            {
                Logger.Error($"User add or update error");
            }
        }
    }
}
