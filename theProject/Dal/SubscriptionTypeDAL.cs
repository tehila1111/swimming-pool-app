using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class SubscriptionTypeDAL
    {
        //שליפת כל טבלת סוגי המנויים
        public static List<Subscription_type> GetAllSubsType()
        {
            try
            {

                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.Subscription_type.ToList();
                    return t;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }
        //שליפה לפי ID
        public static List<string> GetSubTypeById()
        {
            try
            {

                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    List<string> typeName = new List<string>();

                    var t = db.Subscribed_customers.ToList();
                    foreach (var item in t)
                    {
                        var name = db.Subscription_type.FirstOrDefault(p => item.Subscription_type == p.Subscription_type_id);
                        if (name != null)
                            typeName.Add(name.type);
                    }
                    return typeName;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }



        //הוספת סוג מנוי

        public static bool AddNewSubsType(Subscription_type e)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    db.Subscription_type.Add(e);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }



        //מחיקת סוג מנוי

        public static bool RemoveSubsType(int typeID)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var c = db.Subscription_type.FirstOrDefault(p => p.Subscription_type_id == typeID);
                    if (c != null)
                    {
                        db.Subscription_type.Remove(c);
                        db.SaveChanges();
                        return true;
                    }
                    else
                        return false;

                }
            }
            catch (Exception e)

            {
                return false;
            }

        }


        //עדכון סוג מנוי
        public static bool UpdateSubsType(Subscription_type s)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var c = db.Subscription_type.FirstOrDefault(p => p.Subscription_type_id == s.Subscription_type_id);
                    //c.Subscription_type_id = s.Subscription_type_id;
                    c.type = s.type;
                    c.Num_of_entrances = s.Num_of_entrances;
                    c.price = s.price;
                    c.status = s.status;
                    db.SaveChanges();
                    return true;

                }
            }
            catch
            {
                return false;
            }

        }


       

        public static Subscription_type GetTypeById(int type)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.Subscription_type.FirstOrDefault(p => p.Subscription_type_id == type);
                    return t;
                }
            }
           


            catch (Exception e)
            {
                throw;    //לבדוק אם -1 או משהו אחר
            }
        }
    }

   


}

