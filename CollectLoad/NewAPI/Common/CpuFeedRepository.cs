
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Common
{
    public class CpuFeedRepository : ICpuFeedRepository
    {
        public static List<LoadDetail>  DisDictionary=new List<LoadDetail>();
        public void SaveCpuFeed(String servername, decimal cpuLoad, decimal ramLoad)
        {
             DisDictionary.Add(new LoadDetail() {CpuLoad = cpuLoad, Ram = ramLoad, ServerName = servername, FeedDateTime=DateTime.Now});
           
        }

        public async Task<List<LoadDetail>> GetTelemetryData(Int32 duration, string servername)
        {

            List <LoadDetail> list = DisDictionary.Where(e => e.FeedDateTime >= DateTime.Now.AddHours(-duration)).OrderByDescending(e=>e.FeedDateTime).ToList();
            if (!string.IsNullOrEmpty(servername))
            {
                list= list
                    .Where(e => e.ServerName.ToUpper().Equals(servername.ToUpper())).ToList();
            }
           
          return await Task.FromResult<List<LoadDetail>>(list);
        



        }

       
    }
}
