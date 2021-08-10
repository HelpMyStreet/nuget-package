using HelpMyStreet.Contracts.RequestService.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.RequestService.Request
{
    public class PutUpdateJobQuestionRequest : IRequest<PutUpdateJobQuestionResponse>
    {
        public int JobID { get; set; }
        public int QuestionID { get; set; }
        public string Answer { get; set; }
        public int AuthorisedByUserID { get; set; }
    }
}
