﻿using System;
using System.Collections.Generic;
using System.Text;
using HelpMyStreet.Utils.Models;

namespace HelpMyStreet.Contracts.RequestService.Response
{
    public class GetJobsByStatusesResponse
    {
        public List<JobSummary> JobSummaries { get; set; }
    }
}
