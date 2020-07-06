using HelpMyStreet.Contracts.GroupService.Response;
using MediatR;

namespace HelpMyStreet.Contracts.GroupService.Request
{
    public class GetRegistrationFormVariantRequest : IRequest<GetRegistrationFormVariantResponse>
    {
        public int? GroupID { get; set; }
        public string Source { get; set; }
    }
}
