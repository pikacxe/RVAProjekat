
using RVAProject.ClientApp.Helpers;
using RVAProject.ClientApp.Modules;
using RVAProject.ClientApp.Services;
using RVAProject.ClientApp.Services.Impl;
using RVAProject.Common.DTOs.BookDTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RVAProject.ClientApp.ViewModels
{
    public class BookDashboardViewModel : BindableBase
    {
        private readonly IClientBookService _service;

        private ObservableCollection<BookInfo> books;
        public ObservableCollection<BookInfo> Books
        {
            get => books;
            set => SetProperty(ref books, value);
        }

        private BookInfo selectedBook = default;
        public BookInfo SelectedBook
        {
            get => selectedBook;
            set
            {
                SetProperty(ref selectedBook, value);
                OnPropertyChanged("isSelectedBook");
            }
        }
        public bool isSelectedBook => SelectedBook != null;

        public AppAsyncCommand LoadBooks { get; private set; }
        public AppCommand AddBook { get; private set; }
        public AppCommand UpdateBook { get; private set; }
        public AppAsyncCommand DeleteBook { get; private set; }

        public BookDashboardViewModel()
        {
            // Load data here
            books = new ObservableCollection<BookInfo>();
            _service = new ClientBookService();
            LoadBooks = new AppAsyncCommand(HandleLoadBooks);
            AddBook = new AppCommand(HandleAddBook);
            UpdateBook = new AppCommand(HandleUpdateBook);
            DeleteBook = new AppAsyncCommand(HandleDeleteBook);
        }

        private async Task HandleDeleteBook()
        {
            try
            {
                await _service.DeleteBookAsync(selectedBook.Id, NavigationService.Instance.serviceToken);
                Logger.Info($"Book with title: {selectedBook.Title} removed");
                Books.Remove(selectedBook);
                selectedBook = default;
            }
            catch (Exception e)
            {
                Logger.Error("Removing book error");
            }
        }

        private void HandleUpdateBook()
        {
            NavigationService.Instance.NavigateTo("editBook", selectedBook);
        }

        private void HandleAddBook()
        {
            NavigationService.Instance.NavigateTo("addBook");
        }

        private async Task HandleLoadBooks()
        {
            var books = await _service.GetAllBooksAsync(NavigationService.Instance.serviceToken);
            Books.Clear();
            foreach (var book in books)
            {
                Books.Add(book);
            }
            Logger.Info($"Books loaded");
        }

    }
}
