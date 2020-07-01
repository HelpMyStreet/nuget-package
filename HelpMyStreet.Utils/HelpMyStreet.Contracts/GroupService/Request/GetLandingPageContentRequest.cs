using HelpMyStreet.Contracts.GroupService.Response;
using MediatR;
namespace HelpMyStreet.Contracts.GroupService.Request
{
    public class GetLandingPageContentRequest : IRequest<GetLandingPageContentResponse>
    {
        public int GroupID { get; set; }
    }
}
