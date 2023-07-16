using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bll
{


    public class WorkShiftTypeBLL
    {
        //החזרת כל סוגי המשמרות
        public static List<Work_ShiftType_Dto> GetAllWorkSType()
        {
            return Work_ShiftType_Dto.toDTO_List(WorkShiftTypeDAL.GetAllWorkShiftType());
        }

        // הוספת משמרת 
        public static bool AddWorkSType(string name, TimeSpan start_hour, TimeSpan end_hour)
        {
            Work_ShiftType_Dto w = new Work_ShiftType_Dto(name, start_hour, end_hour);
            return WorkShiftTypeDAL.AddNewWorkShType(Work_ShiftType_Dto.toWorkShTypeTBL(w));
        }

        // מחיקת משמרת 
        public static bool RemoveWSType(int shiftTypeID)
        {
            return WorkShiftTypeDAL.RemoveWorkShiType(shiftTypeID);
        }

        //עדכון סוג משמרת
        public static bool UpdateWorkShiType(Work_ShiftType_Dto wst)
        {
            return WorkShiftTypeDAL.UpdateWorkShiType(Work_ShiftType_Dto.toWorkShTypeTBL(wst));
        }



        public static List<string> getShiftName()
        {
            return WorkShiftTypeDAL.getShiftName();
        }
    }
}
