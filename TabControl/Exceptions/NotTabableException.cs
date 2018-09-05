using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabControl.Exceptions
{

    public class NotTabableException : Exception
    {
        public NotTabableException() : base() { }
        public NotTabableException(string message) : base(message) { }
        public NotTabableException(string message, System.Exception inner) : base(message, inner) { }
    }
}
