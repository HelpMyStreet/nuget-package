using HelpMyStreet.Contracts.UserService.Response;
using HelpMyStreet.Utils.Enums;
using MediatR;

namespace HelpMyStreet.Contracts.UserService.Request
{
    public class GetEmailRecipientRequest : IRequest<GetEmailRecipientResponse>
    {
        public string Postcode { get; set; }
        public SupportActivities Activity { get; set; }
    }
}
