using MediatR;
using ReportApi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReportApi.Queries
{
    public class GetCpuFeedQuery:IRequest<List<LoadDetail>>
    {
        public int Duration { get; set; }
        public string ServerName { get; set; }
    }
}