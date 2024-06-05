
using RVAProject.AppServices.Helpers;
using RVAProject.Common;
using RVAProject.Common.DTOs.BookDTO;
using RVAProject.Common.Entities;
using RVAProject.Common.Helpers;
using RVAProject.Common.Repositories;
using RVAProject.Common.Repositories.Impl;
using System;
using System.Collections.Generic;
using System.Security.Claims;
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

        public async Task CreateBookAsync(CreateBookRequest createBookRequest, string token)
        {
            if (TokenHelper.ValidateToken(token, out ClaimsPrincipal principal))
            {
                if (createBookRequest == null)
                {
                    Logger.Error(" Book creation failed. Invalid data.");
                    throw new CustomAppException("Book creation failed. Invalid data.");
                }

                try
                {
                    // TODO Find publisher and artists and add them to new book
                    Book newBook = new Book()
                    {
                        Id = Guid.NewGuid(),
                        Title = createBookRequest.Title,
                        Description = createBookRequest.Description
                    };
                    await _bookRepository.AddBook(newBook);
                    Logger.Info($" Book added: Title:{newBook.Title}, Description: {newBook.Description}");
                }
                catch (Exception ex)
                {
                    // TODO log exception
                    throw new CustomAppException("Server error");
                }
            }
            else
            {
                throw new CustomAppException("Your account does not exist in our base.");
            }
        }

        public async Task DeleteBookAsync(Guid id, string token)
        {
            if (TokenHelper.ValidateToken(token, out ClaimsPrincipal principal))
            {
                var existingBook = await _bookRepository.GetBookById(id);
                if (existingBook == default(Book))
                {
                    Logger.Error($" Book with id: {id} does not exist");
                    throw new CustomAppException("Book not found");
                }
                await _bookRepository.DeleteBook(existingBook);
            }
            else
            {
                throw new CustomAppException("Your account does not exist in our base.");
            }
        }

        public async Task<IEnumerable<BookInfo>> GetAllAsync(string token)
        {
            if (TokenHelper.ValidateToken(token, out ClaimsPrincipal principal))
            {
                var books = await _bookRepository.GetAllBooks();
                Logger.Info("Books get method are successfully executed");
                return books.AsBookInfoList();
            }
            else
            {
                throw new CustomAppException("Your account does not exist in our base.");
            }
        }

        public async Task<BookInfo> GetBookByIdAsync(Guid id, string token)
        {
            if (TokenHelper.ValidateToken(token, out ClaimsPrincipal principal))
            {
                var existingBook = await _bookRepository.GetBookById(id);
                if (existingBook == default(Book))
                {
                    Logger.Error($" Book with id: {id} does not exist");
                    throw new CustomAppException("Book not found");
                }
                Logger.Info($" Book get method by id with id: {id} are successfully executed");
                return existingBook.AsBookInfo();
            }
            else
            {
                throw new CustomAppException("Your account does not exist in our base.");
            }
        }

        public async Task<BookInfo> GetBookByPartialNameAsync(string partialName, string token)
        {
            if (TokenHelper.ValidateToken(token, out ClaimsPrincipal principal))
            {
                var existingBook = await _bookRepository.GetBook(b => b.Title.Contains(partialName));
                if (existingBook == default(Book))
                {
                    Logger.Error($" Book with partialName: {partialName} does not exist");
                    throw new CustomAppException("Book not found");
                }
                Logger.Info($" Book get method by partial name with partial name: {partialName} are successfully executed");
                return existingBook.AsBookInfo();
            }
            else
            {
                throw new CustomAppException("Your account does not exist in our base.");
            }
        }

        public async Task UpdateBookAsync(UpdateBookRequest updateBookRequest, string token)
        {
            if (TokenHelper.ValidateToken(token, out ClaimsPrincipal principal))
            {
                var existingBook = await _bookRepository.GetBookById(updateBookRequest.Id);
                if (existingBook == default(Book))
                {
                    Logger.Error("Book does not exist");
                    throw new CustomAppException("Book not found");
                }
                existingBook.Title = updateBookRequest.Title;
                existingBook.Description = updateBookRequest.Description;
                // TODO update Publisher and artists
                await _bookRepository.SaveChangesBook();
                Logger.Info($" Book updated: Title:{existingBook.Title}, Description: {existingBook.Description}");
            }
            else
            {
                throw new CustomAppException("Your account does not exist in our base.");
            }
        }
    }
}
