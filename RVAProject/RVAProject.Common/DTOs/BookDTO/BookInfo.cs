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
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public PublisherInfo Publisher { get; set; }
        [DataMember]
        public List<AuthorInfo> Authors { get; set; }
    }
}
