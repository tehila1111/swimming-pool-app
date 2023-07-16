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
    public class OtherEnterController : ApiController
    {
        // GET: api/OtherEnter

        //הצגת כל הכניסות

        public List<OtherEnterDto> GetAllEnter()
        {
            var e = OtherEnterBll.GetAllEnter();
            return e;
        }

        //הוספת כניסה
        public bool Post(int id)
        {
            OtherEnterDto o = new OtherEnterDto(id);
            return OtherEnterBll.AddNewEnter(o);
        }


        // מחיקת כניסה
        public bool Delete(int id)
        {
            return OtherEnterBll.RemoveEnter(id);
        }

        public List<string> getOtherShiftsName()
        {
            return OtherEnterBll.getOtherShiftsName();  
        }
    }
}
