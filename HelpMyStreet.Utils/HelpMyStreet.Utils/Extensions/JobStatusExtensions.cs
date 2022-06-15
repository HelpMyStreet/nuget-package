using System;
using HelpMyStreet.Utils.Enums;

namespace HelpMyStreet.Utils.Extensions
{
    public static class JobStatusExtensions
    {
        public static string FriendlyName(this JobStatuses status)
        {
            return status switch
            {
                JobStatuses.New => "Pending Approval",
                JobStatuses.InProgress => "In Progress",
                JobStatuses.AppliedFor => "Applied For",
                _ => status.ToString()
            };
        }

        public static bool Incomplete(this JobStatuses status)
        {
            return status switch
            {
                JobStatuses.New => true,
                JobStatuses.Open => true,
                JobStatuses.Accepted => true,
                JobStatuses.InProgress => true,
                JobStatuses.Done => false,
                JobStatuses.Cancelled => false,
                JobStatuses.AppliedFor => true,
                _ => throw new ArgumentException($"Unexpected JobStatuses value {status}", nameof(status))
            };
        }

        public static bool Complete(this JobStatuses status)
        {
            return !status.Incomplete();
        }
    }
}
