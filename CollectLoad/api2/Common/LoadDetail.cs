using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApi.Common
{
  public  class LoadDetail
    {
       
        public string ServerName { get; set; }
        public decimal CpuLoad { get; set; }
        public decimal Ram { get; set; }
        public DateTime FeedDateTime { get; set; }
    }
}
