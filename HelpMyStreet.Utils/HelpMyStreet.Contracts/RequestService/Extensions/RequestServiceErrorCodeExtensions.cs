using HelpMyStreet.Contracts.RequestService.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.RequestService.Extensions
{
    public static class RequestServiceErrorCodeExtensions
    {
        public static bool Retry(this RequestServiceErrorCode errorCode)
        {
            switch(errorCode)
            {
                case RequestServiceErrorCode.ValidationError:
                    return false;
                case RequestServiceErrorCode.InternalServerError:
                    return true;
                default:
                    throw new ArgumentException($"Unexpected RequestServiceErrorCode value {errorCode}", nameof(errorCode));

            }
        }
    }
}
