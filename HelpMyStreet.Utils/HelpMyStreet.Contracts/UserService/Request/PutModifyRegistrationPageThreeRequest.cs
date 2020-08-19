using HelpMyStreet.Contracts.UserService.Response;
using HelpMyStreet.Utils.Models;
using MediatR;

namespace HelpMyStreet.Contracts.UserService.Request
{
    public class PutModifyRegistrationPageThreeRequest : IRequest<PutModifyRegistrationPageThreeResponse>
    {
        public RegistrationStepThree RegistrationStepThree { get; set; }
    }
}
