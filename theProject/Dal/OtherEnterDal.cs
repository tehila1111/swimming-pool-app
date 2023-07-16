using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class OtherEnterDal
    {

        public static List<otherEnter> GetAllOtherEnter()
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.otherEnter.ToList();
                    return t;
                }
            }

            catch (Exception e)
            {
                return null;

            }


        }


      


        //הוספת כניסה
        public static bool AddNewEnter(otherEnter e)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    db.otherEnter.Add(e);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }


        public static bool RemoveEnter(int enterId)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var c = db.otherEnter.FirstOrDefault(o => o.other_enter == enterId);
                    if (c != null)
                    {
                        db.otherEnter.Remove(c);
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
        public static List<string> getOtherShiftsName()
        {
            try
            {

                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    List<string> OtherShiftNames = new List<string>();

                    var enter = db.otherEnter.ToList();
                    foreach (var c in enter)
                    {
                        var sub = db.work_shift_type.FirstOrDefault(p => p.shift_id == c.work_shift_id);

                        string name = sub.name;
                        OtherShiftNames.Add(name);

                    }
                    return OtherShiftNames;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
