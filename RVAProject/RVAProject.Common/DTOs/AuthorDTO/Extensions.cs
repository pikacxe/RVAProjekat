using RVAProject.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVAProject.Common.DTOs.AuthorDTO
{
    public static class Extensions
    {
        public static AuthorInfo AsAuthorInfo(this Author author)
        {
            AuthorInfo authorInfo = new AuthorInfo()
            {
                FullName = author.FullName,
                HasNobelPrize = author.HasNobelPrize,
                Id = author.Id,
                PenName = author.PenName
            };
            return authorInfo;
        }

        public static IEnumerable<AuthorInfo> AsAuthorInfoList(this IEnumerable<Author> authorList)
        {
            var authorInfoList = new List<AuthorInfo>();
            foreach (var author in authorList)
            {
                authorInfoList.Add(author.AsAuthorInfo());
            }
            return authorInfoList;
        }
    }
}
