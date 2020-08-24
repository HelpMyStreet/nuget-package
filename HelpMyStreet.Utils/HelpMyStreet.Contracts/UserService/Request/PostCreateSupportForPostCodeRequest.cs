using MediatR;

namespace HelpMyStreet.Contracts.UserService.Request
{
    public class PostCreateSupportForPostCodeRequest : IRequest
    {
        public int UserID { get; set; }
        public string PostCode { get; set; }
    }
}
