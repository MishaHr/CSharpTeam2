using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
