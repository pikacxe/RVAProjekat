using RVAProject.ClientApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVAProject.ClientApp.Modules
{
    internal static class ViewModelFactory
    {
        public static BindableBase CreateViewModel(string viewModelName = "login")
        {
            switch (viewModelName.Trim().ToLower())
            {
                case "login": return new LoginViewModel();
                case "register": return new AddUserViewModel();
                case "dashboard": return new DashboardViewModel();
                default: return new LoginViewModel();
            }
        }
    }
}
