using RVAProject.ClientApp.Helpers;
using RVAProject.ClientApp.Modules;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVAProject.ClientApp.ViewModels
{
    public class UserDashboardViewModel : BindableBase
    {
        private ObservableCollection<string> notifications;
        public ObservableCollection<string> Notifications
        {
            get
            {
                return notifications;
            }
            set
            {
                SetProperty(ref notifications, value);
            }
        }

        public AppCommand RefreshNotifications { get; private set; }
        public AppCommand NavigateAdd { get; private set;}
        public AppCommand NavigateUpdate { get; private set; }

        public UserDashboardViewModel()
        {
            RefreshNotifications = new AppCommand(OnRefreshNotifications);
            NavigateAdd = new AppCommand(OnNavigateAdd);
            NavigateUpdate = new AppCommand(OnNavigateUpdate);
            notifications = new ObservableCollection<string>(Logger.messages);
        }

        private void OnNavigateUpdate()
        {
            NavigationService.Instance.NavigateTo("edituser");
        }

        private void OnNavigateAdd()
        {
            NavigationService.Instance.NavigateTo("adduser");
        }

        private void OnRefreshNotifications()
        {
            Notifications = new ObservableCollection<string>(Logger.messages);
        }
    }
}
