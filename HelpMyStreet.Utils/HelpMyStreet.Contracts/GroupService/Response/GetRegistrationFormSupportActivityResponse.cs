using HelpMyStreet.Utils.Models;
using System.Collections.Generic;

namespace HelpMyStreet.Contracts.GroupService.Response
{
    public class GetRegistrationFormSupportActivityResponse
    {
        public List<SupportActivityDetail> SupportActivityDetails { get; set; }
    }
}