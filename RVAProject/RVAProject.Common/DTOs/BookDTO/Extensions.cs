using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RVAProject.Common.Entities;

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
            foreach (var book in books)
            {
                bookInfoList.Add(book.AsBookInfo());
            }
            return bookInfoList;
        }
    }
}
