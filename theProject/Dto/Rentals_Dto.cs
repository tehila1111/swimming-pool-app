using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;

namespace Dto
{
   public class Rentals_Dto
    {

        public int rent_id { get; set; }
        public int cust_id { get; set; }
        public System.DateTime start_date { get; set; }
        public System.DateTime end_date { get; set; }
        public int price { get; set; }
        public string Payment_status { get; set; }
        public string status { get; set; }

        public Rentals_Dto()
        {
                
        }
        public Rentals_Dto(int cust_id, DateTime start_date, DateTime end_date, int price, string Payment_status,string status)
        {
           
            this.cust_id = cust_id;
            this.start_date = start_date;
            this.end_date = end_date;
            this.price = price;
            this.Payment_status = Payment_status;
            this.status = status;   
        }

     

        //פונקצית המרת אוביקט שלנו לשל מיקרוסופט - משמש בהוספת אוביקט חדש למסד
        public static Rentals toRentalsTBL(Rentals_Dto mc)
        {
            Rentals newRent = new Rentals();
            newRent.rent_id = mc.rent_id;
            newRent.cust_id = mc.cust_id;
            newRent.start_date = mc.start_date;
            newRent.end_date = mc.end_date;
            newRent.price = mc.price;
            newRent.Payment_status = mc.Payment_status;
            newRent.status=mc.status;   
            return newRent;
        }


        //פונקצית המרת אוביקט מיקרוסופט  לשלנו- משמש בשליפת אוביקט 
        public static Rentals_Dto toRentalsDTO(Rentals cc)
        {
            Rentals_Dto newRent = new Rentals_Dto();           
            newRent.rent_id = cc.rent_id;           
            newRent.cust_id = (int)cc.cust_id;
            newRent.start_date = (DateTime)cc.start_date;
            newRent.end_date = (DateTime)cc.end_date;
            newRent.price = (int)cc.price;
            newRent.Payment_status = cc.Payment_status;
            newRent.status=cc.status;   

            return newRent;
        }



        //המרת אוסף ממיקרוסופט לשלנו
        public static List<Rentals_Dto> toDTO_List(List<Rentals> ee)
        {
            List<Rentals_Dto> eList = new List<Rentals_Dto>();
            try
            {
                foreach (var item in ee)
                {
                    eList.Add(toRentalsDTO(item));
                }
                return eList;
            }
            catch (Exception e)
            {
                return null;
            }


        }
        //המרת אוסף  שלנו לשל מיקרוסופט
        public static List<Rentals> toTBL_List(List<Rentals_Dto> ee)
        {
            List<Rentals> eList = new List<Rentals>();
            try
            {
                foreach (var item in ee)
                {
                    eList.Add(toRentalsTBL(item));
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
