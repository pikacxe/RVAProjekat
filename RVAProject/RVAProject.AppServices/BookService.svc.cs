using RVAProject.Common;
using RVAProject.Common.Entities;
using RVAProject.Common.Repositories;
using RVAProject.Common.Repositories.Impl;
using System;
using System.Threading.Tasks;

namespace RVAProject.AppServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BookService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BookService.svc or BookService.svc.cs at the Solution Explorer and start debugging.
    public class BookService : IBookService
    {
        private IBookRepository _bookRepository;
        public BookService()
        {
            _bookRepository = new BookRepository(new LibraryDbContext());
        }
        public async Task DoWorkAsync()
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = "Knjiga",
            };

            await _bookRepository.AddBook(book);
        }
    }
}
