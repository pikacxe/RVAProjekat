using RVAProject.ClientApp.AuthorService;
using RVAProject.ClientApp.Modules;
using RVAProject.Common.DTOs.AuthorDTO;
using System;
using System.Threading.Tasks;

namespace RVAProject.ClientApp.ViewModels
{
    internal class AuthorFormViewModel : BindableBase
    {
        private AuthorServiceClient _client = new AuthorServiceClient();
        public bool isUpdate;
        private AuthorInfo currentAuthor;
        public AuthorInfo CurrentAuthor
        {
            get { return currentAuthor; }
            set { SetProperty(ref currentAuthor, value); }
        }

        public AppAsyncCommand Submit { get; private set; }
        public AuthorFormViewModel()
        {
            Title = "Add Author";
            isUpdate = false;
            Submit = new AppAsyncCommand(OnSubmit);
        }
        public AuthorFormViewModel(AuthorInfo authorInfo)
        {
            Title = "Edit Author";
            isUpdate = true;
            CurrentAuthor = authorInfo;
            Submit = new AppAsyncCommand(OnSubmit);
        }

        public async Task OnSubmit()
        {
            try
            {
                if (isUpdate)
                {
                    await _client.UpdateAuthorAsync(new UpdateAuthorRequest()
                    {
                        Id = CurrentAuthor.Id,
                        FullName = CurrentAuthor.FullName,
                        PenName = CurrentAuthor.PenName,
                        HasNobelPrize = CurrentAuthor.HasNobelPrize
                    }, NavigationService.Instance.serviceToken);
                }
                else
                {
                    await _client.AddAuthorAsync(new AuthorRequest()
                    {
                        FullName = CurrentAuthor.FullName,
                        PenName = CurrentAuthor.PenName,
                        HasNobelPrize = CurrentAuthor.HasNobelPrize
                    }, NavigationService.Instance.serviceToken);
                }
            }
            catch (Exception ex)
            {
                // TODO log error
            }
        }
    }
}
