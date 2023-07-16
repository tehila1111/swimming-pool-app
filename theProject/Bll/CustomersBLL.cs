using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bll
{

    public class CustomersBLL
    {
        //שליפת כל הלקוחות 
        public static List<customers_Dto> GetAllCust()
        {
            return customers_Dto.toDTO_List(CustomersDal.GetAllCustomers());
        }


        //שליפת כל לקוחות הארכיון
        public static List<customers_Dto> GetArchiveCustomers()
        {
            return customers_Dto.toDTO_List(CustomersDal.GetArchiveCustomers());

        }


        //שליפת  לקוח המשכיר הפעיל כרגע
        public static customers_Dto GetActiveRentCust()
        {

            DateTime myDateTime = DateTime.Today;
            List<rentals_detailsDto> rentalsDetails = rentals_detailsBLL.GetAllRentDetails();
            List<Rentals_Dto> rentals = RentalsBLL.GetAllRentals();
            List<customers_Dto> allCustomers = GetAllCust();
            rentals_detailsDto rent = rentalsDetails.FirstOrDefault(e => e.date == myDateTime);

            if (rent != null)
            {
                Rentals_Dto currentRent = rentals.FirstOrDefault(r => r.rent_id == rent.rent_id);
                customers_Dto activeRent = getCustById(currentRent.cust_id);
                if(activeRent != null)
                {
                    return activeRent;
                }
                else
                    return null;

                //customers_Dto activeRent = allCustomers.FirstOrDefault(c => c.cust_id == currentRent.cust_id);

                //return activeRent;

            }

            else
                return null;

        }



        //שליפת כל הלקוחות - שהם מנויים פעילים
        public static List<customers_Dto> GetAllActiveSubs()
        {
            List<Subscribed_customersDto> allSubs = SubscribedCustomersBLL.GetAllSubs();
            List<customers_Dto> activeCustSubs = new List<customers_Dto>();
            foreach (var s in allSubs)
            {
                if (s.status == "פעיל")
                {
                    customers_Dto cust = getCustById(s.cust_id);
                    activeCustSubs.Add(cust);

                }

            }
            return activeCustSubs;
        }

        //שליפת לקוח לפי קוד
        public static customers_Dto getCustById(int id)
        {
            return customers_Dto.toCustDTO(CustomersDal.GetCustByID(id));
        }



        //עדכון לקוח
        public static bool UpdateCust(customers_Dto c)
        {
            return CustomersDal.UpdateCust(customers_Dto.toCustTBL(c));
        }


        //בדיקה האם ישנו לקוח עם פרטים זהים
        public static customers_Dto ifExist(customers_Dto c)
        {
            return customers_Dto.toCustDTO(CustomersDal.ifExist(customers_Dto.toCustTBL(c)));
        }

        //הוספת לקוח
        public static int AddCust(customers_Dto c)
        {
            var exist = ifExist(c);//בדיקה האם הלקוח קיים במאגר
            if (exist != null)//הלקוח קיים
            {
                if (exist.archive == "פעיל")
                    return -1;
                else
                {
                    updateArchiveStatus(exist.cust_id, "פעיל");
                    return exist.cust_id;
                }

            }
            else
                CustomersDal.AddNewCust(customers_Dto.toCustTBL(c));
            return 0;

        }

        //שליפת מספר לקוחות
        public static int GetSumOfCust()
        {
            return customers_Dto.toDTO_List(CustomersDal.GetAllCustomers()).Count;
        }



        //קוד לקוח משכיר האחרון שנוצר
        public static int LastRentId()
        {
            int count = GetSumOfCust() - 1;
            customers_Dto lastCust = GetAllCust()[count];
            return lastCust.cust_id;

        }


        //  עדכון סטטוס ארכיון- עדכון לקוח לפעיל או לא פעיל
        public static bool updateArchiveStatus(int id, string action)
        {
            return CustomersDal.updateArchiveStatus(id, action);
        }

        //מחיקת לקוח
        public static bool DeleteCust(int custId)
        {
            customers_Dto cust=getCustById(custId);
            if(cust.status=="מנוי")
            {
                Subscribed_customersDto s = SubscribedCustomersBLL.GetSubsByCustId(custId);
                return SubscribedCustomersBLL.RemoveSubs(s.Subscription_id);
            }
            else
                if(cust.status=="עסקי")
            {
                Rentals_Dto r = RentalsBLL.GetRentByCustId(custId);
                return RentalsBLL.RemoveRent(r.rent_id);
            }
            return false; 
        }












        //שליפת שמות לקוחות מנויים
        public static List<string> GetAllNames()
        {
            try
            {

                return CustomersDal.GetSubNamsById();

            }
            catch (Exception e)
            {
                throw;
            }
        }














    }
}
