using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class usersDal
    {


        //שליפת כל המשתמשים
        public static List<users> GetAllUsers()
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.users.ToList();
                    return t;
                }
            }

            catch (Exception e)
            {
                return null;

            }


        }

        //שליפה לפי סיסמא
        public static users GetByPsd(string psd)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.users.FirstOrDefault(p=>p.password==psd);
                    return t;
                }
            }

            catch (Exception e)
            {
                return null;

            }


        }

       
        //הוספת משתמש
        public static bool AddUser(users u)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.users.Add(u);
                    db.SaveChanges();
                    
                    return true;
                }
            }

            catch (Exception e)
            {
                return false;

            }


        }




        //מחיקת משתמש
        public static bool DeleteUser(int id)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.users.FirstOrDefault(p => p.userId == id);
                    if (t != null)
                    {
                        db.users.Remove(t);
                        db.SaveChanges();
                        return true;

                    }
                    return false;
                }
            }

            catch (Exception e)
            {
                return false;

            }


        }




        //עדכון משתמש
        public static bool UpdateUsers(users u)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.users.FirstOrDefault(p=>p.userId==u.userId);
                    t.userId = u.userId;
                    t.password = u.password;
                    t.userName = u.userName;
                    t.position=u.position;
                    db.SaveChanges();
                    return true;
                }
            }

            catch (Exception e)
            {
                return false;

            }


        }
    }
}
