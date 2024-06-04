using RVAProject.ClientApp.ViewModels;

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
