namespace RVAProject.ClientApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        private string connectionMessage = string.Empty;
        public string ConnectionMessage
        {
            get => connectionMessage;
            set => SetProperty(ref connectionMessage, value);
        }
        public MainWindowViewModel()
        {
            connectionMessage = "Not connected";
        }
    }
}
