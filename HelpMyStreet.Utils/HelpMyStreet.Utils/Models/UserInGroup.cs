using HelpMyStreet.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Utils.Models
{
    public class UserInGroup
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public List<GroupRoles> GroupRoles { get; set; }
        public List<UserCredential> UserCredentials { get; set; }        
    }
}


