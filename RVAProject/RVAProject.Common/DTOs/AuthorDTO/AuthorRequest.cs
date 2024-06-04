using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RVAProject.Common.DTOs.AuthorDTO
{
    public class AuthorRequest
    {
        [DataMember]
        public string FullName { get; set; }
        [DataMember]
        public string PenName { get; set; }
        [DataMember]
        public bool HasNobelPrize { get; set; }
    }
}
