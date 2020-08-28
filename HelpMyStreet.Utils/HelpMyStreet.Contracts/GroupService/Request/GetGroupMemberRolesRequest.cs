using HelpMyStreet.Contracts.GroupService.Response;
using MediatR;

namespace HelpMyStreet.Contracts.GroupService.Request
{
    public class GetGroupMemberRolesRequest : IRequest<GetGroupMemberRolesResponse>
    {
        public int GroupId { get; set; }
        public int UserId { get; set; }
    }
}
