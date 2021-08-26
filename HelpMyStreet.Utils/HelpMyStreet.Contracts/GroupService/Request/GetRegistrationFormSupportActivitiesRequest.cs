using HelpMyStreet.Contracts.GroupService.Response;
using HelpMyStreet.Utils.Enums;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HelpMyStreet.Contracts.GroupService.Request
{
    public class RegistrationFormVariantRequest
    {
        public RegistrationFormVariant RegistrationFormVariant { get; set; }
    }
    public class GetRegistrationFormSupportActivitiesRequest : IRequest<GetRegistrationFormSupportActivitiesResponse>
    {
        [Required]
        public RegistrationFormVariantRequest RegistrationFormVariantRequest { get; set; }
    }

}
