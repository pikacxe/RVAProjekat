using RVAProject.ClientApp.Helpers;
using RVAProject.ClientApp.Modules;
using RVAProject.ClientApp.PublisherService;
using RVAProject.Common.DTOs.PublisherDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVAProject.ClientApp.ViewModels
{
    internal class PublisherFormViewModel : BindableBase
    {
        private PublisherServiceClient _client = new PublisherServiceClient();
        public bool isUpdate;
        private PublisherInfo currentPublisher;
        public PublisherInfo CurrentPublisher
        {
            get { return currentPublisher; }
            set { SetProperty(ref currentPublisher, value); }
        }

        public AppAsyncCommand Submit { get; private set; }
        public PublisherFormViewModel()
        {
            Title = "Add Publisher";
            currentPublisher = new PublisherInfo();
            isUpdate = false;
            Submit = new AppAsyncCommand(OnSubmit);
        }

        public PublisherFormViewModel(PublisherInfo publisherInfo)
        {
            Title = "Edit Publisher";
            isUpdate = true;
            CurrentPublisher = publisherInfo;
            Submit = new AppAsyncCommand(OnSubmit);
        }

        private async Task OnSubmit()
        {
            try
            {
                if (isUpdate)
                {
                    await _client.UpdatePublisherAsync(new UpdatePublisherRequest()
                    {
                        Id = CurrentPublisher.Id,
                        Name = CurrentPublisher.Name,
                        Address = CurrentPublisher.Address,
                        Email = currentPublisher.Email,
                    }, NavigationService.Instance.serviceToken);
                    Logger.Info($" Publisher named {CurrentPublisher.Name} updated");
                }
                else
                {
                    await _client.AddPublisherAsync(new PublisherRequest()
                    {
                        Name = CurrentPublisher.Name,
                        Address = CurrentPublisher.Address,
                        Email = currentPublisher.Email,
                    }, NavigationService.Instance.serviceToken);
                    Logger.Info($" Publisher named {CurrentPublisher.Name} added");
                }
                NavigationService.Instance.NavigateTo("dashboard");
            }
            catch (Exception ex)
            {
                Logger.Error(" Publisher update or add error");
            }
        }

    }
}
