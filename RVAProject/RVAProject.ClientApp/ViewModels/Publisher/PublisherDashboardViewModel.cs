using RVAProject.ClientApp.Helpers;
using RVAProject.ClientApp.Modules;
using RVAProject.ClientApp.Services;
using RVAProject.ClientApp.Services.Impl;
using RVAProject.Common.DTOs.PublisherDTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            set
            {
                SetProperty(ref publishers, value);
            }
        }
        private PublisherInfo selectedPublisher = default;
        public bool isSelectedPublisher => SelectedPublisher != null;

        private string filterText = string.Empty;
        public string FilterText
        {
            get => filterText;
            set
            {
                if(value != filterText)
                {
                    filterText = value;
                    OnPropertyChanged("FilterText");
                    OnPropertyChanged("Publishers");
                }
            }
        }

        private bool FindAll(PublisherInfo publisher)
        {
            Regex regex = new Regex(filterText, RegexOptions.IgnoreCase);
            return regex.IsMatch(publisher.Name);
        }

        public PublisherInfo SelectedPublisher
        {
            get => selectedPublisher;
            set
            {
                SetProperty(ref selectedPublisher, value);
                OnPropertyChanged("isSelectedPublisher");
            }
        }
        public AppAsyncCommand LoadPublishers { get; private set; }
        public AppCommand AddPublisher { get; private set; }
        public AppCommand UpdatePublisher { get; private set; }
        public AppCommand FilterPublishers { get; private set; }
        public AppAsyncCommand DeletePublisher { get; private set; }
        public AppAsyncCommand DuplicatePublishers { get; private set; }

        public PublisherDashboardViewModel()
        {
            publishers = new ObservableCollection<PublisherInfo>();
            _service = new ClientPublisherService();
            LoadPublishers = new AppAsyncCommand(HandleLoadPublishers);
            AddPublisher = new AppCommand(HandleAddPublisher);
            UpdatePublisher = new AppCommand(HandleUpdatePublisher);
            DeletePublisher = new AppAsyncCommand(HandleDeletePublisher);
            DuplicatePublishers = new AppAsyncCommand(HandleDuplicatePublishers);
            FilterPublishers = new AppCommand(HandleFilterPublishers);
        }

        private void HandleFilterPublishers()
        {
            Publishers = new ObservableCollection<PublisherInfo>(publisherCache.Where(r => FindAll(r)));
        }

        private async Task HandleDuplicatePublishers()
        {
            try
            {
                foreach(var p in publisherCache)
                {
                    await _service.CreatePublisherAsync(new PublisherRequest { Name = p.Name, Address = p.Name, Email = p.Email }, NavigationService.Instance.serviceToken);
                }
                Logger.Info(" Publishers duplicated");
            }
            catch (Exception e)
            {
                Logger.Error(" Publishers duplicate error");
            }
        }

        private async Task HandleDeletePublisher()
        {
            try
            {
                await _service.DeletePublisherAsync(selectedPublisher.Id, NavigationService.Instance.serviceToken);
                Logger.Info($" Publisher named :{selectedPublisher.Name} deleted");
                Publishers.Remove(selectedPublisher);
                selectedPublisher = default;
            }
            catch (Exception e)
            {
                Logger.Info($" Publisher delete error");
            }
        }

        private void HandleUpdatePublisher()
        {
           NavigationService.Instance.NavigateTo("editPublisher", selectedPublisher);
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
                Logger.Info(" Publishers loaded");
            }
            catch (Exception e)
            {
                Logger.Error(" Publishers load error");
            }
        }

    }
}
