using RVAProject.Common.DTOs.UserDTO;

namespace RVAProject.ClientApp.ViewModels
{
    internal class AddUserViewModel : BindableBase
    {
        private UserInfo currentUser;
        public UserInfo CurrentUser
        {
            get => currentUser;
            set => SetProperty(ref currentUser, value);
        }

        public AddUserViewModel() {
            Title = "Register";
            CurrentUser = new UserInfo();
        }

        public AddUserViewModel(UserInfo user) : base()
        {
            CurrentUser = user;
        }
    }
}
