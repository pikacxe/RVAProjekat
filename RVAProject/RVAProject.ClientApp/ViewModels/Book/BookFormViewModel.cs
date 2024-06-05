using RVAProject.ClientApp.BookService;
using RVAProject.ClientApp.Modules;
using RVAProject.Common.DTOs.BookDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVAProject.ClientApp.ViewModels
{
    internal class BookFormViewModel : BindableBase
    {
        private readonly BookServiceClient _client = new BookServiceClient();
        public bool isUpdate;
        private BookInfo currentBook;
        public BookInfo CurrentBook
        {
            get { return currentBook; }
            set { SetProperty(ref currentBook, value); }
        }

        private Guid publisherId;
        public Guid PublisherId
        {
            get { return publisherId; }
            set { SetProperty(ref publisherId, value); }
        }
        private List<Guid> authorIds;
        public List<Guid> AuthorIds
        {
            get { return authorIds; }
            set { SetProperty(ref authorIds, value); }
        }

        public AppAsyncCommand Submit { get; private set; }
        public BookFormViewModel()
        {
            Title = "Add Book";
            isUpdate = false;
            Submit = new AppAsyncCommand(OnSubmit);
        }
        public BookFormViewModel(BookInfo bookInfo)
        {
            Title = "Edit Book";
            isUpdate = true;
            CurrentBook = bookInfo;
            Submit = new AppAsyncCommand(OnSubmit);
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
                        AuthorIds = AuthorIds,
                        Description = CurrentBook.Description,
                        PublisherId = CurrentBook.Publisher.Id,
                        
                    }, NavigationService.Instance.serviceToken);
                }
                else
                {
                    await _client.CreateBookAsync(new CreateBookRequest()
                    {
                        Title = CurrentBook.Title,
                        AuthorIds = AuthorIds,
                        Description = CurrentBook.Description,
                        PublisherId = PublisherId
                    }, NavigationService.Instance.serviceToken);
                }
            }
            catch (Exception e)
            {
                // TODO log error
            }
        }
    }
}
