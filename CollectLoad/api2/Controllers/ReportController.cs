using ReportApi.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using MediatR;
using ReportApi.Queries;

namespace ReportApi.Controllers
{
    public class ReportController : ApiController
    {

        public ReportController(IMediator mediator)
        {
            Mediator = mediator;
        }
        protected IMediator Mediator { private set; get; }

        public async Task<List<LoadDetail>> GetCpuFeed(Int32 duration, String serverName = "")
        {
            return await Mediator.Send(new GetCpuFeedQuery() { Duration = duration, ServerName = serverName });
          
           
        }

      
    }
}
