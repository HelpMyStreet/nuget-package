using HelpMyStreet.Contracts.RequestService.Response;
using HelpMyStreet.Utils.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.RequestService.Request
{
    public class PostAllocateJobRequest : IRequest<PostAllocateJobResponse>
    {
        public int JobID { get; set; }
        public int UserID { get; set; }
    }
}
