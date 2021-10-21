using HelpMyStreet.Utils.Enums;
using MediatR;

namespace HelpMyStreet.Contracts.GroupService.Response
{
    public class PostRevokeAllRolesResponse
    {
        public GroupPermissionOutcome Outcome { get; set; }
    }
}
