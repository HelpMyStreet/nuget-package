using HelpMyStreet.Contracts.GroupService.Response;
using MediatR;

namespace HelpMyStreet.Contracts.GroupService.Request
{
    public class GetGroupMembersForGivenRoleRequest : IRequest<GetGroupMembersForGivenRoleResponse>
    {
        public int GroupId { get; set; }
        public int UserId { get; set; }
        public int AuthorisingUserID { get; set; }
    }
}
