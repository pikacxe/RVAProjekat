using RVAProject.Common.Entities;
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
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public List<Book> Books { get; set; }
    }
}
