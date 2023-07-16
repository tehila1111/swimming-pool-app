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

    public class RentalsController : ApiController
    {

        //הצגת כל המשכירים
        public List<Rentals_Dto> GetAllRentals()
        {
            return RentalsBLL.GetAllRentals();
        }

       

        //הוספת השכרה
        public dynamic PostRent([FromBody] List<dynamic> obj)
        {
            int Syear = obj[0].year;
            int Smonth = obj[0].month;
            int Sday = obj[0].day;

            int Eyear = obj[1].year;
            int Emonth = obj[1].month;
            int Eday = obj[1].day;
          

            DateTime start = new DateTime(Syear, Smonth, Sday);
            DateTime end = new DateTime(Eyear, Emonth, Eday);
            var custId = CustomersBLL.LastRentId();
            var numOfRents = (int)obj[2].numOfRents;
            int price = (int)RentalsBLL.getRentPrice();
            int allPrice = price * numOfRents;

            return RentalsBLL.AddRent(custId, start, end, allPrice, "שולם","פעיל");
        }

        public bool DeleteRent(int id)
        {
            return RentalsBLL.RemoveRent(id);
        }


        public bool PutStatus(int id, string name)
        {
            return RentalsBLL.UpdateStatus(id, name);
        }

        public List<string> getRentalsName()
        {
            return RentalsBLL.getRentalsName();
        }



    }
}
