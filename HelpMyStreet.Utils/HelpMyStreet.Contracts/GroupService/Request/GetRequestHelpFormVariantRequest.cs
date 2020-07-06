using HelpMyStreet.Contracts.GroupService.Response;
using MediatR;

namespace HelpMyStreet.Contracts.GroupService.Request
{
    public class GetRequestHelpFormVariantRequest : IRequest<GetRequestHelpFormVariantResponse>
    {
        public int? GroupID { get; set; }
        public string Source { get; set; }
    }
}
