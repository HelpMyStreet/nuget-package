using MediatR;

namespace HelpMyStreet.Contracts.GroupService.Request
{
    public class PostCreateGroupRequest :IRequest<PostCreateGroupResponse>
    {
        public string GroupName { get; set; }
    }
}
