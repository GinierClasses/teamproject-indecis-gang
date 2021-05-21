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
    public class FetchController : ApiController
    {
        WebClient webClient = new WebClient();
        // GET api/<controller>


        public String Get()
        {
            string brutRSS = webClient.DownloadString("https://www.tomshardware.fr/feed");
            byte[] bytes = Encoding.Default.GetBytes(brutRSS);
            brutRSS = Encoding.UTF8.GetString(bytes);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(brutRSS);
            string jsonText = JsonConvert.SerializeXmlNode(doc);
            // System.Diagnostics.Debug.WriteLine(jsonText);
            return jsonText;
        }
        // GET api/<controller>/5
        public News Get(int id)
        {
            return new Models.News();
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
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