using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;

namespace Dto
{
    public class customers_Dto
    {


        public int cust_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string telephone { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string status { get; set; }
        public DateTime birthdate { get; set; }
        public string archive { get; set; }
        public customers_Dto()
        {

        }
        public customers_Dto(string first_name, string last_name, string telephone, string email, string gender, string status, DateTime birthdate, string archive)
        {

            this.first_name = first_name;
            this.last_name = last_name;
            this.telephone = telephone;
            this.email = email;
            this.gender = gender;
            this.status = status;
            this.birthdate = birthdate;
            this.archive = archive; 
        }
        public customers_Dto( int cust_id,string first_name, string last_name, string telephone, string email, string gender, DateTime birthdate,string archive)
        {
            this.cust_id = cust_id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.telephone = telephone;
            this.email = email;
            this.gender = gender;
            this.birthdate = birthdate;
            this.archive = archive;
        }
       

        //פונקצית המרת אוביקט שלנו לשל מיקרוסופט - משמש בהוספת אוביקט חדש למסד
        public static customers toCustTBL(customers_Dto mc)
        {
            customers newCust = new customers();
            newCust.cust_id = mc.cust_id;
            newCust.first_name = mc.first_name;
            newCust.last_name = mc.last_name;
            newCust.telephone = mc.telephone;
            newCust.email = mc.email;
            newCust.gender = mc.gender;
            newCust.status = mc.status;
            newCust.birthdate = mc.birthdate;
            newCust.archive=mc.archive;
            return newCust;
        }


        //פונקצית המרת אוביקט מיקרוסופט  לשלנו- משמש בשליפת אוביקט 
        public static customers_Dto toCustDTO(customers cc)
        {
            if(cc!=null)
            {
                customers_Dto newCust = new customers_Dto();
                newCust.cust_id = cc.cust_id;
                newCust.first_name = cc.first_name;
                newCust.last_name = cc.last_name;
                newCust.telephone = cc.telephone;
                newCust.email = cc.email;
                newCust.gender = cc.gender;
                newCust.status = cc.status;
                newCust.birthdate = (DateTime)cc.birthdate;
                newCust.archive = cc.archive;

                return newCust;
            }
            else
                return null;    
            
        }




        //המרת אוסף ממיקרוסופט לשלנו
        public static List<customers_Dto> toDTO_List(List<customers> ee)
        {
            List<customers_Dto> eList = new List<customers_Dto>();
            try
            {
                foreach (var item in ee)
                {
                    eList.Add(toCustDTO(item));
                }
                return eList;
            }
            catch (Exception e)
            {
                return null;
            }


        }
        //המרת אוסף  שלנו לשל מיקרוסופט
        public static List<customers> toTBL_List(List<customers_Dto> ee)
        {
            List<customers> eList = new List<customers>();
            try
            {
                foreach (var item in ee)
                {
                    eList.Add(toCustTBL(item));
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
