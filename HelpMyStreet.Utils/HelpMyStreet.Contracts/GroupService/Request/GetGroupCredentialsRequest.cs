using HelpMyStreet.Contracts.GroupService.Response;
using MediatR;

namespace HelpMyStreet.Contracts.GroupService.Request
{
    public class GetGroupCredentialsRequest : IRequest<GetGroupCredentialsResponse>
    {
        public int GroupID { get; set; }
    }
}
