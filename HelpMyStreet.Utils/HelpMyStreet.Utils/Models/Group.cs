using HelpMyStreet.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Utils.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string FriendlyName { get; set; }
        public string GroupName { get; set; }
        public string GroupKey { get; set; }
        public int? ParentGroupId { get; set; }
        public bool ShiftsEnabled { get; set; }
        public bool TasksEnabled { get; set; }
        public bool HomepageEnabled { get; set; }
        public string GeographicName { get; set; }
        public GroupTypes GroupType { get; set; }
        public List<MapDetails> Maps { get; set; }
        public string LinkURL { get; set; }

    }
}
