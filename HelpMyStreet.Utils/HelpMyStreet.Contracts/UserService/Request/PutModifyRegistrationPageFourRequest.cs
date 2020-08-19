using HelpMyStreet.Contracts.UserService.Response;
using HelpMyStreet.Utils.Models;
using MediatR;

namespace HelpMyStreet.Contracts.UserService.Request
{
    public class PutModifyRegistrationPageFourRequest : IRequest<PutModifyRegistrationPageFourResponse>
    {
        public RegistrationStepFour RegistrationStepFour { get; set; }
    }
}
