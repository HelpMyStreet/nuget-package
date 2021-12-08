using HelpMyStreet.Utils.Enums;
using System;

namespace HelpMyStreet.Utils.Extensions
{
    public static class RequestTypeExtensions
    {
        public static string PerfectTense(this RequestType requestType, int count)
        {
            if (count <= 1)
            {
                return requestType switch
                {
                    RequestType.Task => "task",
                    RequestType.Shift => "shift",
                    _ => throw new ArgumentException(message: $"Unexpected RequestType: {requestType}")
                };
            }
            else
            {
                return requestType switch
                {
                    RequestType.Task => "tasks",
                    RequestType.Shift => "shifts",
                    _ => throw new ArgumentException(message: $"Unexpected RequestType: {requestType}")
                };
            }
        }
    }
}
