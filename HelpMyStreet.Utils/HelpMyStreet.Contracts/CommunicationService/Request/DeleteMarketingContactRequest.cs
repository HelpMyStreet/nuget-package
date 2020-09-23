using MediatR;

namespace HelpMyStreet.Contracts.CommunicationService.Request
{
    public class DeleteMarketingContactRequest : IRequest<bool>
    {
        public MarketingContact MarketingContact { get; set; }
    }
}
