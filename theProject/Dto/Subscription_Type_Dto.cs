using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;

namespace Dto
{
    public class Subscription_Type_Dto
    {
        public int Subscription_type_id { get; set; }
        public string type { get; set; }
        public int Num_of_entrances { get; set; }
        public int price { get; set; }
        public string status { get; set; }

        public Subscription_Type_Dto()
        {

        }
        public Subscription_Type_Dto( string type, int Num_of_entrances, int price, string status)
        {
           
            this.type = type;
            this.Num_of_entrances = Num_of_entrances;
            this.price = price;
            this.status = status;

        }

        public Subscription_Type_Dto(int id,string type, int Num_of_entrances, int price, string status)
        {
            this.Subscription_type_id = id;
            this.type = type;
            this.Num_of_entrances = Num_of_entrances;
            this.price = price;
            this.status = status;

        }
        //פונקצית המרת אוביקט שלנו לשל מיקרוסופט - משמש בהוספת אוביקט חדש למסד
        public static Subscription_type toSubsTypeTBL(Subscription_Type_Dto mc)
        {
            Subscription_type newSType = new Subscription_type();
            newSType.Subscription_type_id = mc.Subscription_type_id;
            newSType.type = mc.type;
            newSType.Num_of_entrances = mc.Num_of_entrances;
            newSType.price = mc.price;
            newSType.status = mc.status;


            return newSType;
        }


        //פונקצית המרת אוביקט מיקרוסופט  לשלנו- משמש בשליפת אוביקט 
        public static Subscription_Type_Dto toSubsTypeDTO(Subscription_type cc)
        {
            Subscription_Type_Dto newSType = new Subscription_Type_Dto();
            newSType.Subscription_type_id = cc.Subscription_type_id;
            newSType.type = cc.type;
            newSType.Num_of_entrances = (int)cc.Num_of_entrances;
            newSType.price = (int)cc.price;
            newSType.status = cc.status;
            return newSType;



        }







        //המרת אוסף ממיקרוסופט לשלנו
        public static List<Subscription_Type_Dto> toDTO_List(List<Subscription_type> ee)
        {
            List<Subscription_Type_Dto> eList = new List<Subscription_Type_Dto>();
            try
            {
                foreach (var item in ee)
                {
                    eList.Add(toSubsTypeDTO(item));
                }
                return eList;
            }
            catch (Exception e)
            {
                return null;
            }


        }
        //המרת אוסף  שלנו לשל מיקרוסופט
        public static List<Subscription_type> toTBL_List(List<Subscription_Type_Dto> ee)
        {
            List<Subscription_type> eList = new List<Subscription_type>();
            try
            {
                foreach (var item in ee)
                {
                    eList.Add(toSubsTypeTBL(item));
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

