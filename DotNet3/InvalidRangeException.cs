using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet3
{
    class InvalidRangeException<T> : System.Exception
    {        
        public InvalidRangeException() : base() { }
        public InvalidRangeException(string message, T start, T end) : base(String.Format("{0}: {1}, {2}", message, start, end)){ }
        public InvalidRangeException(string message) : base(message) { }
        public InvalidRangeException(string message, System.Exception inner) : base(message, inner) { }
        
    }
}
