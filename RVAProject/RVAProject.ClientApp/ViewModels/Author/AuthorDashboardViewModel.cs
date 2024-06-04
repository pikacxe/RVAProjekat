using RVAProject.ClientApp.Modules;
using RVAProject.ClientApp.Services;
using RVAProject.ClientApp.Services.Impl;
using RVAProject.Common.DTOs.AuthorDTO;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace RVAProject.ClientApp.ViewModels
{
    public class AuthorDashboardViewModel : BindableBase
    {
        public readonly IClientAuthorService _service;
        private List<AuthorInfo> authorsCache = new List<AuthorInfo>();
        public ObservableCollection<AuthorInfo> authors;
        public ObservableCollection<AuthorInfo> Authors
        {
            get => authors;
            set => SetProperty(ref authors, value);
        }

        public AppAsyncCommand LoadAuthors { get; private set; }
        public AppAsyncCommand AddAuthor { get; private set; }
        public AppAsyncCommand<AuthorInfo> UpdateAuthor { get; private set; }
        public AppAsyncCommand<Guid> DeleteAuthor { get; private set; }

        public AuthorDashboardViewModel()
        {
            _service = new ClientAuthorService();
            authors = new ObservableCollection<AuthorInfo>();
            LoadAuthors = new AppAsyncCommand(HandleLoadAuthors);
            AddAuthor = new AppAsyncCommand(HandleAddAuthor);
            UpdateAuthor = new AppAsyncCommand<AuthorInfo>(HandleUpdateAuthor);
            DeleteAuthor = new AppAsyncCommand<Guid>(HandleDeleteAuthor);
        }

        private async Task HandleDeleteAuthor(Guid id)
        {
            try
            {
                await _service.DeleteAuthorAsync(id);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private async Task HandleUpdateAuthor(AuthorInfo authorInfo)
        {
            NavigationService.Instance.NavigateTo("updateAuthor", authorInfo);
        }

        private async Task HandleAddAuthor()
        {
            throw new NotImplementedException();
        }

        private async Task HandleLoadAuthors()
        {
            var authors = await _service.GetAllAuthorsAsync();
            authorsCache = authors.ToList();
            Authors.Clear();
            foreach (var author in authors)
            {
                Authors.Add(author);
            }
        }
    }
}
