using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common12
{
    public interface ICpuFeedRepository
    {
        void SaveCpuFeed(String servername, decimal cpuLoad, decimal ramLoad);
       Task<List<LoadDetail>> GetTelemetryData(Int32 duration,string servername);
    }
}
