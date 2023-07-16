using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class rentals_detailsDal
    {

        //שליפת כל פרטי השכרות
        public static List<rentals_details> GetAllRentals_details()
        {
            try
            {

                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.rentals_details.Where(p => p.status == "פעיל").ToList();
                    return t;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }

        //קבלת פרטי השכרה לפי תאריך
        public static rentals_details GetByDate(DateTime date)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {


                    rentals_details rentDet = db.rentals_details.FirstOrDefault(p => p.date == date && p.status == "פעיל");
                    return rentDet;
                }
            }
            catch
            {
                return null;
            }

        }
        //שליפת פרטי השכרה לפי מספר פרטי השכרה
        public static rentals_details GetRentDetById(int id)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {


                    rentals_details rentDet = db.rentals_details.FirstOrDefault(p => p.RentalDetails_id == id);
                    return rentDet;
                }
            }
            catch
            {
                return null;
            }

        }

        //שליפת כניסות ע''פ מספר השכרה

        public static List<rentals_details> GetRentDetailByReId(int id)
        {
            try
            {

                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.rentals_details.Where(p => p.rent_id == id).ToList();
                    return t;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }

        //הוספת פרטי השכרה

        public static bool AddRentalDetails(rentals_details Rent)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    db.rentals_details.Add(Rent);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }
      


        //מחיקת פרטי השכרה

        public static bool RemoveRentalDetails(int id)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {

                    var e = db.rentals_details.FirstOrDefault(p => p.RentalDetails_id == id);
                    if (e != null)
                    {
                        e.status = "לא פעיל";
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

        //החזרת קוד לקוח האחרון שהתווסף
        public static int LastRentId()
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.Rentals.ToList();
                    var cust = t[t.Count - 1];
                    return cust.rent_id;
                }
            }
            catch
            {
                return -1;
            }
        }

        //שליפת שמות המשכירים- לפרטי השכרה
        public static List<string> getRentalDetName()
        {
            try
            {

                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    List<string> RentalDetNames = new List<string>();

                    var rental = db.rentals_details.Where(p => p.status == "פעיל").ToList();
                    foreach (var c in rental)
                    {
                        var rent = db.Rentals.FirstOrDefault(p => p.rent_id == c.rent_id);
                        var cust = db.customers.FirstOrDefault(p => rent.cust_id == p.cust_id);
                        if (cust != null)
                            RentalDetNames.Add(cust.first_name + " " + cust.last_name);
                    }
                    return RentalDetNames;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
