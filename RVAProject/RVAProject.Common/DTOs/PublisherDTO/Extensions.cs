using System;
using System.Collections.Generic;
using System.Linq;
using RVAProject.Common.Entities;
using System.Text;
using System.Threading.Tasks;

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
            };
            return publisherInfo;
        }
    }
}
