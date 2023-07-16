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
    public class rentals_detailsController : ApiController
    {
        // הצגת כל פרטי השכרות
        public List<rentals_detailsDto> GetAllRentalsDetails()
        {
            return rentals_detailsBLL.GetAllRentDetails();
        }

        public List<string> getRentName()
        {
            return rentals_detailsBLL.getRentalDetName();       
        }
        
        // הצגת פרטי השכרות לפי קוד השכרה
        public List<rentals_detailsDto> GetRentByRentId(int id)
        {
            return rentals_detailsBLL.GetRentDetByReId(id);
        }

        //הוספת פרטי השכרה
        public dynamic PostRentDet([FromBody] List<dynamic> obj)
        {
            List<DateTime> rentList = new List<DateTime>();
            foreach (var iDate in obj)
            {
                DateTime oDate = Convert.ToDateTime(iDate);              
                
                rentList.Add(oDate);
                
            }
            return rentals_detailsBLL.AddRentDetails(rentList);

        }

       

          


            // PUT: api/rentals_details/5
            public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/rentals_details/5
        public bool Delete(int id)
        {
          return rentals_detailsBLL.RemoveRentDetails(id);
        }

        //שליפת כל תאריכי ההשכרה הפנויים
        public List<DateTime> GetAllFreeDates()
        {
            return rentals_detailsBLL.freeDates();
        }
    }
}
