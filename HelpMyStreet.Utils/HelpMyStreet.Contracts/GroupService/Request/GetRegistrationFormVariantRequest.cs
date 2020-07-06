using HelpMyStreet.Contracts.GroupService.Response;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HelpMyStreet.Contracts.GroupService.Request
{
    public class GetRegistrationFormVariantRequest : IRequest<GetRegistrationFormVariantResponse>
    {
        [Required]
        public int? GroupID { get; set; }
        [Required]
        public string Source { get; set; }
    }
}
