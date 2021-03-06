﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressiveAssertions.Data;

namespace ExpressiveAssertions.Tooling
{
    /// <summary>
    /// This class can wrap another Assertion Tool and it will
    /// rewrite all success / failure assertions so that a success is reported as an error
    /// and a failure is treated as a success... This is useful
    /// for testing expectations for things not working without
    /// coming up with a the appropriate negative assertion
    /// </summary>
    public class AssertionInverterTool : IAssertionTool
    {
        IAssertionTool _inner;
        public AssertionInverterTool(IAssertionTool inner)
        {
            _inner = inner;
        }

        public void Accept(AssertionDeclaredFailure failure)
        {
            _inner.Accept(failure);
        }

        public void Accept(AssertionDeclaredInconclusive inconclusive)
        {
            _inner.Accept(inconclusive);
        }
        
        public void Accept(AssertionSuccess assertionSuccess)
        {
            var inverted = new AssertionFailure(assertionSuccess);
            _inner.Accept(inverted);
        }

        public void Accept(AssertionFailure failure)
        {
            var inverted = new AssertionSuccess(failure);
            _inner.Accept(inverted);
        }
    }
}
