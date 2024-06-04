using RVAProject.ClientApp.Modules;
using RVAProject.Common.DTOs.AuthorDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVAProject.ClientApp.ViewModels.Author
{
    internal class AuthorFormViewModel : BindableBase
    {
        private AuthorServiceClient _client = new AuthorServiceClient();
        private bool isUpdate;
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
                //if(isUpdate)
                //{
                //    await _client.UpdateAuthorAsync(new UpdateAuthorRequest()
                //    {
                //        Id = CurrentAuthor.Id,
                //        FirstName = CurrentAuthor.FirstName,
                //        LastName = CurrentAuthor.LastName,
                //        DateOfBirth = CurrentAuthor.DateOfBirth,
                //        DateOfDeath = CurrentAuthor.DateOfDeath
                //    });
                //}
                //else
                //{
                //    await _client.AddAuthorAsync(new AuthorRequest()
                //    {
                //        FirstName = CurrentAuthor.FirstName,
                //        LastName = CurrentAuthor.LastName,
                //        DateOfBirth = CurrentAuthor.DateOfBirth,
                //        DateOfDeath = CurrentAuthor.DateOfDeath
                //    });
                //}
            }
            catch (Exception ex)
            {
                // TODO log error
            }
        }
    }
}
