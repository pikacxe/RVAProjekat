using RVAProject.ClientApp.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RVAProject.ClientApp.ViewModels
{
    internal class LoginViewModel : BindableBase
    {
        public LoginViewModel() {
            Title= "Login";
            LoginCommand = new AppCommand(HandleLogin);
            ToRegisterView = new AppCommand(HandleRedirect);
        }

        private void HandleLogin()
        {
            MessageBox.Show($"Username: {Username}, Password: {Password}");
            NavigationService.Instance.NavigateTo(ViewModelFactory.CreateViewModel("dashboard"));
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
            set=> SetProperty(ref username, value);
        }
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public AppCommand LoginCommand {  get; private set; }
        public AppCommand ToRegisterView { get; private set; }

    }
}
