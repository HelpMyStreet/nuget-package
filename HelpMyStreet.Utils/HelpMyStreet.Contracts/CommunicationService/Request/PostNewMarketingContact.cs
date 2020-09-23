using MediatR;

namespace HelpMyStreet.Contracts.CommunicationService.Request
{
    public class PostNewMarketingContact : IRequest<bool>
    {
        public MarketingContact MarketingContact { get; set; }
    }
}
