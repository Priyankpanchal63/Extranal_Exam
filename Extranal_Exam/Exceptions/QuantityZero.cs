using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Extranal_Exam.Exceptions
{
    public class QuantityZero : Exception
    {
        public QuantityZero() : base("Food Quantity less than 0 or more than 10") { }
    }
}