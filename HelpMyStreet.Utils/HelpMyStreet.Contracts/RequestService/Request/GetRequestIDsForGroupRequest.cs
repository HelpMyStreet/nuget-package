using HelpMyStreet.Contracts.RequestService.Response;
using MediatR;

namespace HelpMyStreet.Contracts.RequestService.Request
{
    public class GetRequestIDsForGroupRequest : IRequest<GetRequestIDsForGroupResponse>
    {
        public int GroupID { get; set; }
        public bool IncludeChildGroups { get; set; }
    }
}
