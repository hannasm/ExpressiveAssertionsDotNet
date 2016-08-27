using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions.Exceptions
{
    public class DataMismatchException : Exception
    {
        public DataMismatchException()
        {
        }

        public DataMismatchException(string message) : base(message)
        {
        }

        public DataMismatchException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DataMismatchException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
