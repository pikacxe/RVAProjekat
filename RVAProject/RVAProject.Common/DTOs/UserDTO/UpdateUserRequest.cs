using System;

namespace RVAProject.Common.DTOs.UserDTO
{
    public class UpdateUserRequest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
