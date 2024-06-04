using RVAProject.ClientApp.Modules;
using RVAProject.ClientApp.Services;
using RVAProject.ClientApp.Services.Impl;
using RVAProject.Common.DTOs.AuthorDTO;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RVAProject.ClientApp.ViewModels
{
    public class AuthorDashboardViewModel : BindableBase
    {
        public readonly IClientAuthorService _service;
        public ObservableCollection<AuthorInfo> authors;
        public ObservableCollection<AuthorInfo> Authors
        {
            get => authors;
            set => SetProperty(ref authors, value);
        }

        public AppAsyncCommand LoadAuthors { get; private set; }
        public AppAsyncCommand AddAuthor { get; private set; }
        public AppAsyncCommand UpdateAuthor { get; private set; }
        public AppAsyncCommand DeleteAuthor { get; private set; }

        public AuthorDashboardViewModel()
        {
            _service = new ClientAuthorService();
            authors = new ObservableCollection<AuthorInfo>();
            LoadAuthors = new AppAsyncCommand(HandleLoadAuthors);
            AddAuthor = new AppAsyncCommand(HandleAddAuthor);
            UpdateAuthor = new AppAsyncCommand(HandleUpdateAuthor);
            DeleteAuthor = new AppAsyncCommand(HandleDeleteAuthor);
        }

        private async Task HandleDeleteAuthor()
        {
            throw new NotImplementedException();
        }

        private async Task HandleUpdateAuthor()
        {
            throw new NotImplementedException();
        }

        private async Task HandleAddAuthor()
        {
            throw new NotImplementedException();
        }

        private async Task HandleLoadAuthors()
        {
            throw new NotImplementedException();
        }
    }
}
