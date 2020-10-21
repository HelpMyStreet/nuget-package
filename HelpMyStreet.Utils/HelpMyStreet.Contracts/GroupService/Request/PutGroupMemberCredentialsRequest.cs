using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.GroupService.Request
{
    public class PutGroupMemberCredentialsRequest : IRequest<bool>
    {
		public int GroupId { get; set; }
		public int UserId { get; set; }
		public int CredentialId { get; set; }
		public DateTime? ValidUntil { get; set; }
		public int AuthorisedByUserID { get; set; }
		public string Reference { get; set; }
		public string Notes { get; set; }
	}
}
