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
    public class CustomersController : ApiController
    {



        // שליפת טבלת לקוחות
        public List<customers_Dto> GetCust()
        {
            var e = CustomersBLL.GetAllCust();
            return e;
        }


        //שליפת לקוחות הארכיון
        public List<customers_Dto> GetArchiveCust()
        {
            var e = CustomersBLL.GetArchiveCustomers();
            return e;
        }

        //שליפת כל הלקוחות מנויים הפעילים כרגע
        public List<customers_Dto> GetAllActiveSubs()
        {
            var c=CustomersBLL.GetAllActiveSubs();
            return c;
        }

        //שליפת כל שמות המנויים
        public List<string> GetAllNames()
        {
            var c = CustomersBLL.GetAllNames();
        
            return c;
        }
        // שליפת המשכיר הנוכחי
        public customers_Dto GetCurrentRent()
        {
            customers_Dto e = CustomersBLL.GetActiveRentCust();
            return e;
        }
  
        // ID שליפת לקוח לפי  
        public customers_Dto GetById(int id)
        {
            var e = CustomersBLL.getCustById(id);
            return e;
        }

        
        //הוספת מנוי 
        public dynamic Postsub([FromBody] List<dynamic> obj)
        {
            int year = obj[0].year;
            int month = obj[0].month;
            int day = obj[0].day;
            DateTime birth = new DateTime(year, month, day);

            string first = obj[1].first_name;
            string last = obj[1].last_name;
            string phone = obj[1].telephone;
            string email = obj[1].email;
            string gender = obj[1].gender;

          
            
            customers_Dto cust = new customers_Dto(first, last, phone, email, gender, "מנוי", birth,"פעיל");
           
            return CustomersBLL.AddCust(cust);
        }


        //הוספת לקוח עסקי
        public dynamic PostRentCust([FromBody] List<dynamic> obj)
        {
            int year = obj[0].year;
            int month = obj[0].month;
            int day = obj[0].day;
            DateTime birth = new DateTime(year, month, day);

            string first = obj[1].first_name;
            string last = obj[1].last_name;
            string phone = obj[1].telephone;
            string email = obj[1].email;
            string gender = obj[1].gender;



            customers_Dto cust = new customers_Dto(first, last, phone, email, gender, "עסקי", birth,"פעיל");
            return CustomersBLL.AddCust(cust);
        }
     

        //עדכון סטטוס 
        public bool sendToArchive(int id)
        {
            return CustomersBLL.updateArchiveStatus(id,"לא פעיל");
        }

        //עדכון לקוח
        public dynamic Put([FromBody] List<dynamic> obj)
        {
            int year = obj[0].year;
            int month = obj[0].month;
            int day = obj[0].day;

            int id = obj[1].cust_id;
            string first = obj[1].first_name;
            string last = obj[1].last_name;
            string phone = obj[1].telephone;
            string email = obj[1].email;
            string gender = obj[1].gender;

            DateTime birth = new DateTime(year, month, day);
            customers_Dto cust = new customers_Dto(id, first, last, phone, email, gender, birth,"פעיל");
            return CustomersBLL.UpdateCust(cust);
        }

        //מחיקת לקוח
        public bool DeleteCust(int id)
        {
            return CustomersBLL.DeleteCust(id);
        }

    }
}
