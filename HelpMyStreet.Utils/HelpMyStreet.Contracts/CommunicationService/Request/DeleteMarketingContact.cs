using MediatR;

namespace HelpMyStreet.Contracts.CommunicationService.Request
{
    public class DeleteMarketingContact : IRequest<bool>
    {
        public MarketingContact MarketingContact { get; set; }
    }
}
