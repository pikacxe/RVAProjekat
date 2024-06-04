using System.Runtime.Serialization;

namespace RVAProject.Common.DTOs.UserDTO
{
    [DataContract]
    public class LogInRequest
    {
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}
