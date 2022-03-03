using HelpMyStreet.Contracts.UserService.Response;
using HelpMyStreet.Utils.Models;
using MediatR;

namespace HelpMyStreet.Contracts.UserService.Request
{
    public class PostAddBiographyRequest : IRequest<PostAddBiographyResponse>
    {
        public int UserId { get; set; }
        public string Details { get; set; }
    }
}
