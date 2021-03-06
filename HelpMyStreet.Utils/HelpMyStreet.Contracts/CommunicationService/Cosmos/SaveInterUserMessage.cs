﻿using HelpMyStreet.Contracts.CommunicationService.Request;
using HelpMyStreet.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace HelpMyStreet.Contracts.CommunicationService.Cosmos
{
    public class SaveInterUserMessage
    {
        public Guid ThreadId { get; set; }
        public List<int> SenderUserIds { get; set; }
        public string SenderFirstName { get; set; }
        public RequestRoles SenderRequestRoles { get; set; }
        public int? JobId { get; set; }
        public string Content { get; set; }
        public EmailDetails EmailDetails { get; set; }
        public List<int> RecipientUserIds { get; set; }
        public Guid id { get; set; }
        public DateTime MessageDate { get; set; }
        public RequestRoles RecipientRequestRoles { get; set; }
    }
}