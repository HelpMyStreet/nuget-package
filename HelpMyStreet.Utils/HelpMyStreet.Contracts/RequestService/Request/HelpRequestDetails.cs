using HelpMyStreet.Utils.Enums;
using HelpMyStreet.Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelpMyStreet.Contracts.RequestService.Request
{
    public class HelpRequestDetail
    {
        public HelpRequest HelpRequest { get; set; }
        public NewJobsRequest NewJobsRequest { get; set; }

        public bool Repeat 
        { 
            get
            {
                return NewJobsRequest.Jobs.First().NumberOfRepeats > 1;
            }
        }

        public bool MultiVolunteer
        {
            get
            {
                bool multi = false;
                var numberOfSlotsQuestion = NewJobsRequest.Jobs.First().Questions?.Where(x => x.Id == (int)Questions.NumberOfSlots).FirstOrDefault();

                if (numberOfSlotsQuestion != null)
                {
                    int numberOfSlots = Convert.ToInt32(numberOfSlotsQuestion.Answer);

                    multi = numberOfSlots > 1;
                }
                return multi;
                   
            }
        }


    }
}
