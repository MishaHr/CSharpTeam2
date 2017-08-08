using System;
using System.Runtime.Serialization;

namespace ProductDatabase.BL.CustomExceptions
{
    public class CustomeException : ApplicationException
    {
        public CustomeException() { }

        public CustomeException(string message) : base(message) { }

        public CustomeException(string message, ApplicationException innerException) :
            base(message, innerException)
        { }

        protected CustomeException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
