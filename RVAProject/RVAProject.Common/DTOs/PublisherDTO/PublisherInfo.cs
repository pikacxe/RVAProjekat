using RVAProject.Common.DTOs.BookDTO;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RVAProject.Common.DTOs.PublisherDTO
{
    [DataContract]
    public class PublisherInfo
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public List<BookInfo> Books { get; set; }
    }
}
