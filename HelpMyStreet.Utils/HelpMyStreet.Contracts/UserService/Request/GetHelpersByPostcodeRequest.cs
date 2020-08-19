using HelpMyStreet.Contracts.UserService.Response;
using MediatR;

namespace HelpMyStreet.Contracts.UserService.Request
{
    public class GetHelpersByPostcodeRequest : IRequest<GetHelpersByPostcodeResponse>
    {
        public string Postcode { get; set; }
    }
}
