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
                _ => status.ToString()
            };
        }
    }
}
