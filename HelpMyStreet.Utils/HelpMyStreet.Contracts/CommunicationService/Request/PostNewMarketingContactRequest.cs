using MediatR;

namespace HelpMyStreet.Contracts.CommunicationService.Request
{
    public class PostNewMarketingContactRequest : IRequest<bool>
    {
        public MarketingContact MarketingContact { get; set; }
    }
}
