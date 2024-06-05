using RVAProject.ClientApp.ViewModels;
using RVAProject.Common.DTOs.AuthorDTO;
using RVAProject.Common.DTOs.BookDTO;
using RVAProject.Common.DTOs.PublisherDTO;
using RVAProject.Common.DTOs.UserDTO;

namespace RVAProject.ClientApp.Modules
{
    internal static class ViewModelFactory
    {
        public static BindableBase CreateViewModel(string viewModelName = "login", object model = null)
        {
            switch (viewModelName.Trim().ToLower())
            {
                case "login": return new LoginViewModel();
                case "dashboard": return new DashboardViewModel();
                case "adduser": return new UserFormViewModel();
                case "edituser": return new UserFormViewModel(model as UserInfo);
                case "addpublisher": return new PublisherFormViewModel();
                case "editpublisher": return new PublisherFormViewModel(model as PublisherInfo);
                case "addbook": return new BookFormViewModel();
                case "editbook": return new BookFormViewModel(model as BookInfo);
                case "addauthor": return new AuthorFormViewModel();
                case "editauthor": return new AuthorFormViewModel(model as AuthorInfo);
                default: return new LoginViewModel();
            }
        }
    }
}
