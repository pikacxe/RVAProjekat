using RVAProject.Common;
using RVAProject.Common.DTOs.BookDTO;
using RVAProject.Common.Entities;
using RVAProject.Common.Repositories;
using RVAProject.Common.Repositories.Impl;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationException = RVAProject.Common.ApplicationException;

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

        public async Task CreateBookAsync(CreateBookRequest createBookRequest)
        {
            if (createBookRequest == null)
            {
                throw new ApplicationException("Book creation failed. Invalid data.");
            }
            try
            {
                // TODO Find publisher and artists and add them to new book
                Book newBook = new Book()
                {
                    Id = Guid.NewGuid(),
                    Title = createBookRequest.Title,
                    Description = createBookRequest.Description,
                };
                await _bookRepository.AddBook(newBook);
            }
            catch (Exception ex)
            {
                // TODO log exception
                throw new ApplicationException("Server error");
            }
        }

        public async Task DeleteBookAsync(Guid id)
        {
            var existingBook = await _bookRepository.GetBookById(id);
            if(existingBook == default(Book))
            {
                throw new ApplicationException("Book not found");
            }
            await _bookRepository.DeleteBook(existingBook);
        }

        public async Task<IEnumerable<BookInfo>> GetAllAsync()
        {
            var books = await _bookRepository.GetAllBooks();
            return books.AsBookInfoList();
        }

        public async Task<BookInfo> GetBookByIdAsync(Guid id)
        {
            var existingBook = await _bookRepository.GetBookById(id);
            if (existingBook == default(Book))
            {
                throw new ApplicationException("Book not found");
            }
            return existingBook.AsBookInfo();
        }

        public async Task<BookInfo> GetBookByPartialNameAsync(string partialName)
        {
            var existingBook = await _bookRepository.GetBook(b => b.Title.Contains(partialName));
            if (existingBook == default(Book))
            {
                throw new ApplicationException("Book not found");
            }
            return existingBook.AsBookInfo();
        }

        public async Task UpdateBookAsync(UpdateBookRequest updateBookRequest)
        {
            var existingBook = await _bookRepository.GetBookById(updateBookRequest.Id);
            if (existingBook == default(Book))
            {
                throw new ApplicationException("Book not found");
            }
            existingBook.Title = updateBookRequest.Title;
            existingBook.Description = updateBookRequest.Description;
            // TODO update Publisher and artists
            await _bookRepository.SaveChangesBook();
        }
    }
}
