using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace projetAPI_News.Controllers
{
    public class TestController : ApiController
    {
        // GET api/values
        public Models.User Get()
        {
            return Models.UsersModel.GetUserInfos();
        }

        // GET api/test/5
        public Models.Author Get(int id)
        {
            System.Diagnostics.Debug.WriteLine(id);

            //Models.UsersModel.SetUserInfos();
            //return Models.UsersModel.GetUserInfos();
            return Models.AuthorModel.GetAuthorInfos();
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
            value = id.ToString();
            Models.UsersModel.CreateUser(value);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
