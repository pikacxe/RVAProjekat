using RVAProject.ClientApp.AuthorService;
using RVAProject.ClientApp.BookService;
using RVAProject.ClientApp.Helpers;
using RVAProject.ClientApp.Modules;
using RVAProject.ClientApp.PublisherService;
using RVAProject.ClientApp.Services;
using RVAProject.ClientApp.Services.Impl;
using RVAProject.Common.DTOs.AuthorDTO;
using RVAProject.Common.DTOs.BookDTO;
using RVAProject.Common.DTOs.PublisherDTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVAProject.ClientApp.ViewModels
{
    internal class BookFormViewModel : BindableBase
    {
        private readonly BookServiceClient _client = new BookServiceClient();
        private readonly AuthorServiceClient _authorClient = new AuthorServiceClient();
        private readonly PublisherServiceClient _publisherClient = new PublisherServiceClient();
        public bool isUpdate;
        private BookInfo currentBook;
        public BookInfo CurrentBook
        {
            get { return currentBook; }
            set { SetProperty(ref currentBook, value); }
        }

        private PublisherInfo selectedPublisher;
        public PublisherInfo SelectedPublisher
        {
            get { return selectedPublisher; }
            set { SetProperty(ref selectedPublisher, value); }
        }
        private AuthorInfo selectedAuthors;
        public AuthorInfo SelectedAuthor
        {
            get { return selectedAuthors; }
            set { SetProperty(ref selectedAuthors, value); }
        }

        public IEnumerable<AuthorInfo> Authors { get; set; }
        public IEnumerable<PublisherInfo> Publishers { get; set; }

        public AppAsyncCommand Submit { get; private set; }
        public BookFormViewModel()
        {
            Title = "Add Book";
            isUpdate = false;
            CurrentBook = new BookInfo();
            Submit = new AppAsyncCommand(OnSubmit);
            Authors = _authorClient.GetAllAuthors(NavigationService.Instance.serviceToken);
            Publishers = _publisherClient.GetAllPublishers(NavigationService.Instance.serviceToken);
        }
        public BookFormViewModel(BookInfo bookInfo)
        {
            Title = "Edit Book";
            isUpdate = true;
            CurrentBook = bookInfo;
            Submit = new AppAsyncCommand(OnSubmit);
            Authors = _authorClient.GetAllAuthors(NavigationService.Instance.serviceToken);
            Publishers = _publisherClient.GetAllPublishers(NavigationService.Instance.serviceToken);
        }
        private async Task OnSubmit() {
            try
            {
                if (isUpdate)
                {
                    await _client.UpdateBookAsync(new UpdateBookRequest()
                    {
                        Id = CurrentBook.Id,
                        Title = CurrentBook.Title,
                        AuthorIds = new List<Guid>() { SelectedAuthor.Id },
                        Description = CurrentBook.Description,
                        PublisherId = SelectedPublisher.Id,
                        
                    }, NavigationService.Instance.serviceToken);
                    Logger.Info(" Book updated");
                }
                else
                {
                    await _client.CreateBookAsync(new CreateBookRequest()
                    {
                        Title = CurrentBook.Title,
                        AuthorIds = new List<Guid>() { SelectedAuthor.Id },
                        Description = CurrentBook.Description,
                        PublisherId = SelectedPublisher.Id,
                    }, NavigationService.Instance.serviceToken);
                    Logger.Info(" Book created");
                }
                NavigationService.Instance.NavigateTo("dashboard");
            }
            catch (Exception e)
            {
                Logger.Error(" Book update or create error");
            }
        }
    }
}
