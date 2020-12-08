using HelpMyStreet.Contracts.RequestService.Response;
using MediatR;
using System;

namespace HelpMyStreet.Contracts.RequestService.Request
{
    public class PutUpdateDueDateRequest : IRequest<PutUpdateJobDueDateResponse>
    {
        public int? JobID { get; set; }
        public DateTime DueDate { get; set; }
        public int? AuthorisedByUserID { get; set; }
    }
}
