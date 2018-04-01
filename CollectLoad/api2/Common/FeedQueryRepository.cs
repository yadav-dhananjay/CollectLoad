using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace ReportApi.Common
{
    public class FeedQueryRepository: IFeedQueryRepository
    {
        public async Task<List<LoadDetail>> QueryFeed(Int32 duration, String serverName = "")
        {
            Uri url = new Uri(ConfigurationManager.AppSettings["IntegrationUrl"] + $"/{duration}/time/{serverName}/server");

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.ContentType = "application/json";
            req.Method = "GET";

            req.Host = url.Host;

            WebResponse resp = await req.GetResponseAsync();

            using (var reader = new StreamReader(resp?.GetResponseStream()))
            {

                var js = new JavaScriptSerializer();
                var doclist = js.Deserialize<List<LoadDetail>>(reader.ReadToEnd());

                return doclist;
            }
        }
    }
}