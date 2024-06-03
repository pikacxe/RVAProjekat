using RVAProject.Common.DTOs.BookDTO;
using RVAProject.Common.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RVAProject.Common.DTOs.PublisherDTO
{
    public static class Extensions
    {
        public static PublisherInfo AsPublisherInfo(this Publisher publisher)
        {
            var publisherInfo = new PublisherInfo()
            {
                Id = publisher.Id,
                Name = publisher.Name,
                Email = publisher.Email,
                Address = publisher.Address,
                Books = publisher.Books.AsBookInfoList().ToList()
            };
            return publisherInfo;
        }

        public static IEnumerable<PublisherInfo> AsPublisherInfoList(this IEnumerable<Publisher> publishers)
        {
            var publisherInfoList = new List<PublisherInfo>();
            if (publishers != null)
            {
                foreach (var publisher in publishers)
                {
                    publisherInfoList.Add(publisher.AsPublisherInfo());
                }
            }
            return publisherInfoList;
        }
    }
}
