using System;

namespace zk4500.Exceptions
{
    public class CreatingDuplicateException : Exception
    {
        public CreatingDuplicateException(string message = null) : base(message: message)
        {
        }
    }
}
