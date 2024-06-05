﻿using RVAProject.ClientApp.Modules;
using RVAProject.ClientApp.Services;
using RVAProject.ClientApp.Services.Impl;
using RVAProject.Common.DTOs.UserDTO;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows;

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
                NavigationService.Instance.serviceToken = token;
                NavigationService.Instance.NavigateTo("dashboard");
            }
            catch (FaultException fe)
            {
                MessageBox.Show($"{fe.Message}");
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
    }
}
