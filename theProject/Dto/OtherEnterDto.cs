using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;

namespace Dto
{
    public class OtherEnterDto
    {

        public int other_enter { get; set; }
        public DateTime date { get; set; }
        public int work_shift_id { get; set; }



        public OtherEnterDto()
        {
                
        }

        public OtherEnterDto(int work_shift_id)
        {
           
            this.date = DateTime.Today;
            this.work_shift_id = work_shift_id;
        }




        //פונקצית המרת אוביקט שלנו לשל מיקרוסופט - משמש בהוספת אוביקט חדש למסד
        public static otherEnter toTBL(OtherEnterDto mc)
        {
            otherEnter newEnter = new otherEnter();
            newEnter.other_enter = mc.other_enter;
            newEnter.date = mc.date;
            newEnter.work_shift_id = mc.work_shift_id;
            
            return newEnter;
        }


        //פונקצית המרת אוביקט מיקרוסופט  לשלנו- משמש בשליפת אוביקט 
        public static OtherEnterDto toDTO(otherEnter cc)
        {
            OtherEnterDto newEnter = new OtherEnterDto();
            newEnter.other_enter = cc.other_enter;
            newEnter.date = cc.date;
            newEnter.work_shift_id = cc.work_shift_id;
            return newEnter;

        }




        //המרת אוסף ממיקרוסופט לשלנו
        public static List<OtherEnterDto> toDTO_List(List<otherEnter> ee)
        {
            List<OtherEnterDto> eList = new List<OtherEnterDto>();
            try
            {
                foreach (var item in ee)
                {
                    eList.Add(toDTO(item));
                }
                return eList;
            }
            catch (Exception e)
            {
                return null;
            }


        }
        //המרת אוסף  שלנו לשל מיקרוסופט
        public static List<otherEnter> toTBL_List(List<OtherEnterDto> ee)
        {
            List<otherEnter> eList = new List<otherEnter>();
            try
            {
                foreach (var item in ee)
                {
                    eList.Add(toTBL(item));
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
