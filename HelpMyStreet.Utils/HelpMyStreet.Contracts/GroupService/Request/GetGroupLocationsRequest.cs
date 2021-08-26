using HelpMyStreet.Contracts.GroupService.Response;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HelpMyStreet.Contracts.GroupService.Request
{
    public class GetGroupLocationsRequest : IRequest<GetGroupLocationsResponse>
    {
        [Required]
        public int? GroupID { get; set; }

        public bool IncludeChildGroups { get; set; }
    }

}
