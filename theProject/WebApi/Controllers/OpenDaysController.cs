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

    public class OpenDaysController : ApiController
    {
      

        //הצגת כל ימי הפתיחה
        public List<Open_Days_Dto> GetOpenDays()
        {
            var e = OpenDaysBLL.GetAllOpenDays();
            return e;
        }

        //שליפת המשמרת והיום פתיחה הנוכחי
        public Open_Days_Dto GetCurrentOpenDays()
        {
            var e = OpenDaysBLL.GetCurrentOpen();
            if (e != null)
                return e;
            else
                return null;
        }


        //הוספת יום פתיחה
        public bool Post([FromBody] Open_Days_Dto open)
        {
            return OpenDaysBLL.AddOpen(open.shift_id,open.day,open.gender,open.status);
        }

        // PUT: api/OpenDays/5
        public bool Put(Open_Days_Dto open)
        {
            return OpenDaysBLL.UpdateOpenDay(open);
        }

        // DELETE: api/OpenDays/5
        public void Delete(int id)
        {
            OpenDaysBLL.RemoveOpen(id); 
        }
    }
}
