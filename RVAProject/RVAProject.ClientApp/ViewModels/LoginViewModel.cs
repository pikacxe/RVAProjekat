using RVAProject.ClientApp.Modules;
using RVAProject.Common.DTOs.UserDTO;
using RVAProject.Common.Helpers;
using System.Security.Claims;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows;

namespace RVAProject.ClientApp.ViewModels
{
    internal class LoginViewModel : BindableBase
    {
        public LoginViewModel()
        {
            Title = "Login";
            LoginCommand = new AppAsyncCommand(HandleLogin);
            ToRegisterView = new AppCommand(HandleRedirect);
        }

        private async Task HandleLogin()
        {
            UserService.UserServiceClient userClient = new UserService.UserServiceClient();

            var token = "";
            try
            {
                token = await userClient.LogInAsync(new LogInRequest { Username = Username, Password = Password });
            }
            catch (FaultException ex)
            {
                MessageBox.Show($"{ex.Message}");
            }

            if (TokenHelper.ValidateToken(token, out ClaimsPrincipal principal))
            {
                var userId = principal.FindFirst("user_id").Value;
                var userRole = principal.FindFirst("user_role").Value;

                MessageBox.Show($"Token is valid. User ID: {userId}, User Role: {userRole}");
                NavigationService.Instance.NavigateTo(ViewModelFactory.CreateViewModel("dashboard"));
            }
            else
            {
                MessageBox.Show("Invalid token.");
            }
        }
        private void HandleRedirect()
        {
            NavigationService.Instance.NavigateTo(ViewModelFactory.CreateViewModel("register"));
        }

        private string username;
        private string password;
        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public AppAsyncCommand LoginCommand { get; private set; }
        public AppCommand ToRegisterView { get; private set; }

    }
}
