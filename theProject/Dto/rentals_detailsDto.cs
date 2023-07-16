using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;


namespace Dto
{
    public class rentals_detailsDto
    {

        public int RentalDetails_id { get; set; }
        public int rent_id { get; set; }
        public DateTime date { get; set; }
        public string status { get; set; }




        public rentals_detailsDto()
        {

        }

        public rentals_detailsDto(DateTime date)
        {

            this.date = date;
        
        }
        public rentals_detailsDto(int rent_id, DateTime date, string status)
        {

            this.rent_id = rent_id;
            this.date = date;
            this.status = status;
        }


        //פונקצית המרת אוביקט שלנו לשל מיקרוסופט - משמש בהוספת אוביקט חדש למסד
        public static rentals_details toRentalDetailsTBL(rentals_detailsDto mc)
        {
            rentals_details newRentals_details = new rentals_details();
            newRentals_details.RentalDetails_id = mc.RentalDetails_id;
            newRentals_details.rent_id = mc.rent_id;
            newRentals_details.date = mc.date;
            newRentals_details.status = mc.status;

            return newRentals_details;
        }


        //פונקצית המרת אוביקט מיקרוסופט  לשלנו- משמש בשליפת אוביקט 
        public static rentals_detailsDto toRentals_detailsDto(rentals_details cc)
        {
            rentals_detailsDto newRentals_details = new rentals_detailsDto();
            newRentals_details.RentalDetails_id = cc.RentalDetails_id;
            newRentals_details.rent_id = cc.rent_id;
            newRentals_details.date = cc.date;
            newRentals_details.status = cc.status;


            return newRentals_details;
        }


        //המרת אוסף ממיקרוסופט לשלנו
        public static List<rentals_detailsDto> toDTO_List(List<rentals_details> ee)
        {
            List<rentals_detailsDto> eList = new List<rentals_detailsDto>();
            try
            {
                foreach (var item in ee)
                {
                    eList.Add(toRentals_detailsDto(item));
                }
                return eList;
            }
            catch (Exception e)
            {
                return null;
            }


        }
        //המרת אוסף  שלנו לשל מיקרוסופט
        public static List<rentals_details> toTBL_List(List<rentals_detailsDto> ee)
        {
            List<rentals_details> eList = new List<rentals_details>();
            try
            {
                foreach (var item in ee)
                {
                    eList.Add(toRentalDetailsTBL(item));
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

