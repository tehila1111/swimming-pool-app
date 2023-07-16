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
    public class BusinessDetailsController : ApiController
    {
        // GET: api/BusinessDetails
        public List<BusinessDetailsDto> Get()
        {
            return BusinessDetailsBll.GetAllDetails();
        }

        
        // PUT: api/BusinessDetails/5
        public bool Put(BusinessDetailsDto obj)
        {
            //string BusinessName = b[0].BusinessName;
            //string address = b[0].address;
            //string rentDay = b[0].rentDay;
            //int rentPrice = b[0].rentPrice;
            //TimeSpan RentStartHour = b[0].RentStartHour;
            //TimeSpan RentEndHour = b[0].RentEndHour;
            return BusinessDetailsBll.UpdateDetails(obj.BusinessName,obj.address,obj.rentDay,obj.rentPrice,obj.RentStartHour,obj.RentEndHour);
        }

        // DELETE: api/BusinessDetails/5
        public void Delete(int id)
        {
        }
    }
}
