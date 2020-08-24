using MediatR;

namespace HelpMyStreet.Contracts.UserService.Request
{
    public class PostCreateChampionForPostCodeRequest : IRequest
    {
        public int UserID { get; set; }
        public string PostCode { get; set; }
    }
}
