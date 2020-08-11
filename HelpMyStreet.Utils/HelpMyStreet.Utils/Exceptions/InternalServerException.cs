using System;

namespace HelpMyStreet.Utils.Exceptions
{
    public class InternalServerException : Exception
    {
        public InternalServerException()
        {
        }

        public InternalServerException(string message)
            : base(message)
        {
        }
    }
}
