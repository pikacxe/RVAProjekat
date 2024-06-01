using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RVAProject.Common.Entities
{
    public class Publisher
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string Address { get; set; }
        public List<Book> Books { get; set; }
    }
}
