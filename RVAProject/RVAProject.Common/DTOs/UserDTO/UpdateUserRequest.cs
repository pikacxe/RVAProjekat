using System;
using System.Runtime.Serialization;

namespace RVAProject.Common.DTOs.UserDTO
{
    [DataContract]
    public class UpdateUserRequest
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
    }
}
