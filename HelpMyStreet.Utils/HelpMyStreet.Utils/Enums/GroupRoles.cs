using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HelpMyStreet.Utils.Enums
{
    public enum GroupRoles
    {        
        Member = 1,            
        TaskAdmin = 2,               
        UserAdmin = 3,
        Owner = 4,
        RequestSubmitter = 5,
        Volunteer = 6,
        UserAdmin_ReadOnly = 7,
        ShowCharts = 8
    }
}