using System;

namespace RVAProject.Common
{
    [Serializable]
    public class CustomAppException : Exception
    {
        private string _message;
        public override string Message { get => _message; }

        public CustomAppException(string message) => _message = message;
    }
}
