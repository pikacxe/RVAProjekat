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

        public AppAsyncCommand LoadPublishers { get; private set; }
        public AppAsyncCommand AddPublisher { get; private set; }
        public AppAsyncCommand UpdatePublisher { get; private set; }
        public AppAsyncCommand DeletePublisher { get; private set; }

        public PublisherDashboardViewModel()
        {
            publishers = new ObservableCollection<PublisherInfo>();
            _service = new ClientPublisherService();
            LoadPublishers = new AppAsyncCommand(HandleLoadPublishers);
            AddPublisher = new AppAsyncCommand(HandleAddPublisher);
            UpdatePublisher = new AppAsyncCommand(HandleUpdatePublisher);
            DeletePublisher = new AppAsyncCommand(HandleDeletePublisher);
        }

        private async Task HandleDeletePublisher()
        {
            throw new NotImplementedException();
        }

        private async Task HandleUpdatePublisher()
        {
            throw new NotImplementedException();
        }

        private async Task HandleAddPublisher()
        {
            throw new NotImplementedException();
        }
        private async Task HandleLoadPublishers()
        {
            throw new NotImplementedException();
        }

    }
}
