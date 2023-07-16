using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class CustomersDal
    {
        //שליפת כל הלקוחות הפעילים
        public static List<customers> GetAllCustomers()
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.customers.Where(p => p.archive == "פעיל").ToList();
                    return t;
                }
            }

            catch (Exception e)
            {
                return null;

            }


        }

        //שליפת כל לקוחות הארכיון

        public static List<customers> GetArchiveCustomers()
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.customers.Where(p => p.archive == "לא פעיל").ToList();
                    return t;
                }
            }

            catch (Exception e)
            {
                return null;

            }


        }
        //בדיקה האם הלקוח קיים עם כל הפרטים זהים
        public static customers ifExist(customers e)
        {

            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var exist=db.customers.FirstOrDefault(p=>p.first_name==e.first_name&&p.last_name==e.last_name&&p.birthdate==e.birthdate&&p.telephone==e.telephone);
                    if (exist != null)
                        return exist;
                    else
                        return null;
                }
            }
            catch
            {
                return null;
            }
        }



        //הוספת לקוח
        public static bool AddNewCust(customers e)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    db.customers.Add(e);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }




        //עדכון לקוח
        public static bool UpdateCust(customers c)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.customers.FirstOrDefault(p => p.cust_id == c.cust_id);

                    t.first_name = c.first_name;
                    t.last_name = c.last_name;
                    t.telephone = c.telephone;
                    t.email = c.email;
                    t.gender = c.gender;
                    t.birthdate = c.birthdate;
                    db.SaveChanges();
                    return true;

                }
            }
            catch
            {
                return false;
            }

        }

        


      

        //שליפת לקוח לפי קוד לקוח
        public static customers GetCustByID(int id)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.customers.FirstOrDefault(p => p.cust_id == id);
                    return t;
                }
            }

            catch
            {

                return null;

            }


        }
      


        //עדכון ארכיון לפעיל או ללא פעיל
        public static bool updateArchiveStatus(int id,string action) 
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var cust = db.customers.FirstOrDefault(p => p.cust_id == id);
                    cust.archive = action;
                    db.SaveChanges();
                    return true;

                }
            }
            catch
            {
                return false;
            }
        }


        public static List<string> GetSubNamsById()
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    List<string> subNames = new List<string>();

                    var subs = db.Subscribed_customers.Where(p => p.status == "פעיל").ToList();
                    foreach (var c in subs)
                    {
                        var customers = db.customers.FirstOrDefault(p => c.cust_id == p.cust_id);
                        if (customers != null)
                            subNames.Add(customers.first_name + " " + customers.last_name);
                    }
                    return subNames;
                }
            }
            catch
            {
                return null;
            }
        }

    }
}
