using RVAProject.ClientApp.Modules;
using RVAProject.ClientApp.Services;
using RVAProject.Common.DTOs.UserDTO;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows;
using RVAProject.ClientApp.Services.Impl;
using System;
using RVAProject.Common;
using RVAProject.Common.Entities;

namespace RVAProject.ClientApp.ViewModels
{
    internal class LoginViewModel : BindableBase
    {
        private readonly IClientUserService _service;
        public LoginViewModel()
        {
            Title = "Login";
            _service = new ClientUserService();
            LoginCommand = new AppAsyncCommand(HandleLogin);
        }

        private async Task HandleLogin()
        {
            var token = "";
            try
            {
                token = await _service.LoginAsync(new LogInRequest { Username = Username, Password = Password });
                NavigationService.Instance.NavigateTo("dashboard");
            }
            catch (FaultException fe)
            {
                MessageBox.Show($"{fe.Message}");
            }
            catch (CustomAppException cae)
            {
                MessageBox.Show($"{cae.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");   
            }
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
