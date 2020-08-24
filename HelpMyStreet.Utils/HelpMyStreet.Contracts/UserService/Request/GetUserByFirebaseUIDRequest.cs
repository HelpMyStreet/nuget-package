using HelpMyStreet.Contracts.UserService.Response;
using MediatR;

namespace HelpMyStreet.Contracts.UserService.Request
{
    public class GetUserByFirebaseUIDRequest : IRequest<GetUserByFirebaseUIDResponse>
    {
        public string FirebaseUID { get; set; }
    }
}
