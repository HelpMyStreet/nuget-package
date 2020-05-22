﻿using HelpMyStreet.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.UserService.Response
{
    public class EmailRecipient
    {
        public int UserID { get; set; }
        public bool? IsVerified { get; set; }
        public bool? IsStreetChampionForGivenPostCode { get; set; }
    }
}
