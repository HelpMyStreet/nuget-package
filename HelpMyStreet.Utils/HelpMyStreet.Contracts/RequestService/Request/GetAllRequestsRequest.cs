using HelpMyStreet.Contracts.RequestService.Response;
using HelpMyStreet.Utils.Enums;
using HelpMyStreet.Utils.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.RequestService.Request
{
    public class GetAllRequestsRequest : IRequest<GetAllRequestsResponse>
    {
        public List<int> RequestIDs { get; set; }
    }
}
