using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
namespace Dto
{
    public class BusinessDetailsDto
    {
        public string BusinessName { get; set; }
        public string address { get; set; }
        public string rentDay { get; set; }
        public int rentPrice { get; set; }
        public TimeSpan RentStartHour { get; set; }
        public TimeSpan RentEndHour { get; set; }

        public BusinessDetailsDto()
        {

        }
        public BusinessDetailsDto(string businessName, string address, string rentDay, int rentPrice, TimeSpan rentStartHour, TimeSpan rentEndHour)
        {
            this.BusinessName = businessName;
            this.address = address;
            this.rentDay = rentDay;
            this.rentPrice = rentPrice;
            this.RentStartHour = rentStartHour;
            this.RentEndHour = rentEndHour;
        }
    
        //פונקצית המרת אוביקט שלנו לשל מיקרוסופט - משמש בהוספת אוביקט חדש למסד
        public static BusinessDetails toTBL(BusinessDetailsDto mc)
        {
            BusinessDetails newDetail = new BusinessDetails();
            newDetail.BusinessName = mc.BusinessName;
            newDetail.address = mc.address;
            newDetail.rentDay = mc.rentDay;
            newDetail.rentPrice = mc.rentPrice;
            newDetail.RentStartHour = mc.RentStartHour;
            newDetail.RentEndHour = mc.RentEndHour;



            return newDetail;
        }


        //פונקצית המרת אוביקט מיקרוסופט  לשלנו- משמש בשליפת אוביקט 
        public static BusinessDetailsDto toDTO(BusinessDetails mc)
        {
            BusinessDetailsDto newDetail = new BusinessDetailsDto();
            newDetail.BusinessName = mc.BusinessName;
            newDetail.address = mc.address;
            newDetail.rentDay = mc.rentDay;
            newDetail.rentPrice = (int)mc.rentPrice;
            newDetail.RentStartHour = (TimeSpan)mc.RentStartHour;
            newDetail.RentEndHour = (TimeSpan)mc.RentEndHour;



            return newDetail;
        }




        //המרת אוסף ממיקרוסופט לשלנו
        public static List<BusinessDetailsDto> toDTO_List(List<BusinessDetails> ee)
        {
            List<BusinessDetailsDto> eList = new List<BusinessDetailsDto>();
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
        public static List<BusinessDetails> toTBL_List(List<BusinessDetailsDto> ee)
        {
            List<BusinessDetails> eList = new List<BusinessDetails>();
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

