using System;

namespace HelpMyStreet.Utils.Exceptions
{
    public class InternalServerException : Exception
    {
        public InternalServerException() : base("Internal Server")
        {
        }
    }
}
