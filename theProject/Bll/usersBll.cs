using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bll
{
    public class usersBll
    {

        //שליפת כל המשתמשים
        public static List<usersDto> GetAllUsers()
        {            
               return usersDto.toDTO_List(usersDal.GetAllUsers());           
        }

        // קבלת משתמש לפי סיסמת משתמש 
        public static usersDto GetByPsd(string psd)
        {
            return usersDto.toDTO(usersDal.GetByPsd(psd));
        }

        //הוספת משתמש
        public static bool AddUser(usersDto u)
        {            
                return usersDal.AddUser(usersDto.toTBL(u));           
        }

        //מחיקת משתמש
        public static bool DeleteUser(int id)
        {            
                return usersDal.DeleteUser(id);         
        }

        //עדכון פרטי משתמש
        public static bool UpdateUser(usersDto b)
        {
            return usersDal.UpdateUsers(usersDto.toTBL(b));
        }
    }
}
