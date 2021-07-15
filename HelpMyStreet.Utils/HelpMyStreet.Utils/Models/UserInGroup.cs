using HelpMyStreet.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Utils.Models
{
    public class UserInGroup
    {
        private const int YOTI_CREDENTIAL_ID = -1;
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public List<GroupRoles> GroupRoles { get; set; }
        public List<int> ValidCredentials { get; set; }
        public List<UserRoleAudit> UserRoleAudit { get; set; }
        public bool UserIsYotiVerified
        {
            get
            {
                return ValidCredentials.Contains(YOTI_CREDENTIAL_ID);
            }
        }
    }

}


