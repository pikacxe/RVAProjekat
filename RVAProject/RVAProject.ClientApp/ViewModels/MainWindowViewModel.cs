using RVAProject.ClientApp.Modules;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;

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
