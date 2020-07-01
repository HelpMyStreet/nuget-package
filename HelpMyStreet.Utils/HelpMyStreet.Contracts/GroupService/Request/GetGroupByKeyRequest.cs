using HelpMyStreet.Contracts.GroupService.Response;
using MediatR;

namespace HelpMyStreet.Contracts.GroupService.Request
{
    public class GetGroupByKeyRequest : IRequest<GetGroupByKeyResponse>
    {
        public string GroupKey { get; set; }
    }

}
