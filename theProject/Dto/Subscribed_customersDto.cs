using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;

namespace Dto
{
     public class Subscribed_customersDto
    {


        public int Subscription_id { get; set; }
        public int cust_id { get; set; }
        public int Subscription_type { get; set; }
        public DateTime start_date { get; set; }
        public int sum_of_entries { get; set; }
        public string status { get; set; }

        public Subscribed_customersDto()
        {

        }
        public Subscribed_customersDto( int cust_id, int Subscription_type, int sum_of_entries, string status)
        {
           
            this.cust_id = cust_id;
            this.Subscription_type = Subscription_type;
            this.start_date = DateTime.Today;
            this.sum_of_entries = sum_of_entries;
            this.status = status;
        }

        //פונקצית המרת אוביקט שלנו לשל מיקרוסופט - משמש בהוספת אוביקט חדש למסד
        public static Subscribed_customers toSubCustTBL(Subscribed_customersDto mc)
        {
            Subscribed_customers newSubCust = new Subscribed_customers();
            newSubCust.Subscription_id = mc.Subscription_id;
            newSubCust.cust_id = mc.cust_id;
            newSubCust.Subscription_type = mc.Subscription_type;
            newSubCust.start_date = mc.start_date;
            newSubCust.sum_of_entries = mc.sum_of_entries;
            newSubCust.status = mc.status;


            return newSubCust;
        }


        //פונקצית המרת אוביקט מיקרוסופט  לשלנו- משמש בשליפת אוביקט 
        public static Subscribed_customersDto toSubCustDTO(Subscribed_customers cc)
        {
            Subscribed_customersDto newSubCust = new Subscribed_customersDto();
            newSubCust.Subscription_id = cc.Subscription_id;
            newSubCust.cust_id = (int)cc.cust_id;
            newSubCust.Subscription_type = (int)cc.Subscription_type;
            newSubCust.start_date = (DateTime)cc.start_date;
            newSubCust.sum_of_entries = (int)cc.sum_of_entries;
            newSubCust.status = cc.status;



            return newSubCust;
        }

        //המרת אוסף ממיקרוסופט לשלנו
        public static List<Subscribed_customersDto> toDTO_List(List<Subscribed_customers> ee)
        {
            List<Subscribed_customersDto> eList = new List<Subscribed_customersDto>();
            try
            {
                foreach (var item in ee)
                {
                    eList.Add(toSubCustDTO(item));
                }
                return eList;
            }
            catch (Exception e)
            {
                return null;
            }


        }
        //המרת אוסף  שלנו לשל מיקרוסופט
        public static List<Subscribed_customers> toTBL_List(List<Subscribed_customersDto> ee)
        {
            List<Subscribed_customers> eList = new List<Subscribed_customers>();
            try
            {
                foreach (var item in ee)
                {
                    eList.Add(toSubCustTBL(item));
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
