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
    public class WorkShTypeController : ApiController
    {
        // GET: api/WorkShType
      

        //הצגת כל הסוגים
        public List<Work_ShiftType_Dto> GetAllWSType()
        {
            var e = WorkShiftTypeBLL.GetAllWorkSType();
            return e;
        }


        //הוספת סוג

        public bool PostAddType(Work_ShiftType_Dto w)
        {
            return WorkShiftTypeBLL.AddWorkSType(w.name, w.start_hour, w.end_hour);
        }

        //מחיקת סוג 
        public bool DeleteType(int id)
        {
            return WorkShiftTypeBLL.RemoveWSType(id);
        }




       
        // PUT: api/WorkShType/5
        public bool Put(Work_ShiftType_Dto wst)
        {
            return WorkShiftTypeBLL.UpdateWorkShiType(wst); 
        }


        //שליפת שמות המשמרות
        public List<string> getShiftName()
        {
            var c = WorkShiftTypeBLL.getShiftName();

            return c;
        }
    }
}
