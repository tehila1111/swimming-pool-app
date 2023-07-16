using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bll
{
    public class OtherEnterBll
    {
        //שליפת כל הכניסות
        public static List<OtherEnterDto> GetAllEnter()
        {
            return OtherEnterDto.toDTO_List(OtherEnterDal.GetAllOtherEnter());
        }      


        //הוספת כניסת לקוח מזדמן
        public static bool AddNewEnter(OtherEnterDto o)
        {
            return OtherEnterDal.AddNewEnter(OtherEnterDto.toTBL(o));
        }



        //מחיקת כניסת לקוח מזדמן
        public static bool RemoveEnter(int EnterId)
        {
            return OtherEnterDal.RemoveEnter(EnterId);
        }

        //שליפת כל שמות המשמרות לתצוגה בטבלת כניסות
        public static List<string> getOtherShiftsName()
        {
            try
            {
                return OtherEnterDal.getOtherShiftsName();
            }
            catch
            {
                throw;
            }
        }


    }
}
