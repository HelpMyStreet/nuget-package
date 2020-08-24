using HelpMyStreet.Contracts.UserService.Response;
using HelpMyStreet.Utils.Models;
using MediatR;

namespace HelpMyStreet.Contracts.UserService.Request
{
    public class PutModifyRegistrationPageTwoRequest : IRequest<PutModifyRegistrationPageTwoResponse>
    {
        public RegistrationStepTwo RegistrationStepTwo { get; set; }
    }
}
