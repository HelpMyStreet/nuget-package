﻿using HelpMyStreet.Contracts.RequestService.Response;
using HelpMyStreet.Utils.Enums;
using HelpMyStreet.Utils.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.RequestService.Request
{
    public class GetRequestsByFilterRequest : IRequest<GetRequestsByFilterResponse>
    {
        // If supplied, filters to that referring group
        public int? ReferringGroupID { get; set; }

        public bool IncludeChildGroups { get; set; }

        // If supplied, returns requests available to those groups
        public GroupRequest Groups { get; set; }

        public RequestTypeRequest RequestType { get; set; }
    }
}
