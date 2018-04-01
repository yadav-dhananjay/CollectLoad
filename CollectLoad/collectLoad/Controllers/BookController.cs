using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using common;

namespace collectLoad.Controllers
{
    public class BookController : ApiController
    {

        private IBook _meditor;
        public BookController(IBook meditor)
        {
            _meditor = meditor;
        }
        [HttpGet]
        public IHttpActionResult getBook()
        {
          return  Ok(_meditor.GetBookInformation());
        }
    }
}
