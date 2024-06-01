using System;
using System.ComponentModel.DataAnnotations;

namespace RVAProject.Common.Entities
{
    public class User
    {
        public Guid Id {  get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool isAdmin { get; set; }
    }
}
