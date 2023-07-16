using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bll
{

    public class CustomersEnterBLL
    {

        //שליפת כל כניסות הלקוחות- מנויים
        public static List<Customers_enterDto> GetAllEnter()
        {
            return Customers_enterDto.toDTO_List(CustEnterDAL.GetAllEnter());
        }

        // קבלת כניסת מנוי לפי קוד כניסה
        public static Customers_enterDto GetSubEnterById(int enterId)
        {
            return Customers_enterDto.toCustomersEnterDTO(CustEnterDAL.GetSubEntByEntId(enterId));
        }


        //הוספת כניסת מנוי
        public static bool AddEnter(int Subscription_id, int Shift_work)
        {
            Customers_enterDto enter = new Customers_enterDto(Subscription_id, Shift_work);
            Subscribed_customersDto sub = SubscribedCustomersBLL.GetSubsById(Subscription_id);
            List<Customers_enterDto> custEnter= CustomersEnterBLL.GetAllEnter();
            foreach(var e in custEnter)  //אם המנוי כבר נכנס היום במשמרת הזאת
            {
                if(e.Subscription_id==Subscription_id&&e.date==DateTime.Today&&e.work_shift_id==Shift_work)
                {
                    return false;
                }
            }
            CustEnterDAL.AddNewEnter(Customers_enterDto.toCustomersEnterTBL(enter));

            if (sub.sum_of_entries == 1)
            {
                //customers_Dto cust = CustomersBLL.getCustById(sub.cust_id);

                //הפיכת סטטוס מנוי - לא פעיל 
                SubscribedCustomersBLL.UpdateSubStatus(sub.Subscription_id, "לא פעיל");

                //אם הלקוח אינו משכיר- נעביר אותו לארכיון
               if (!RentalsBLL.checkIfCustIsRent(sub.cust_id))
                    CustomersBLL.updateArchiveStatus(sub.cust_id, "לא פעיל");
                return true;
            }
            else
            {
                return true;
            }
        }


        //כניסת משכיר
        public static bool AddRentEnter()
        {

            var rentDetails = rentals_detailsBLL.GetAllRentDetails().FirstOrDefault(e => e.date == DateTime.Today);
            var rent = RentalsBLL.GetAllRentals().FirstOrDefault(r => r.rent_id == rentDetails.rent_id);
            if (rentDetails != null)
            {
                CustEnterDAL.AddRentEnter();

                //בדיקה האם נגמר למשכיר ההשכרות
                if (rentDetails.date == rent.end_date)
                {
                    RentalsBLL.UpdateStatus(rent.rent_id, "לא פעיל");
                }
                return true;
            }
            else { return false; }
        }


        //מחיקת כניסת מנוי
        public static bool RemoveSubEnter(int EnterID)
        {
            Customers_enterDto enter = CustomersEnterBLL.GetSubEnterById(EnterID);
            Subscribed_customersDto sub = SubscribedCustomersBLL.GetSubsById(enter.Subscription_id);
            sub.sum_of_entries = sub.sum_of_entries + 1;
            if (sub.status == "לא פעיל")
            {
                sub.status = "פעיל";
                customers_Dto cust = CustomersBLL.getCustById(sub.cust_id);
                CustomersBLL.updateArchiveStatus(cust.cust_id, "פעיל");

            }

            SubscribedCustomersBLL.UpdateSub(sub);
            return CustEnterDAL.RemoveSubEnter(EnterID);

        }





        //שליפת שמות המנויים לכניסה

        public static List<string> getEnterSubsName()
        {
            try
            {

                return CustEnterDAL.getEnterSubsName();
            }
            catch (Exception e)
            {
                return null;
            }
        }




        //שליפת שמות המשמרות לכניסה
        public static List<string> getEnterShiftName()
        {
            try
            {

                return CustEnterDAL.getShiftsName();
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
