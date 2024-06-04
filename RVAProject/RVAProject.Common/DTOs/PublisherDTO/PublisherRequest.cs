using System.Runtime.Serialization;

namespace RVAProject.Common.DTOs.PublisherDTO
{
    [DataContract]
    public class PublisherRequest
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Address { get; set; }
    }
}
