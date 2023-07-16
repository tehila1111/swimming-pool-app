using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Dal;

namespace Bll
{
    public class rentals_detailsBLL
    {
        //הצגת כל פרטי ההשכרות
        public static List<rentals_detailsDto> GetAllRentDetails()
        {
            return rentals_detailsDto.toDTO_List(rentals_detailsDal.GetAllRentals_details());
        }



        //הצגת פרטי השכרה לפי קוד השכרה
        public static List<rentals_detailsDto> GetRentDetByReId(int id)
        {
            return rentals_detailsDto.toDTO_List(rentals_detailsDal.GetRentDetailByReId(id));
        }


        //שליפת כל תאריכי ההשכרה הפנויים
        public static List<DateTime> freeDates()
        {
            string[] dayArr = { "ראשון", "שני", "שלישי", "רביעי", "חמישי", "שישי" };
            int day = (int)DateTime.Now.DayOfWeek;
            var rentDay = BusinessDetailsDal.GetRentDay();
            var rentDayIndex = 0;
            for (int i = 0; i < 6; i++)
            {
                if (rentDay == dayArr[i])
                {
                    rentDayIndex = i;
                    break;
                }

            }

            DateTime date = DateTime.Today;
            if (day != rentDayIndex)
            {
                if (day < rentDayIndex)
                    date = date.AddDays(rentDayIndex - day);
                else
                {
                    var sub = day - rentDayIndex;
                    date = date.AddDays(7 - sub);
                }


            }

            List<DateTime> allDates = new List<DateTime>();

            var fexist = rentals_detailsDal.GetByDate(date);
            if (fexist == null)
                allDates.Add(date);
            for (int i = 0; i < 4 * 12; i++)
            {
                date = date.AddDays(7);
                var exist = rentals_detailsDal.GetByDate(date);
                if (exist == null)
                    allDates.Add(date);

            }
            return allDates;
        }



        //הוספת פרטי השכרה
        public static bool AddRentDetails(List<DateTime> c)
        {
            var rentId = rentals_detailsDal.LastRentId();
            foreach (DateTime item in c)
            {

                rentals_detailsDto rent = new rentals_detailsDto(rentId, item, "פעיל");
                rentals_detailsDal.AddRentalDetails(rentals_detailsDto.toRentalDetailsTBL(rent));
            }
            return true;
        }

      //מחיקת פרטי השכרה לפי קוד פרטי השכרה
        public static bool RemoveRentDetails(int id)

        {
            List<Rentals_Dto> rentals=RentalsBLL.GetAllRentals();
            var rentDet=rentals_detailsDal.GetRentDetById(id);
            var rentId = rentDet.rent_id;
            var rentPrice = RentalsBLL.getRentPrice();
            RentalsDal.updateRentalPrice(rentId, rentPrice);
            return rentals_detailsDal.RemoveRentalDetails(id);

        }

        //הצגת שמות השכרות
        public static List<string> getRentalDetName()
        {

            try
            {
                return rentals_detailsDal.getRentalDetName();
            }
            catch
            {
                throw;
            }
        }
    }
}
