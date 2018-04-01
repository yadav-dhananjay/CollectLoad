using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ReportApi.Common
{
    public interface IFeedQueryRepository
    {
        Task<List<LoadDetail>> QueryFeed(Int32 duration, String serverName = "");
    }
}