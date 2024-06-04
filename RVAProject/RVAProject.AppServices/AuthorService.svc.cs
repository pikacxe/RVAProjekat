using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using RVAProject.Common.DTOs.PublisherDTO;

using RVAProject.Common;
using RVAProject.Common.DTOs.AuthorDTO;
using RVAProject.Common.Entities;
using System.Data.Entity.Core.Metadata.Edm;
using RVAProject.Common.Repositories.Impl;
using RVAProject.Common.Repositories;
using System.Threading;

namespace RVAProject.AppServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AuthorService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AuthorService.svc or AuthorService.svc.cs at the Solution Explorer and start debugging.
    public class AuthorService : IAuthorService
    {
        private IAuthorRepository _authorRepository;
        public AuthorService()
        {
            _authorRepository= new AuthorRepository(new LibraryDbContext());
        }
        public async Task AddAuthor(AuthorRequest authorRequest)
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
        }

        public async Task DeleteAuthor(Guid id)
        {
            var author = await _authorRepository.GetAuthorById(id);
            await _authorRepository.DeleteAuthor(author);
        }

        public async Task<IEnumerable<AuthorInfo>> GetAllAuthors()
        {
            var authors = await _authorRepository.GetAllAuthors();
            return authors.AsAuthorInfoList();
        }

        public async Task<AuthorInfo> GetAuthorById(Guid id)
        {
            var author = await _authorRepository.GetAuthorById(id);
            if(author == null)
            {
                throw new CustomAppException("Author does not exist");
            }
            return author.AsAuthorInfo();
        }

        public async Task UpdateAuthor(UpdateAuthorRequest updateAuthorRequest)
        {
            var author = await _authorRepository.GetAuthorById(updateAuthorRequest.Id);
            if (author == null)
            {
                throw new CustomAppException("Author does not exits");
            }
            author.FullName = updateAuthorRequest.FullName;
            author.PenName= updateAuthorRequest.PenName;
            author.HasNobelPrize=updateAuthorRequest.HasNobelPrize;
            await _authorRepository.SaveChangesAuthor(); 
        }
    }
}
