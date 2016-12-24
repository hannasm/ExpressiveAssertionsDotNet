using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveAssertions.Exceptions
{
    public class IncompleteAssertionException : Exception
    {
        public IncompleteAssertionException(Exception innerException) 
            : base("The assertion was unable to complete due to an error", innerException)
        {
        }

        protected IncompleteAssertionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
