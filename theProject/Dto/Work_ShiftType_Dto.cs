using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;


namespace Dto
{
    public class Work_ShiftType_Dto
    {


        public int shift_id { get; set; }
        public string name { get; set; }
        public TimeSpan start_hour { get; set; }
        public TimeSpan end_hour { get; set; }


        public Work_ShiftType_Dto()
        {

        }
        public Work_ShiftType_Dto( string name, TimeSpan start_hour, TimeSpan end_hour)
        {
            
            this.name = name;
            this.start_hour = start_hour;
            this.end_hour = end_hour;
        }
        //פונקצית המרת אוביקט שלנו לשל מיקרוסופט - משמש בהוספת אוביקט חדש למסד
        public static work_shift_type toWorkShTypeTBL(Work_ShiftType_Dto mc)
        {
            work_shift_type newWshiftType = new work_shift_type();
            newWshiftType.shift_id = mc.shift_id;
            newWshiftType.name = mc.name;
            newWshiftType.start_hour = mc.start_hour;
            newWshiftType.end_hour = mc.end_hour;


            return newWshiftType;
        }


        //פונקצית המרת אוביקט מיקרוסופט  לשלנו- משמש בשליפת אוביקט 
        public static Work_ShiftType_Dto toWorkShTypeDTO(work_shift_type cc)
        {
            Work_ShiftType_Dto newWshiftType = new Work_ShiftType_Dto();
            newWshiftType.shift_id = cc.shift_id;
            newWshiftType.name = cc.name;
            newWshiftType.start_hour =cc.start_hour;
            newWshiftType.end_hour = cc.end_hour;

            return newWshiftType;

        }



        //המרת אוסף ממיקרוסופט לשלנו
        public static List<Work_ShiftType_Dto> toDTO_List(List<work_shift_type> ee)
        {
            List<Work_ShiftType_Dto> eList = new List<Work_ShiftType_Dto>();
            try
            {
                foreach (var item in ee)
                {
                    eList.Add(toWorkShTypeDTO(item));
                }
                return eList;
            }
            catch (Exception e)
            {
                return null;
            }


        }
        //המרת אוסף  שלנו לשל מיקרוסופט
        public static List<work_shift_type> toTBL_List(List<Work_ShiftType_Dto> ee)
        {
            List<work_shift_type> eList = new List<work_shift_type>();
            try
            {
                foreach (var item in ee)
                {
                    eList.Add(toWorkShTypeTBL(item));
                }
                return eList;
            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}
