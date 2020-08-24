using HelpMyStreet.Contracts.UserService.Response;
using MediatR;

namespace HelpMyStreet.Contracts.UserService.Request
{
    public class GetChampionCountByPostcodeRequest : IRequest<GetChampionCountByPostcodeResponse>
    {
        public string PostCode { get; set; }
    }
}
