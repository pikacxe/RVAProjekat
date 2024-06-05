using RVAProject.AppServices.Helpers;
using RVAProject.Common;
using RVAProject.Common.DTOs.AuthorDTO;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AuthorService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AuthorService.svc or AuthorService.svc.cs at the Solution Explorer and start debugging.
    public class AuthorService : IAuthorService
    {
        private IAuthorRepository _authorRepository;
        public AuthorService()
        {
            _authorRepository = new AuthorRepository(new LibraryDbContext());
        }
        public async Task AddAuthor(AuthorRequest authorRequest, string token)
        {
            if (TokenHelper.ValidateToken(token, out ClaimsPrincipal principal))
            {
                var author = new Author
                {
                    Id = Guid.NewGuid(),
                    FullName = authorRequest.FullName,
                    PenName = authorRequest.PenName,
                    HasNobelPrize = authorRequest.HasNobelPrize,
                    Books = new List<Book>()
                };
                await _authorRepository.AddAuthor(author);
                Logger.Info($" Author added: Fullname:{author.FullName}, Penname: {author.PenName}, Nobel : {author.HasNobelPrize}");
            }
            else
            {
                throw new CustomAppException("Your account does not exist in our base.");
            }
        }

        public async Task DeleteAuthor(Guid id, string token)
        {
            if (TokenHelper.ValidateToken(token, out ClaimsPrincipal principal))
            {
                var author = await _authorRepository.GetAuthorById(id);
                if (author == null)
                {
                    Logger.Error($" Author with id: {id} does not exist");
                    throw new CustomAppException("Author does not exist");
                }
                await _authorRepository.DeleteAuthor(author);
                Logger.Info($" Author with id: {id} is deleted");
            }
            else
            {
                throw new CustomAppException("Your account does not exist in our base.");
            }
        }

        public async Task<IEnumerable<AuthorInfo>> GetAllAuthors(string token)
        {
            if (TokenHelper.ValidateToken(token, out ClaimsPrincipal principal))
            {
                var authors = await _authorRepository.GetAllAuthors();
                Logger.Info("Authors get method are successfully executed");
                return authors.AsAuthorInfoList();
            }
            else
            {
                throw new CustomAppException("Your account does not exist in our base.");
            }
        }

        public async Task<AuthorInfo> GetAuthorById(Guid id, string token)
        {
            if (TokenHelper.ValidateToken(token, out ClaimsPrincipal principal))
            {
                var author = await _authorRepository.GetAuthorById(id);
                if (author == null)
                {
                    Logger.Error($" Author with id: {id} does not exist");
                    throw new CustomAppException("Author does not exist");
                }
                Logger.Info($" Author get method by id with id: {id} are successfully executed");
                return author.AsAuthorInfo();
            }
            else
            {
                throw new CustomAppException("Your account does not exist in our base.");
            }
        }

        public async Task UpdateAuthor(UpdateAuthorRequest updateAuthorRequest, string token)
        {
            if (TokenHelper.ValidateToken(token, out ClaimsPrincipal principal))
            {
                var author = await _authorRepository.GetAuthorById(updateAuthorRequest.Id);
                if (author == null)
                {
                    Logger.Error("Author does not exist");
                    throw new CustomAppException("Author does not exits");
                }
                author.FullName = updateAuthorRequest.FullName;
                author.PenName = updateAuthorRequest.PenName;
                author.HasNobelPrize = updateAuthorRequest.HasNobelPrize;
                await _authorRepository.SaveChangesAuthor();
                Logger.Info($" Author updated: Fullname:{author.FullName}, Penname: {author.PenName}, Nobel : {author.HasNobelPrize}");
            }
            else
            {
                throw new CustomAppException("Your account does not exist in our base.");
            }
        }
    }
}
