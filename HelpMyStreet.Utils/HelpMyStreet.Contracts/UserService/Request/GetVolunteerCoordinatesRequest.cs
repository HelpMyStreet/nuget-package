using HelpMyStreet.Contracts.UserService.Response;
using HelpMyStreet.Utils.Enums;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HelpMyStreet.Contracts.UserService.Request
{
    public class GetVolunteerCoordinatesRequest : IRequest<GetVolunteerCoordinatesResponse>
    {
        [Required]
        [Range(-90, 90)]
        public double SWLatitude { get; set; }

        [Required]
        [Range(-180, 180)]
        public double SWLongitude { get; set; }

        [Required]
        [Range(-90, 90)]
        public double NELatitude { get; set; }

        [Required]
        [Range(-180, 180)]
        public double NELongitude { get; set; }

        [Required]
        public byte VolunteerType { get; set; }

        // a workaround... https://github.com/Azure/azure-webjobs-sdk-extensions/issues/486 (the suggested workaround there didn't work)
        public VolunteerType VolunteerTypeEnum => (VolunteerType)VolunteerType;

        [Required]
        public byte IsVerifiedType { get; set; }

        public IsVerifiedType IsVerifiedTypeEnum => (IsVerifiedType)IsVerifiedType;

        [Range(0, int.MaxValue)]
        public int MinDistanceBetweenInMetres { get; set; }

    }
}
