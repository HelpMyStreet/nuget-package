using HelpMyStreet.Contracts.GroupService.Response;
using MediatR;

namespace HelpMyStreet.Contracts.GroupService.Request
{

    public class GetGroupSupportActivityInstructionsRequest : IRequest<GetGroupSupportActivityInstructionsResponse>
    {
        public int GroupId { get; set; }
        public SupportActivityType SupportActivityType { get; set; }
    }
}
