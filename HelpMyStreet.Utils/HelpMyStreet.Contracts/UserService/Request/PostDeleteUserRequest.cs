using HelpMyStreet.Contracts.UserService.Response;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HelpMyStreet.Contracts.UserService.Request
{
    public class PostDeleteUserRequest : IRequest<PostDeleteUserResponse>
    {
        [Required]
        public int UserID { get; set; }

        [Required]
        public string Postcode { get; set; }
    }
}
