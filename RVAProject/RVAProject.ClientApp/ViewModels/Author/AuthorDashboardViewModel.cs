﻿using RVAProject.ClientApp.Modules;
using RVAProject.ClientApp.Services;
using RVAProject.ClientApp.Services.Impl;
using RVAProject.Common.DTOs.AuthorDTO;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
using RVAProject.ClientApp.Helpers;

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

        public AuthorInfo selectedAuthor = default;
        public AuthorInfo SelectedAuthor
        {
            get => selectedAuthor;
            set
            {
                SetProperty(ref selectedAuthor, value);
                OnPropertyChanged("isSelectedAuthor");
            }
        }
        public bool isSelectedAuthor => SelectedAuthor != null;
        public AppAsyncCommand LoadAuthors { get; private set; }
        public AppCommand AddAuthor { get; private set; }
        public AppCommand UpdateAuthor { get; private set; }
        public AppAsyncCommand DeleteAuthor { get; private set; }

        public AuthorDashboardViewModel()
        {
            _service = new ClientAuthorService();
            authors = new ObservableCollection<AuthorInfo>();
            LoadAuthors = new AppAsyncCommand(HandleLoadAuthors);
            AddAuthor = new AppCommand(HandleAddAuthor);
            UpdateAuthor = new AppCommand(HandleUpdateAuthor);
            DeleteAuthor = new AppAsyncCommand(HandleDeleteAuthor);
        }

        private async Task HandleDeleteAuthor()
        {
            try
            {
                await _service.DeleteAuthorAsync(selectedAuthor.Id, NavigationService.Instance.serviceToken);
                Authors.Remove(selectedAuthor);
                Logger.Info(" Author deleted");
                selectedAuthor = default;
            }
            catch (Exception e)
            {
                Logger.Error(" Author delete error");
                Console.WriteLine(e.Message);
            }
        }

        private void HandleUpdateAuthor()
        {
            NavigationService.Instance.NavigateTo("editAuthor", selectedAuthor);
        }

        private void HandleAddAuthor()
        {
            NavigationService.Instance.NavigateTo("addAuthor");
        }

        private async Task HandleLoadAuthors()
        {
            var authors = await _service.GetAllAuthorsAsync(NavigationService.Instance.serviceToken);
            Authors.Clear();
            foreach (var author in authors)
            {
                Authors.Add(author);
            }
            Logger.Info(" Authors loaded");
        }
    }
}
