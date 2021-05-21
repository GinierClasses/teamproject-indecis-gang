using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Xml;
using projetAPI_News.Models;

namespace projetAPI_News.Controllers
{
    public class NewsController : ApiController
    {
        WebClient webClient = new WebClient();
        // GET api/<controller>
        public News Get()
        {
            System.Diagnostics.Debug.WriteLine("toto");
            return NewsModel.GetNewsInfos();
        }
        // GET api/<controller>/5
        public News Get(int id)
        {
            return new Models.News();
        }

        // POST api/<controller>
        public string Post([FromBody] string value)
        {
            return NewsModel.CreateNews("toto", "toto", "toto", "2021-05-05T00:00:00", "toto", "tutu");
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}