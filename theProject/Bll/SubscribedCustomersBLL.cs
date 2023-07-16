using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bll
{
    public class SubscribedCustomersBLL
    {
        //הצגת כל המנויים
        public static List<Subscribed_customersDto> GetAllSubs()
        {
            return Subscribed_customersDto.toDTO_List(Subscribed_customersDal.GetAllSubscribed());
        }


        //הוספת מנוי חדש
        public static bool AddSubs(int Subscription_type, int sum_of_entries, string status)
        {
            var cust_id = Subscribed_customersDal.GetLast().cust_id;
            Subscribed_customersDto s = new Subscribed_customersDto(cust_id, Subscription_type, sum_of_entries, status);
            return Subscribed_customersDal.AddNewSubs(Subscribed_customersDto.toSubCustTBL(s));
        }


        //הוספת מנוי - לקוח קיים
        public static bool AddUpdateSub(int custId, int Subscription_type, int sum_of_entries, string status)
        {           
            Subscribed_customersDto s = new Subscribed_customersDto(custId, Subscription_type, sum_of_entries, status);
            return Subscribed_customersDal.AddNewSubs(Subscribed_customersDto.toSubCustTBL(s));
        }

        //מחיקת מנוי
        public static bool RemoveSubs(int subID)
        {
            Subscribed_customersDto sub=GetSubsById(subID);
            CustomersBLL.updateArchiveStatus(sub.cust_id, "לא פעיל");
            return Subscribed_customersDal.RemoveSubs(subID);
        }

        //שליפת מנוי לפי קוד מנוי
        public static Subscribed_customersDto GetSubsById(int subId)
        {
            return Subscribed_customersDto.toSubCustDTO(Subscribed_customersDal.GetSubscribedById(subId));
        }


        //שליפת מנוי לפי קוד לקוח
        public static Subscribed_customersDto GetSubsByCustId(int subId)
        {
            return Subscribed_customersDto.toSubCustDTO(Subscribed_customersDal.GetSubsByCustId(subId));
        }

        //עדכון מנוי- מספר כניסות וסטטוס
        public static bool UpdateSub(Subscribed_customersDto sub)
        {
            return Subscribed_customersDal.UpdateSub(Subscribed_customersDto.toSubCustTBL(sub));
        }

        //עידכון סטטוס מנוי
        public static bool UpdateSubStatus(int subId, string action)
        {
            return Subscribed_customersDal.UpdateSubStatus(subId, action);
        }
        //עידכון סטטוס מנוי
        public static bool UpdateSubEnterDate(int subId, DateTime startDate, int enter)
        {
            return Subscribed_customersDal.UpdateEnterDate(subId, startDate, enter);
        }


    }
}
