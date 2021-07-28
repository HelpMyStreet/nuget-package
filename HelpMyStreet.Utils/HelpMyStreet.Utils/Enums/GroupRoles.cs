using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HelpMyStreet.Utils.Enums
{
    public enum GroupRoles
    {
        [Description("Standard")]
        Member = 1,
        
        [Description("Admin")]
        TaskAdmin = 2,
        
        [Description("Admin")]
        UserAdmin = 3,

        [Description("Admin")]
        Owner = 4,

        [Description("Admin")]
        RequestSubmitter = 5,

        [Description("Standard")]
        Volunteer = 6,

        [Description("Admin")]
        UserAdmin_ReadOnly = 7
    }
}