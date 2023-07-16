using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class RentalsDal
    {
        //שליפת כל  ההשכרות - כלליות
        public static List<Rentals> GetAllRentals()
        {
            try
            {

                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.Rentals.Where(p=>p.status=="פעיל").ToList();
                    return t;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }

        //שליפת השכרה על פי מספר השכרה
        public static Rentals GetRentalByRent(int RentId)
        {
            try
            {

                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.Rentals.FirstOrDefault(u => u.rent_id == RentId);
                    return t;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }

        //שליפת השכרה לפי מספר לקוח
        public static Rentals GetRentalByCust(int custid)
        {
            try
            {

                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.Rentals.FirstOrDefault(u => u.cust_id == custid &&u.status=="פעיל");
                    if(t!=null)
                    return t;
                    else
                        return null;    
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static bool checkIfCustIsRent(int custid)
        {
            try
            {

                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.Rentals.FirstOrDefault(u => u.cust_id == custid && u.status == "פעיל");
                    if (t!=default&&t!=null)
                        return true;
                    else
                        return false;
                }

            }
            catch (Exception e)
            {
                return false;
            }
        }
        //הוספת השכרה - כללית

        public static bool AddNewRental(Rentals e)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    db.Rentals.Add(e);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }

        //עדכון סטטוס
        public static bool UpdateStatus(int id, string status)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {

                    var c = db.Rentals.FirstOrDefault(p => p.rent_id== id);
                    c.Payment_status = status;
                    db.SaveChanges();
                    return true;

                }
            }
            catch
            {
                return false;
            }

        }

        //מחיקת השכרה
        public static bool RemoveRental(int rentId)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var e = db.Rentals.FirstOrDefault(p => p.rent_id == rentId);
                    if(e!= null)
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


        //עדכון מחיר השכרה
        public static bool updateRentalPrice(int rentId, int price)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var e = db.Rentals.FirstOrDefault(p => p.rent_id == rentId);
                    if (e != null)
                    {
                        e.price -=price;
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

        //שליפת שמות משכירים
        public static List<string> getRentalName()
        {
            try
            {

                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    List<string> RentalNames = new List<string>();

                    var rental = db.Rentals.Where(p => p.status == "פעיל").ToList();
                    foreach (var c in rental)
                    {
                        var cust = db.customers.FirstOrDefault(p => c.cust_id == p.cust_id);
                        if (cust != null)
                            RentalNames.Add(cust.first_name + " " + cust.last_name);
                    }
                    return RentalNames;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }



    }
}
