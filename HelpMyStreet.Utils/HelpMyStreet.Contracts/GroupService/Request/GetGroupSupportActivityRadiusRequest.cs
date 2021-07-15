using HelpMyStreet.Contracts.GroupService.Response;
using MediatR;

namespace HelpMyStreet.Contracts.GroupService.Request
{

    public class GetGroupSupportActivityRadiusRequest : IRequest<GetGroupSupportActivityRadiusResponse>
    {
        public int GroupId { get; set; }
        public SupportActivityType SupportActivityType { get; set; }
    }
}
