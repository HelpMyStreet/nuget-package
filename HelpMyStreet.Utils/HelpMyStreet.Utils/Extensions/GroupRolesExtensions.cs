using HelpMyStreet.Utils.Enums;

namespace HelpMyStreet.Utils.Extensions
{
    public static class GroupRolesExtensions
    {
        public static string FriendlyName(this GroupRoles role)
        {
            return role switch
            {
                GroupRoles.UserAdmin => "User Administrator",
                GroupRoles.TaskAdmin => "Request Administrator",
                GroupRoles.RequestSubmitter => "Request Submitter",
                _ => role.ToString()
            };
        }
    }
}
