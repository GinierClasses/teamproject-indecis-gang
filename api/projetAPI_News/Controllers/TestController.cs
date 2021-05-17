﻿using System;
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
        public IEnumerable<string> Get()
        {
            
            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM t_user"))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        System.Diagnostics.Debug.WriteLine(cmd);
                    }
                }
                
            }
            
            return new string[] { "value1", "value2" };
        }

        // GET api/test/5
        public string Get(int id)
        {
            System.Diagnostics.Debug.WriteLine(id);
            return "valueTest";
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
