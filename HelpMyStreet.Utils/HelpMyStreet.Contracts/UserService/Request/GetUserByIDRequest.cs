using HelpMyStreet.Contracts.UserService.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts.UserService.Request
{
    public class GetUserByIDRequest : IRequest<GetUserByIDResponse>
    {
        public int ID { get; set; }
    }
}
