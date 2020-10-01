using HelpMyStreet.Contracts.GroupService.Response;
using HelpMyStreet.Utils.Enums;
using MediatR;

namespace HelpMyStreet.Contracts.GroupService.Request
{
    public class GetGroupMembersForGivenRoleRequest : IRequest<GetGroupMembersForGivenRoleResponse>
    {
        public int GroupId { get; set; }
        public RoleRequest GroupRole { get; set; }
        public int AuthorisingUserID { get; set; }
    }
}
