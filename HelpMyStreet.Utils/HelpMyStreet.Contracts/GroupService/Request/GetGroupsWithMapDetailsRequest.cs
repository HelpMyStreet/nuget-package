using HelpMyStreet.Contracts.GroupService.Response;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HelpMyStreet.Contracts.GroupService.Request
{
    public class GetGroupsWithMapDetailsRequest : IRequest<GetGroupsWithMapDetailsResponse>
    {
        [Required]
        public MapLocationRequest MapLocation { get; set; }
    }

}
