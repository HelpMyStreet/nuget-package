using HelpMyStreet.Contracts.GroupService.Response;
using MediatR;

namespace HelpMyStreet.Contracts.GroupService.Request
{
    public class GetGroupMemberRequest : IRequest<GetGroupMemberResponse>
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public int AuthorisingUserId { get; set; }
    }
}
