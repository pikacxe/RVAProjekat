using RVAProject.Contracts;
using System.ServiceModel;

namespace RVAProject.ServiceApp
{
    public class LibraryServiceImpl : ILibraryService
    {
        public string HelloWorld()
        {
            return "Hello from test service";
        }
    }
}
