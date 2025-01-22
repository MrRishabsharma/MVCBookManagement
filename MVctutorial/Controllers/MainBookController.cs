using MVctutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVctutorial.Controllers.Api
{
    [RoutePrefix("api/MainBook")]
    public class MainBookController : ApiController
    {
        EmpDetailsContext DB = new EmpDetailsContext();

        [HttpGet]
        [Route("")]
        public IHttpActionResult Index()
        {
            List<ProductsDetails> obj = DB.ProductVariant.ToList();
            return Ok(obj);
        }




    }
}
