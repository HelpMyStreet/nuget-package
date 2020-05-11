﻿using HelpMyStreet.Contracts.RequestService.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.RequestService.Request
{
    public class PutUpdateJobStatusToOpenRequest : IRequest<PutUpdateJobStatusToOpenResponse>
    {
        public int JobID { get; set; }
        public int UserID { get; set; }
    }
}
