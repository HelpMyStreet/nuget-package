using HelpMyStreet.Contracts.RequestService.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HelpMyStreet.Contracts.RequestService.Request
{
    public class DeleteRequestRequest : IRequest<DeleteRequestResponse>
    {
        [Required]
        public int RequestID { get; set; }

        [Required]
        public string Postcode { get; set; }
    }
}
