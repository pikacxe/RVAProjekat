using RVAProject.ClientApp.Modules;
using RVAProject.ClientApp.Services;
using RVAProject.ClientApp.Services.Impl;
using RVAProject.Common.DTOs.UserDTO;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RVAProject.ClientApp.ViewModels
{
    public class UserDashboardViewModel : BindableBase
    {
        private readonly IClientUserService _service;
        private ObservableCollection<UserInfo> users = new ObservableCollection<UserInfo>();
        public ObservableCollection<UserInfo> Users
        {
            get { return users; }
            set { SetProperty(ref users, value); }
        }
        public AppAsyncCommand LoadUsers { get; private set; }
        public AppAsyncCommand AddUser { get; private set; }
        public AppAsyncCommand UpdateUser { get; private set; }

        public UserDashboardViewModel()
        {
            _service = new ClientUserService();
            LoadUsers = new AppAsyncCommand(HandleLoadUsers);
            AddUser = new AppAsyncCommand(HandleAddUser);
            UpdateUser = new AppAsyncCommand(HandleUpdateUser);
        }

        private async Task HandleUpdateUser()
        {
            throw new NotImplementedException();
        }

        private async Task HandleAddUser()
        {
            throw new NotImplementedException();
        }

        private async Task HandleLoadUsers()
        {
            var users = await _service.GetAllAsync();
            Users.Clear();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }
    }
}

