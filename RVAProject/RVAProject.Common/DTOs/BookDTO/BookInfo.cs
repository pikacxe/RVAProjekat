using RVAProject.Common.DTOs.AuthorDTO;
using RVAProject.Common.DTOs.PublisherDTO;
using RVAProject.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RVAProject.Common.DTOs.BookDTO
{
    [DataContract]
    public class BookInfo
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public PublisherInfo Publisher { get; set; }

        public List<AuthorInfo> Authors { get; set; }
    }
}
