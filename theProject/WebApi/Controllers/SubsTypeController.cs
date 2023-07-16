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
    public class SubsTypeController : ApiController
    {
    

  

        //הצגת כל סוגי המנויים
        public List<Subscription_Type_Dto> GetSubType()
        {
            return SubsTypeBLL.GetAllSubsType();
        }


        //הצגת מספר כניסות ל סוג מנוי
        public int GetNumEnter(int id)
        {
            return SubsTypeBLL.SumEnter(id);
        }

        //הצגת שם סוג מנוי
        public List<string> GetAllTypeNames()
        {
            return SubsTypeBLL.GetSubTypeById();
        }


        //הוספת סוג מנוי
        public bool PostSubType([FromBody] Subscription_Type_Dto insert)
        {
            //בדיקה אם קיים כבר
           return SubsTypeBLL.AddSubType(insert.type,insert.Num_of_entrances,insert.price,insert.status);
            
        }

        //מחיקת סוג מנוי
       
        public bool DeleteSubType(int id)
        {
            return SubsTypeBLL.RemoveSubType(id);

        }


        public bool Put( Subscription_Type_Dto update)
        {
             return SubsTypeBLL.UpdateSubType(update.Subscription_type_id,update.type, update.Num_of_entrances, update.price, update.status);
        }

       
    }
}
