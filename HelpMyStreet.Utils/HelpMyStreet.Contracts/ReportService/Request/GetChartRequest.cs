using HelpMyStreet.Contracts.GroupService.Request;
using HelpMyStreet.Contracts.ReportService.Response;
using MediatR;

namespace HelpMyStreet.Contracts.ReportService.Request
{
    public class GetChartRequest : IRequest<GetChartResponse>
    {
        public int GroupId { get; set; }
        public ChartRequest Chart { get; set; }

    }
}
