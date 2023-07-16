using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;

namespace Dto
{
     public class Open_Days_Dto
    {

        public int open_id { get; set; }
        public int shift_id { get; set; }
        public string day { get; set; }
        public string gender { get; set; }
        public string status { get; set; }


        public Open_Days_Dto()
        {

        }
        public Open_Days_Dto(int shift_id, string day, string gender, string status)
        {
           
            this.shift_id = shift_id;
            this.day = day;
            this.gender = gender;
            this.status = status;
        }
       
        //פונקצית המרת אוביקט שלנו לשל מיקרוסופט - משמש בהוספת אוביקט חדש למסד
        public static open_days toOpenDTBL(Open_Days_Dto mc)
        {
            open_days newOpen = new open_days();
            newOpen.open_id = mc.open_id;
            newOpen.shift_id = mc.shift_id;
            newOpen.day = mc.day;
            newOpen.gender = mc.gender;
            newOpen.status = mc.status;
           

            return newOpen;
        }


        //פונקצית המרת אוביקט מיקרוסופט  לשלנו- משמש בשליפת אוביקט 
        public static Open_Days_Dto toOpenDDTO(open_days cc)
        {
            if(cc!=null)
            {
                Open_Days_Dto newOpen = new Open_Days_Dto();
                newOpen.open_id = cc.open_id;
                newOpen.shift_id = (int)cc.shift_id;
                newOpen.day = cc.day;
                newOpen.gender = cc.gender;
                newOpen.status = cc.status;

                return newOpen;
            }
            else
                return null;
        }




        //המרת אוסף ממיקרוסופט לשלנו
        public static List<Open_Days_Dto> toDTO_List(List<open_days> ee)
        {
            List<Open_Days_Dto> eList = new List<Open_Days_Dto>();
            try
            {
                foreach (var item in ee)
                {
                    eList.Add(toOpenDDTO(item));
                }
                return eList;
            }
            catch (Exception e)
            {
                return null;
            }


        }
        //המרת אוסף  שלנו לשל מיקרוסופט
        public static List<open_days> toTBL_List(List<Open_Days_Dto> ee)
        {
            List<open_days> eList = new List<open_days>();
            try
            {
                foreach (var item in ee)
                {
                    eList.Add(toOpenDTBL(item));
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
