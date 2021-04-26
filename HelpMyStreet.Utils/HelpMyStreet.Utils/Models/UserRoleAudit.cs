using HelpMyStreet.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace HelpMyStreet.Utils.Models
{
    public class UserRoleAudit
    {
        public int AuthorisedByUserID { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public int RoleId { get; set; }
        public DateTime DateRequested { get; set; }
        public byte ActionId { get; set; }
        public bool Success { get; set; }
    }

}


