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
    public class CustEnterController : ApiController
    {

        //הצגת כל הכניסות
        public List<Customers_enterDto> GetAllEnter()
        {
            var e = CustomersEnterBLL.GetAllEnter();
            return e;
        }


        //הצגת כניסה לפי קוד
        public Customers_enterDto GetEntById(int id)
        {
            var e = CustomersEnterBLL.GetSubEnterById(id);
            return e;
        }


        //הוספת כניסת מנוי שליחת משמרת ומנוי
        public bool PostSub(int id, int id2)
        {
            return CustomersEnterBLL.AddEnter(id, id2);

        }


        public bool addRentEnter()
        {
            return CustomersEnterBLL.AddRentEnter();
        }




        // מחיקת כניסת לקוח מנוי
        public bool DeleteSubEnter(int id)
        {
            return CustomersEnterBLL.RemoveSubEnter(id);
        }

        //שליפת שמות מנויים לכניסה
        public List<string> getSubNames()
        {
            return CustomersEnterBLL.getEnterSubsName();
        }
        //שליפת שמות משמרות לכניסה
        public List<string> getShiftNames()
        {
            return CustomersEnterBLL.getEnterShiftName();
        }
    }
}
