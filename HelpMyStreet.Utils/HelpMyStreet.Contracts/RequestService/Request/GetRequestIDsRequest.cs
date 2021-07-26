using HelpMyStreet.Contracts.RequestService.Response;
using HelpMyStreet.Utils.Enums;
using HelpMyStreet.Utils.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.RequestService.Request
{
    public class GetRequestIDsRequest : IRequest<GetRequestIDsResponse>
    {
        public List<int> JobIDs { get; set; }
    }
}
