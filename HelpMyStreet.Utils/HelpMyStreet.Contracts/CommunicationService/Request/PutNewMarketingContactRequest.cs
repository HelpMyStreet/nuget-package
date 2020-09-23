using MediatR;

namespace HelpMyStreet.Contracts.CommunicationService.Request
{
    public class PutNewMarketingContactRequest : IRequest<bool>
    {
        public MarketingContact MarketingContact { get; set; }
    }
}
