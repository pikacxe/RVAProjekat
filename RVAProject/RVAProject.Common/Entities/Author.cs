using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RVAProject.Common.Entities
{
    public class Author
    {
        public Guid Id { get; set; }
        [Required]
        public string FullName { get; set; }
        public string PenName { get; set; }

        public bool HasNobelPrize { get; set; }
        public List<Book> Books { get; set; }
    }
}
