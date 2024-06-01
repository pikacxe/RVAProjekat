using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RVAProject.Common.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public Publisher Publisher { get; set; }
        public List<Author> Authors  { get; set; }
    }
}
