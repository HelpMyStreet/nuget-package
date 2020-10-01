using HelpMyStreet.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.CommunicationService.Request
{
    public class MessageParticipant
    {
        public int? UserId { get; set; }
        public EmailDetails EmailDetails { get; set; }
        public GroupRoleType GroupRoleType { get; set; }
        public RequestRoleType RequestRoleType { get; set; }
    }
}