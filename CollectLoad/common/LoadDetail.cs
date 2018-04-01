using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common12
{
  public  class LoadDetail
    {
        

        public string ServerName { get; set; }
        public decimal CpuLoad { get; set; }
        public decimal Ram { get; set; }
        public DateTime FeedDateTime { get; set; }
    }
}
