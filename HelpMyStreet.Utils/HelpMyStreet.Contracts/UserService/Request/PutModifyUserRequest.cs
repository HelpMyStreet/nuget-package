using HelpMyStreet.Contracts.UserService.Response;
using HelpMyStreet.Utils.Models;
using MediatR;

namespace HelpMyStreet.Contracts.UserService.Request
{
    public class PutModifyUserRequest : IRequest<PutModifyUserResponse>
    {
        public User User { get; set; }
    }
}
