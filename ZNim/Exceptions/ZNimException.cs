using System;

namespace ZNim.Core
{
    public abstract class ZNimException : Exception
    {
        public ZNimException(string message) : base(message) { }
    }
}
