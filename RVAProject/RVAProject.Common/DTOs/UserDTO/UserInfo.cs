using System.Runtime.Serialization;

namespace RVAProject.Common.DTOs.UserDTO
{
    [DataContract]
    public class UserInfo
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
    }
}
