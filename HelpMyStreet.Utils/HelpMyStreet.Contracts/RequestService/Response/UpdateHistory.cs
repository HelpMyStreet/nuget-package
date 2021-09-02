using HelpMyStreet.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.RequestService.Response
{
    public class UpdateHistory
    {
        public DateTime DateCreated { get; set; }
        public int? CreatedByUserID { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public int? QuestionID { get; set; }
        public string FieldChanged { get; set; }
    }
}
