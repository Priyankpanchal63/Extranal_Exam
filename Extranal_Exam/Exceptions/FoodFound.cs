using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Extranal_Exam.Exceptions
{
    public class FoodFound : Exception
    {
        public FoodFound() : base ("Food Already Exsits Appending 1 at the End") {}
    }
}