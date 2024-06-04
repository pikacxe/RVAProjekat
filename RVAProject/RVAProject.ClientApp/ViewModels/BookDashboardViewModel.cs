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

        public AppAsyncCommand<IEnumerable<BookInfo>> LoadBooks { get; private set; }
        public AppAsyncCommand AddBook { get; private set; }
        public AppAsyncCommand UpdateBook { get; private set; }
        public AppAsyncCommand DeleteBook { get; private set; }

        public BookDashboardViewModel()
        {
            // Load data here
            books = new ObservableCollection<BookInfo>();
            _service = new ClientBookService();
            LoadBooks = new AppAsyncCommand<IEnumerable<BookInfo>>(HandleLoadBooks);
            AddBook = new AppAsyncCommand(HandleAddBook);
            UpdateBook = new AppAsyncCommand(HandleUpdateBook);
            DeleteBook = new AppAsyncCommand(HandleDeleteBook);
        }

        private async Task HandleDeleteBook()
        {
            throw new NotImplementedException();
        }

        private async Task HandleUpdateBook()
        {
            throw new NotImplementedException();
        }

        private async Task HandleAddBook()
        {
            throw new NotImplementedException();
        }

        private async Task HandleLoadBooks(IEnumerable<BookInfo> enumerable)
        {
            var books = await _service.GetAllBooksAsync();
            Books.Clear();
            foreach (var book in books)
            {
                Books.Add(book);
            }
        }

    }
}
