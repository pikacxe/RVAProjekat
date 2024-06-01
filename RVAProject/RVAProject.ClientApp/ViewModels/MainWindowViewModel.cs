using RVAProject.ClientApp.Modules;
using RVAProject.Contracts;
using System;
using System.ServiceModel;

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
            TestCommand = new AppCommand(TestService);
        }

        private void TestService()
        {
            try
            {
                var factory = new ChannelFactory<ILibraryService>("LibraryService");
                var proxy = factory.CreateChannel();
                TestMessage = proxy.HelloWorld();
                factory.Close();
            }
            catch (Exception ex)
            {
                TestMessage = ex.Message;
            }
        }
    }
}
