using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RVAProject.Common.DTOs.BookDTO
{
    [DataContract]
    public class UpdateBookRequest
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public Guid PublisherId { get; set; }
        [DataMember]
        public IEnumerable<Guid> AuthorIds { get; set; }
    }
}
