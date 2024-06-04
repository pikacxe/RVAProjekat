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
                case "register": return new AddUserViewModel();
                case "dashboard": return new DashboardViewModel();
                case "adduser": return new AddUserViewModel();
                case "edituser": return new AddUserViewModel(model as UserInfo);
                    /*
                case "addpublisher": return new AddPublisherViewModel();
                case "editpublisher": return new AddPublisherViewModel(model as PublisherInfo);
                case "addbook": return new AddBookViewModel();
                case "editbook": return new AddBookViewModel(model as BookInfo);
                case "addauthor": return new AddAuthorViewModel();
                case "editauthor": return new AddAuthorViewModel(model as AuthorInfo);

                    */
                default: return new LoginViewModel();
            }
        }
    }
}
