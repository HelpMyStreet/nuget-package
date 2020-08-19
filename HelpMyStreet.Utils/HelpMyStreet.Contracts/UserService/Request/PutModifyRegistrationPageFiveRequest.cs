using HelpMyStreet.Contracts.UserService.Response;
using HelpMyStreet.Utils.Models;
using MediatR;

namespace HelpMyStreet.Contracts.UserService.Request
{
    public class PutModifyRegistrationPageFiveRequest : IRequest<PutModifyRegistrationPageFiveResponse>
    {
        public RegistrationStepFive RegistrationStepFive { get; set; }
    }
}
