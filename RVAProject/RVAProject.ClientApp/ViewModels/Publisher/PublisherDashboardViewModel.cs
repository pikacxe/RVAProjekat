using RVAProject.ClientApp.Modules;
using RVAProject.ClientApp.Services;
using RVAProject.ClientApp.Services.Impl;
using RVAProject.Common.DTOs.PublisherDTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;

namespace RVAProject.ClientApp.ViewModels
{
    public class PublisherDashboardViewModel : BindableBase
    {
        private readonly IClientPublisherService _service;
        private List<PublisherInfo> publisherCache = new List<PublisherInfo>();
        private ObservableCollection<PublisherInfo> publishers;
        public ObservableCollection<PublisherInfo> Publishers
        {
            get => publishers;
            set => SetProperty(ref publishers, value);
        }
        private PublisherInfo selectedPublisher = default;
        public bool isSelectedPublisher => SelectedPublisher != null;

        private string filterString = string.Empty;
        public string FilterString
        {
            get => filterString;
            set
            {
                SetProperty(ref filterString, value);
                FilterPublishers();
            }
        }

        private void FilterPublishers()
        {
            Publishers.Clear();
            if(string.IsNullOrWhiteSpace(filterString))
            {
                Publishers = new ObservableCollection<PublisherInfo>(publisherCache);
                return;
            }
            Publishers = new ObservableCollection<PublisherInfo>(publisherCache.Where(p => p.Name.ToLower().Contains(filterString.ToLower())));
        }

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
                selectedPublisher = default;
            }
            catch (Exception e)
            {
                //TODO log error
            }
        }

        private void HandleUpdatePublisher()
        {
           NavigationService.Instance.NavigateTo("updatePublisher", selectedPublisher);
        }

        private void HandleAddPublisher()
        {
           NavigationService.Instance.NavigateTo("addPublisher");
        }
        private async Task HandleLoadPublishers()
        {          
            try
            {
                var publishers = await _service.GetAllPublishersAsync(NavigationService.Instance.serviceToken);
                publisherCache = publishers.ToList();
                Publishers.Clear();
                foreach (var publisher in publishers)
                {
                    Publishers.Add(publisher);
                }
            }
            catch (Exception e)
            {
                //TODO log error
            }
        }

    }
}
