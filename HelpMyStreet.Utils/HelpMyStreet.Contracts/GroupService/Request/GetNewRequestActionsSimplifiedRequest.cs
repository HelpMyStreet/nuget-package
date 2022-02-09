using HelpMyStreet.Contracts.GroupService.Response;
using HelpMyStreet.Contracts.RequestService.Request;
using MediatR;

namespace HelpMyStreet.Contracts.GroupService.Request
{
    public class GetNewRequestActionsSimplifiedRequest : IRequest<GetNewRequestActionsSimplifiedResponse>
    {
        public int GroupId { get; set; }
        public string Source { get; set; }
        public SupportActivityRequest SupportActivity { get; set; }
    }
}
