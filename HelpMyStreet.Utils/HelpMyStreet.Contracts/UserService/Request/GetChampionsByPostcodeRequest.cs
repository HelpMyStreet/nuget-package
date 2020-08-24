using HelpMyStreet.Contracts.UserService.Response;
using MediatR;

namespace HelpMyStreet.Contracts.UserService.Request
{
    public class GetChampionsByPostcodeRequest : IRequest<GetChampionsByPostcodeResponse>
    {
        public string PostCode { get; set; }
    }
}
