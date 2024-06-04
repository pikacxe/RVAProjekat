using System.Runtime.Serialization;

namespace RVAProject.Common.DTOs.UserDTO
{
    [DataContract]
    public class UserRequest
    {
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public bool isAdmin { get; set; }
    }
}
