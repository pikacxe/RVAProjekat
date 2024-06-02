namespace RVAProject.Common.DTOs.UserDTO
{
    public class UserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool isAdmin { get; set; }
    }
}
