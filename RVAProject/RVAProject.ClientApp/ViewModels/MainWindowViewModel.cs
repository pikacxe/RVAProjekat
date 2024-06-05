using RVAProject.ClientApp.Modules;
using System;

namespace RVAProject.ClientApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public AppCommand Logout { get; private set; }

        public MainWindowViewModel()
        {
            Logout = new AppCommand(OnLogout);
        }

        private void OnLogout()
        {
            NavigationService.Instance.serviceToken = null;
            NavigationService.Instance.NavigateTo("login");
        }
    }
}
