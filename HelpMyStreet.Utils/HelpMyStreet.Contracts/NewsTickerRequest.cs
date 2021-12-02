using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMyStreet.Contracts
{
    public class NewsTickerRequest : IRequest<NewsTickerResponse>
    {
        public int? GroupId { get; set; }
    }
}
