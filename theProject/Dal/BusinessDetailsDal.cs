using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class BusinessDetailsDal
    {

        //שליפת כל הפרטים
        public static List<BusinessDetails> GetAllDetails()
        {
            try
            {

                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                    var t = db.BusinessDetails.ToList();
                    return t;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }




        //עדכון פרטים
        public static bool UpdateDetail(string bussinesName, string address, string day, int price, TimeSpan start, TimeSpan end)
        {
            try
            {
                

                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {
                 
                    var t = db.BusinessDetails.First();              
                    t.BusinessName = bussinesName;
                    t.rentPrice = price;
                    t.rentDay = day;
                    t.RentEndHour = end;
                    t.RentStartHour = start;
                    t.address = address;
             
                    db.SaveChanges();
                    return true;

                }
                
            }

            catch (Exception e)
            {
                return false;
            }
        }

        //יום השכרה
        public static string GetRentDay()
        {
            try
            {

                using (Swimming_PoolEntities db = new Swimming_PoolEntities())
                {

                   string rentDay = db.BusinessDetails.First().rentDay; ;
                    return rentDay;
                }
            }
            catch
            {
                return null;
            }
        }


      

    }

}

