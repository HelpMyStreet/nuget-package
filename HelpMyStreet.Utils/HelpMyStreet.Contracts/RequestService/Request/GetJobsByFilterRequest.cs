using HelpMyStreet.Utils.Enums;
using HelpMyStreet.Utils.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using HelpMyStreet.Contracts.RequestService.Response;

namespace HelpMyStreet.Contracts.RequestService.Request
{
    public class GetJobsByFilterRequest : IRequest<GetJobsByFilterResponse>
    { 
        public string Postcode { get; set; }
        public double DistanceInMiles { get; set; }
    }
}
