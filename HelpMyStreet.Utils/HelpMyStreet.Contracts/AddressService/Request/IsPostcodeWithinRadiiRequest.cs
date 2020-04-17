using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace HelpMyStreet.Contracts.AddressService.Request
{
    public class IsPostcodeWithinRadiiRequest : IRequest<IsPostcodeWithinRadiiResponse>
    {
        [Required]
        public string Postcode { get; set; }

        [Required]
        public List<PostcodeWithRadius> PostcodeWithRadiuses { get; set; }

    }
}
