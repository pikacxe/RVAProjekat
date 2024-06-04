using RVAProject.Common.Entities;
using System.Collections.Generic;

namespace RVAProject.Common.DTOs.BookDTO
{
    public static class Extensions
    {
        public static BookInfo AsBookInfo(this Book book)
        {
            BookInfo info = new BookInfo()
            {
                Title = book.Title,
                Description = book.Description,
                Id = book.Id
            };
            return info;
        }

        public static IEnumerable<BookInfo> AsBookInfoList(this IEnumerable<Book> books)
        {
            var bookInfoList = new List<BookInfo>();
            if (books != null)
            {
                foreach (var book in books)
                {
                    bookInfoList.Add(book.AsBookInfo());
                }
            }
            return bookInfoList;
        }
    }
}
