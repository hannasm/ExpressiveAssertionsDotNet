using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ExpressiveAssertions.Exceptions
{
    public class EvaluatedExpressionException : Exception
    {
      Expression _exp;
        public EvaluatedExpressionException(Expression exp, Exception innerException) 
            : base("default message should be overidden", innerException)
        {
          _exp = exp;
        }

        protected EvaluatedExpressionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        StringBuilder _sb = null;
        public override string Message { get {
          if (_sb == null) {
            _sb = new StringBuilder();
            _sb.Append("Evaluation of expression '");
            _sb.Append(ExpressionToCodeLib.ExpressionToCode.ToCode(_exp));
            _sb.Append("' failed with unhandled exception");
          }
          return _sb.ToString();
        } }
    }
}
