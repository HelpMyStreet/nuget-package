using HelpMyStreet.Contracts.UserService.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.UserService.Request
{
    public class GetVolunteerCountByPostcodeRequest : IRequest<GetVolunteerCountByPostcodeResponse>
    {
        public string PostCode { get; set; }
    }
}
