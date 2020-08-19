using HelpMyStreet.Contracts.UserService.Response;
using MediatR;

namespace HelpMyStreet.Contracts.UserService.Request
{
    public class PutSetVerificationRequest : IRequest<PutSetVerificationResponse>
    {
        public int UserID { get; set; }
        public bool IsVerified { get; set; }
        public string ServiceName { get; set; }
    }
}
