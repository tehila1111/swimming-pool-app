using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class usersDto
    {


        public int userId { get; set; }
        public string userName { get; set; }
        public string position { get; set; }
        public string password { get; set; }


        public usersDto(string userName, string position, string password)
        {
            
            this.userName = userName;
            this.position = position;
            this.password = password;
        }  
        public usersDto()
        {

        }

        //פונקצית המרת אוביקט שלנו לשל מיקרוסופט - משמש בהוספת אוביקט חדש למסד
        public static users toTBL(usersDto mc)
        {
            users newUser = new users();
            newUser.userId = mc.userId;    
            newUser.userName = mc.userName;
            newUser.position = mc.position;
            newUser.password = mc.password;


            return newUser;
        }


        //פונקצית המרת אוביקט מיקרוסופט  לשלנו- משמש בשליפת אוביקט 
        public static usersDto toDTO(users mc)
        {
            if(mc!=null)
            {
                usersDto newUser = new usersDto();
                newUser.userId = mc.userId;
                newUser.userName = mc.userName;
                newUser.position = mc.position;
                newUser.password = mc.password;


                return newUser;

            }
           else
                return null;    

        }




        //המרת אוסף ממיקרוסופט לשלנו
        public static List<usersDto> toDTO_List(List<users> ee)
        {
            List<usersDto> eList = new List<usersDto>();
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
        public static List<users> toTBL_List(List<usersDto> ee)
        {
            List<users> eList = new List<users>();
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
