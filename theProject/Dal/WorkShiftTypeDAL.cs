using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class WorkShiftTypeDAL
    {


        //שליפת סוגי המשמרות

        public static List<work_shift_type> GetAllWorkShiftType()
        {
            try
            {

                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.work_shift_type.ToList();
                    return t;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }

        //הוספת סוג משמרת

        public static bool AddNewWorkShType(work_shift_type e)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    db.work_shift_type.Add(e);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }

        //מחיקת סוג משמרת
        public static bool RemoveWorkShiType(int WorkShiType)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var e = db.work_shift_type.FirstOrDefault(p => p.shift_id == WorkShiType);
                    if(e!=null)
                    {
                        db.work_shift_type.Remove(e);
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



        //עדכון סוג משמרת
        public static bool UpdateWorkShiType(work_shift_type wst)
        {
            try
            {
                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var e = db.work_shift_type.FirstOrDefault(p => p.shift_id == wst.shift_id);
                    if (e != null)
                    {
                        e.shift_id=wst.shift_id;    
                        e.start_hour=wst.start_hour;
                        e.end_hour=wst.end_hour;    
                        e.name=wst.name;    
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

        public static List<string> getShiftName()
        {
            try
            {

                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    List<string> ShiftNames = new List<string>();

                    var open = db.open_days.ToList();
                    foreach (var c in open)
                    {
                        var workShift = db.work_shift_type.FirstOrDefault(p => c.shift_id == p.shift_id);
                        if (workShift != null)
                            ShiftNames.Add(workShift.name);
                    }
                    return ShiftNames;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }


    }
}
