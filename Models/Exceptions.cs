using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPtask.Models
{
    public class Exceptions : Exception
    {
        public Exceptions()
        {

        }

        public Exceptions(string message) : base(message)
        {

        }

        public Exceptions(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
