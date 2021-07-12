using HelpMyStreet.Contracts.AddressService.Response;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HelpMyStreet.Contracts.AddressService.Request
{
    public class GetLocationBetweenPostcodesRequest
    {
        public string Postcode1  { get; set; }
        public string Postcode2 { get; set; }
    }
}
