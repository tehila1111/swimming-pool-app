using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bll
{

    public class OpenDaysBLL
    {
        //שליפת כל ימי הפתיחה
        public static List<Open_Days_Dto> GetAllOpenDays()
        {
            return Open_Days_Dto.toDTO_List(OpenDateDal.GetAllOpenDays());
        }


        //הוספת יום פתיחה
        public static bool AddOpen(int shift_id, string day, string gender, string status)
        {

            Open_Days_Dto o = new Open_Days_Dto(shift_id, day, gender, status);
            return OpenDateDal.AddNewOpen(Open_Days_Dto.toOpenDTBL(o));
        }

        //מחיקת יום פתיחה
        public static bool RemoveOpen(int openId)
        {
            return OpenDateDal.RemoveOpen(openId);
        }

        ////החזרת ימי פתיחה לפי יום מסוים
        //public static List<Open_Days_Dto> GetOpenByDay(string day)
        //{
        //    return Open_Days_Dto.toDTO_List(OpenDateDal.GetOpenDay(day));
        //}

        //עדכון יום פתיחה
        public static bool UpdateOpenDay(Open_Days_Dto c)
        {
            return OpenDateDal.UpdateOpenDay(Open_Days_Dto.toOpenDTBL(c));
        }


        //קבלת יום הפתיחה הנוכחי
        public static Open_Days_Dto GetCurrentOpen()
        {
            string[] days = { "ראשון", "שני", "שלישי", "רביעי", "חמישי", "שישי", "שבת" };
            int day = (int)DateTime.Now.DayOfWeek;
            string today = days[day];
            TimeSpan time = DateTime.Now.TimeOfDay;
            List<Open_Days_Dto> openDays = GetAllOpenDays().Where(p => p.day == today).ToList();
            List<Work_ShiftType_Dto> shifts = WorkShiftTypeBLL.GetAllWorkSType().Where(p => p.start_hour <= time && p.end_hour > time).ToList();
            foreach (var s in shifts)
            {
                var shiftId = s.shift_id;
                var obj = openDays.FirstOrDefault(p => p.shift_id == shiftId);
                if (obj != null)
                    return obj;
            }
            return null;

        }

    }
}
