using HelpMyStreet.Contracts.CommunicationService.Request;
using HelpMyStreet.Contracts.GroupService.Response;
using HelpMyStreet.Contracts.RequestService.Request;
using HelpMyStreet.Contracts.RequestService.Response;
using HelpMyStreet.Utils.Enums;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HelpMyStreet.Contracts.GroupService.Request
{
    public class GetGroupEmailConfigurationRequest : IRequest<GetGroupEmailConfigurationResponse>
    {
        public int GroupId { get; set; }
        public CommunicationJob CommunicationJob { get; set; }
    }
}