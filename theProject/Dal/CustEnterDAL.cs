using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class CustEnterDAL
    {

        //שליפת כל הכניסות
        public static List<Customers_enter> GetAllEnter()
        {
            try
            {

                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.Customers_enter.ToList();
                    return t;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }


        //החזרת כניסה לפי קוד כניסה
        public static Customers_enter GetSubEntByEntId(int enter)
        {
            try
            {

                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.Customers_enter.FirstOrDefault(p => p.enter_id == enter);
                    return t;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }
       


        //הוספת כניסת מנוי

        public static bool AddNewEnter(Customers_enter e)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var sub = db.Subscribed_customers.FirstOrDefault(p => p.Subscription_id == e.Subscription_id);
                  
                        sub.sum_of_entries--;
                        db.Customers_enter.Add(e);
                        db.SaveChanges();
                        return true;               


                }
            }
            catch
            {
                return false;
            }

        }


        //הוספת כניסת משכיר
        public static bool AddRentEnter()
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var rentDetails = db.rentals_details.FirstOrDefault(p => p.date == DateTime.Today);

                    if (rentDetails != null)
                    {
                        rentDetails.status = "לא פעיל";                        
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }
       




        //מחיקת כניסת מנוי

        public static bool RemoveSubEnter(int EnterId)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {

                    var e = db.Customers_enter.FirstOrDefault(p => p.enter_id == EnterId);
                    if (e != null)
                    {
                        db.Customers_enter.Remove(e);
                        db.SaveChanges();
                        return true;
                    }
                    return false;

                }
            }
            catch
            {
                return false;
            }

        }

        //שליפת שמות המשמרות
        public static List<string> getShiftsName()
        {
            try
            {

                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    List<string> ShiftNames = new List<string>();

                    var enter = db.Customers_enter.ToList();
                    foreach (var c in enter)
                    {
                        var sub = db.work_shift_type.FirstOrDefault(p => p.shift_id == c.work_shift_id);

                        string name = sub.name;
                        ShiftNames.Add(name);

                    }
                    return ShiftNames;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }

        //שליפת שמות המנויים לכניסה

        //שליפת שמות המנויים
        public static List<string> getEnterSubsName()
        {
            try
            {

                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    List<string> SubsNames = new List<string>();

                    var enter = db.Customers_enter.ToList();
                    foreach (var c in enter)
                    {
                        var sub = db.Subscribed_customers.FirstOrDefault(p => c.Subscription_id == p.Subscription_id);
                        if (sub != null)
                        {
                            var subId = sub.cust_id;
                            var custName = db.customers.FirstOrDefault(p => p.cust_id == subId);
                            if (custName != null)
                            {
                                string name = custName.first_name + " " + custName.last_name;
                                SubsNames.Add(name);
                            }

                        }

                    }
                    return SubsNames;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
