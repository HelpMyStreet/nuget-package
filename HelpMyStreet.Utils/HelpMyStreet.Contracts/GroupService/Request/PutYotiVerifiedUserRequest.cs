using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.GroupService.Request
{
    public class PutYotiVerifiedUserRequest : IRequest<bool>
    {
		public int UserId { get; set; }
		public string Reference { get; set; }
		public string Notes { get; set; }
	}
}
