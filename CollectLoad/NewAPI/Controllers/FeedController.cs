using DataAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DataAPI.Controllers
{
    [RoutePrefix("api/feed")]
    public class FeedController : ApiController
    {
        private ICpuFeedRepository _ICpuFeedRepository;

        public FeedController(ICpuFeedRepository ICpuFeedRepository)
        {
            _ICpuFeedRepository = ICpuFeedRepository;
        }

     /// <summary>
     /// 
     /// </summary>
     /// <param name="serverName">Server ID</param>
     /// <param name="cpuLoad">CPU Feed</param>
     /// <param name="ramLoad">RAM load</param>
     /// <returns></returns>
        [Route("savefeed")]
        public IHttpActionResult SaveCpuFeed(String serverName, decimal cpuLoad, decimal ramLoad)
        {
            _ICpuFeedRepository.SaveCpuFeed(serverName, cpuLoad, ramLoad);
          return Ok();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="duration">in hour</param>
        /// <param name="servername">server Id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{duration}/time/{servername}/server")]
        
        public async  Task<IHttpActionResult> GetCpuFeed(int duration,string servername)
        {
            return Ok( await _ICpuFeedRepository.GetTelemetryData(duration, servername));
        }
    }
}
