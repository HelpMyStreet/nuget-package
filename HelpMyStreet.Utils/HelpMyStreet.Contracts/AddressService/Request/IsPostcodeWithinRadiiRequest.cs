using HelpMyStreet.Contracts.AddressService.Response;
using MediatR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HelpMyStreet.Contracts.AddressService.Request
{
    public class IsPostcodeWithinRadiiRequest : IRequest<IsPostcodeWithinRadiiResponse>
    {
        [Required]
        public string Postcode { get; set; }

        [Required]
        public IEnumerable<PostcodeWithRadius> PostcodeWithRadiuses { get; set; }

    }
}
