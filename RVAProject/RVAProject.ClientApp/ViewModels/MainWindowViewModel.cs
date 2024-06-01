using RVAProject.ClientApp.Modules;
using RVAProject.Contracts;
using System;
using System.ServiceModel;
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
                var factory = new ChannelFactory<ILibraryService>("LibraryService");
                var proxy = factory.CreateChannel();

                TestMessage = await proxy.HelloWorldAsync();
                factory.Close();
            }
            catch (Exception ex)
            {
                TestMessage = ex.Message;
            }
        }
    }
}
