using MediatR;
using ReportApi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ReportApi.Queries
{
    public class GetCpuFeedQueryHandler : IRequestHandler<GetCpuFeedQuery, List<LoadDetail>>
    {
        private readonly IFeedQueryRepository _queryRepository;
        public GetCpuFeedQueryHandler(IFeedQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<List<LoadDetail>> Handle(GetCpuFeedQuery message ,CancellationToken token)
        {
            return await _queryRepository.QueryFeed(message.Duration, message.ServerName);
        }
    }
}