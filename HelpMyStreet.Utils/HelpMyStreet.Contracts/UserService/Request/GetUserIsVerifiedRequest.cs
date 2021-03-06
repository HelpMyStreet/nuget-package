﻿using HelpMyStreet.Contracts.UserService.Response;
using MediatR;

namespace HelpMyStreet.Contracts.UserService.Request
{
    public class GetUserIsVerifiedRequest : IRequest<GetUserIsVerifiedResponse>
    {
        public int UserID { get; set; }
    }
}
