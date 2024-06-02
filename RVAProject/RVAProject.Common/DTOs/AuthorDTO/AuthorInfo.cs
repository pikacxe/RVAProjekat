using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVAProject.Common.DTOs.AuthorDTO
{
    public class AuthorInfo
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string PenName { get; set; }
        public bool HasNobelPrize { get; set; }
    }
}
