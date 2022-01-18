using HelpMyStreet.Contracts.ReportService.Response;
using MediatR;

namespace HelpMyStreet.Contracts.ReportService.Request
{
    public class GetChartsRequest : IRequest<GetChartsResponse>
    {
        public int GroupId { get; set; }
    }
}
