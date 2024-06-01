using RVAProject.ClientApp.Modules;
using System;
using System.Threading.Tasks;

namespace RVAProject.ClientApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string testMessage = string.Empty;
        public string TestMessage
        {
            get => testMessage;
            set
            {
                if (value != testMessage)
                {
                    testMessage = value;
                    OnPropertyChanged(nameof(TestMessage));
                }
            }
        }

        public AppCommand TestCommand { get; private set; }
        public MainWindowViewModel()
        {
            TestCommand = new AppCommand(TestServiceAsync);
        }

        private async Task TestServiceAsync()
        {
            try
            {
                BookService.BookServiceClient bookClient = new
                    BookService.BookServiceClient();

                await bookClient.DoWorkAsync();
                TestMessage = "Radi";
            }
            catch (Exception ex)
            {
                TestMessage = ex.Message;
            }
        }
    }
}
