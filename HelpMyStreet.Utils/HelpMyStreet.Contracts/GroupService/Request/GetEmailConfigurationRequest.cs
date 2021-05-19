using HelpMyStreet.Contracts.GroupService.Response;
using HelpMyStreet.Contracts.RequestService.Request;
using HelpMyStreet.Utils.Enums;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HelpMyStreet.Contracts.GroupService.Request
{
    public class GetEmailConfigurationRequest : IRequest<GetEmailConfigurationResponse>
    {
        public int GroupId { get; set; }
        public GroupEmailVariantType GroupEmailVariantType { get; set; }
    }
}