using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using projetAPI_News.Models;

namespace projetAPI_News.Controllers
{
    public class UsersController : ApiController
    {
        // GET api/values
        public User Get()
        {
            return UsersModel.GetUserInfos(0);
        }

        // GET api/values/5
        public User Get(int id)
        {
            System.Diagnostics.Debug.WriteLine("TotoGetUser " + id);
            return UsersModel.GetUserInfos(id);
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
