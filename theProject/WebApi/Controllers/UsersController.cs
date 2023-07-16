using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using Bll;
using Dto;

namespace WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        // GET: api/Users
        public List<usersDto> GetAll()
        {
            return usersBll.GetAllUsers();
        }

        // GET: api/Users/5
       
        public usersDto Get(string psd)
        {
            return usersBll.GetByPsd(psd);

        }




        // POST: api/Users
        public bool Post(usersDto u)
        {
            return usersBll.AddUser(u);
        }

        // PUT: api/Users/5
        public bool Put(usersDto u)
        {
            return usersBll.UpdateUser(u);
        }

        // DELETE: api/Users/5
        public bool Delete(int id)
        {
             return usersBll.DeleteUser(id);
        }
    }
}
