using MediatR;

namespace HelpMyStreet.Contracts.GroupService.Request
{
    public class PostAddMembersToGroupRequest : IRequest<PostAddMembersToGroupResponse>
    {
        public int GroupID { get; set; }
        public int UserID { get; set; }
    }
}
