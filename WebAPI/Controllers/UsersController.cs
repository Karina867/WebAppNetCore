using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class UsersController : ApiController
    {
        public List<Users> Get()
        {
            return UserData.GetList();
        }
        public Users Get(int id)
        {
            return UserData.Get(id);
        }

        public bool Post([FromBody]  Users users)
        {
            return UserData.Add(users);
        }

        public bool Put([FromBody] Users users)
        {
            return UserData.Edit(users);
        }

        public bool Patch(int user)
        {
            return UserData.Delete(user);
        }
    }
}
