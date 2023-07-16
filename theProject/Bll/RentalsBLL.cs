using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bll
{

    public class RentalsBLL
    {
        // החזרת כל ההשכרות
        public static List<Rentals_Dto> GetAllRentals()
        {
            return Rentals_Dto.toDTO_List(RentalsDal.GetAllRentals());
        }

        //שליפת השכרה לפי מספר לקוח
        public static Rentals_Dto GetRentByCustId(int custId)
        {
            return Rentals_Dto.toRentalsDTO(RentalsDal.GetRentalByCust(custId));
        }


        //שליפת מחיר השכרה
        public static int getRentPrice()
        {
              return BusinessDetailsBll.GetAllDetails()[0].rentPrice;
        }


        //הוספת משכיר
        public static bool AddRent(int cust_id, DateTime start_date, DateTime end_date, int price, string Payment_status, string status)
        {
            Rentals_Dto r = new Rentals_Dto(cust_id, start_date, end_date, price, Payment_status, status);
            return RentalsDal.AddNewRental(Rentals_Dto.toRentalsTBL(r));
        }

        //שליפת השכרה לפי מספר השכרה
        public static Rentals_Dto GetByRentId(int rentID)
        {
            return Rentals_Dto.toRentalsDTO( RentalsDal.GetRentalByRent(rentID ));

        }


        //מחיקת משכיר
        public static bool RemoveRent(int rentID)
        {
            Rentals_Dto rent = GetByRentId(rentID);
            CustomersBLL.updateArchiveStatus(rent.cust_id, "לא פעיל");
            List<rentals_detailsDto> rentDetailsList= rentals_detailsBLL.GetAllRentDetails();
            foreach(var rentDetails in rentDetailsList)
            {
                if (rentDetails.rent_id == rentID && rentDetails.status=="פעיל")
                    rentals_detailsBLL.RemoveRentDetails(rentDetails.RentalDetails_id);
            }
            return RentalsDal.RemoveRental(rentID);
        }

       

        //עדכון סטטוס
        public static bool UpdateStatus(int id, string s)
        {
            return RentalsDal.UpdateStatus(id, s);
        }

        //עדכון סטטוס
        public static bool checkIfCustIsRent(int id)
        {
            return RentalsDal.checkIfCustIsRent(id);
        }




        //שליפת שמות משכירים
        public static List<string> getRentalsName()
        {
            try
            {
                return RentalsDal.getRentalName();
            }
            catch (Exception e)
            {
                throw;
            }
        }










    }
}
