using RVAProject.ClientApp.Helpers;
using RVAProject.ClientApp.Modules;
using RVAProject.ClientApp.Services;
using RVAProject.ClientApp.Services.Impl;
using RVAProject.Common.DTOs.PublisherDTO;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RVAProject.ClientApp.ViewModels
{
    public class PublisherDashboardViewModel : BindableBase
    {
        private readonly IClientPublisherService _service;
        private ObservableCollection<PublisherInfo> publishers;
        public ObservableCollection<PublisherInfo> Publishers
        {
            get => publishers;
            set => SetProperty(ref publishers, value);
        }
        private PublisherInfo selectedPublisher = default;
        public PublisherInfo SelectedPublisher
        {
            get => selectedPublisher;
            set => SetProperty(ref selectedPublisher, value);
        }
        public AppAsyncCommand LoadPublishers { get; private set; }
        public AppCommand AddPublisher { get; private set; }
        public AppCommand UpdatePublisher { get; private set; }
        public AppAsyncCommand DeletePublisher { get; private set; }

        public PublisherDashboardViewModel()
        {
            publishers = new ObservableCollection<PublisherInfo>();
            _service = new ClientPublisherService();
            LoadPublishers = new AppAsyncCommand(HandleLoadPublishers);
            AddPublisher = new AppCommand(HandleAddPublisher);
            UpdatePublisher = new AppCommand(HandleUpdatePublisher);
            DeletePublisher = new AppAsyncCommand(HandleDeletePublisher);
        }

        private async Task HandleDeletePublisher()
        {
            try
            {
                await _service.DeletePublisherAsync(selectedPublisher.Id, NavigationService.Instance.serviceToken);
                Publishers.Remove(selectedPublisher);
                Logger.Info($" Publisher named :{selectedPublisher.Name} deleted");
                selectedPublisher = default;
            }
            catch (Exception e)
            {
                Logger.Info($" Publisher delet error");
            }
        }

        private void HandleUpdatePublisher()
        {
           NavigationService.Instance.NavigateTo("updatePublisher", selectedPublisher);
            Logger.Info($" Publisher named: {selectedPublisher.Name} updated");
        }

        private void HandleAddPublisher()
        {
           NavigationService.Instance.NavigateTo("addPublisher");
            Logger.Info(" Publisher added");
        }
        private async Task HandleLoadPublishers()
        {          
            try
            {
                var publishers = await _service.GetAllPublishersAsync(NavigationService.Instance.serviceToken);
                Publishers.Clear();
                foreach (var publisher in publishers)
                {
                    Publishers.Add(publisher);
                }
                Logger.Info(" Publishers loaded");
            }
            catch (Exception e)
            {
                Logger.Error(" Publishers load error");
            }
        }

    }
}
