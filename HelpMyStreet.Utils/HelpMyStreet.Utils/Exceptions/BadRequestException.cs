using System;

namespace HelpMyStreet.Utils.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException() : base("Bad Request")
        {
        }
    }
}
