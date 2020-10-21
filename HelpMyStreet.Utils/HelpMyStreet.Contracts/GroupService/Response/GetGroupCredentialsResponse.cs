using HelpMyStreet.Utils.Enums;
using System.Collections.Generic;

namespace HelpMyStreet.Contracts.GroupService.Response
{
    public class GroupCredential
    {
        public int GroupID { get; set; }
        public int CredentialID { get; set; }
        public CredentialTypes CredentialTypes { get; set; }
        public CredentialVerifiedBy CredentialVerifiedBy { get; set; }
        public string Name { get; set; }
        public string HowToAchieve { get; set; }
        public string HowToAchieve_CTA_Destination { get; set; }
        public string WhatIsThis { get; set; }
        public int DisplayOrder { get; set; }      
    }
    public class GetGroupCredentialsResponse
    {
        public List<GroupCredential> GroupCredentials { get; set; }
    }
}