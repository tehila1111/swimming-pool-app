using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Bll;
using Dto;
namespace WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class WorkShRentalsController : ApiController
    {
        // GET: api/WorkShRentals
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/WorkShRentals/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/WorkShRentals
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/WorkShRentals/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/WorkShRentals/5
        public void Delete(int id)
        {
        }
    }
}
