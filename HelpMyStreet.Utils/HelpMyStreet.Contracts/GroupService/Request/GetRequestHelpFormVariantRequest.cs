using HelpMyStreet.Contracts.GroupService.Response;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HelpMyStreet.Contracts.GroupService.Request
{
    public class GetRequestHelpFormVariantRequest : IRequest<GetRequestHelpFormVariantResponse>
    {
        [Required]
        public int? GroupID { get; set; }

        [Required]
        public string Source { get; set; }
    }
}
