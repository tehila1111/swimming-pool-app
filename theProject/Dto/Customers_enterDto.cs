using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;

namespace Dto
{
     public class Customers_enterDto
    {

        public int  enter_id { get; set; }
        public int Subscription_id { get; set ; }
        public DateTime date { get; set; }
        public int work_shift_id { get; set; }


        public Customers_enterDto()
        {
                
        }
        public Customers_enterDto(int Subscription_id,int work_shift_id)
        {
          
            this.Subscription_id = Subscription_id;           
            this.date = DateTime.Today;
            this.work_shift_id = work_shift_id;
        }

      


        //פונקצית המרת אוביקט שלנו לשל מיקרוסופט - משמש בהוספת אוביקט חדש למסד
        public static Customers_enter toCustomersEnterTBL(Customers_enterDto mc)
            {
            Customers_enter newCustEnter = new Customers_enter();
            newCustEnter.enter_id = mc.enter_id;           
            newCustEnter.Subscription_id = mc.Subscription_id;            
            newCustEnter.date = mc.date;
            newCustEnter.work_shift_id = mc.work_shift_id;
            return newCustEnter;
            }


            //פונקצית המרת אוביקט מיקרוסופט  לשלנו- משמש בשליפת אוביקט 
            public static Customers_enterDto toCustomersEnterDTO(Customers_enter cc)
            {
            Customers_enterDto newCustEnter = new Customers_enterDto();
            newCustEnter.enter_id = cc.enter_id;
            newCustEnter.Subscription_id = (int)cc.Subscription_id;
            newCustEnter.date = (DateTime)cc.date;
            newCustEnter.work_shift_id = (int)cc.work_shift_id;


            return newCustEnter;
            }


        //המרת אוסף ממיקרוסופט לשלנו
        public static List<Customers_enterDto> toDTO_List(List<Customers_enter> ee)
        {
            List<Customers_enterDto> eList = new List<Customers_enterDto>();
            try
            {
                foreach (var item in ee)
                {
                    eList.Add(toCustomersEnterDTO(item));
                }
                return eList;
            }
            catch (Exception e)
            {
                return null;
            }


        }
        //המרת אוסף  שלנו לשל מיקרוסופט
        public static List<Customers_enter> toTBL_List(List<Customers_enterDto> ee)
        {
            List<Customers_enter> eList = new List<Customers_enter>();
            try
            {
                foreach (var item in ee)
                {
                    eList.Add(toCustomersEnterTBL(item));
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
