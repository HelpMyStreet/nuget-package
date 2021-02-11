using HelpMyStreet.Contracts.GroupService.Response;
using HelpMyStreet.Contracts.RequestService.Request;
using HelpMyStreet.Utils.Enums;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HelpMyStreet.Contracts.GroupService.Request
{
    public class GetSupportActivityConfigurationRequest : IRequest<GetSupportActivityConfigurationResponse>
    {
        [Required]
        public SupportActivityType SupportActivityType { get; set; }
    }
}