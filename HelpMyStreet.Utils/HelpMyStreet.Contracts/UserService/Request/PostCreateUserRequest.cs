using HelpMyStreet.Contracts.UserService.Response;
using HelpMyStreet.Utils.Models;
using MediatR;

namespace HelpMyStreet.Contracts.UserService.Request
{
    public class PostCreateUserRequest : IRequest<PostCreateUserResponse>
    {
        public RegistrationStepOne RegistrationStepOne { get; set; }
    }
}
