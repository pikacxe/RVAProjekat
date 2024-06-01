using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVAProject.Common
{
    public class ApplicationException : Exception
    {
        private string _message;
        public override string Message { get => _message; }

        public ApplicationException(string message) => _message = message;
    }
}
