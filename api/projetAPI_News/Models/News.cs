using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetAPI_News.Models
{
    public class News
    {
        public string NewsTiTle { get; set; }
        public string NewsLink { get; set; }
        public string NewsDate { get; set; }
        public string NewsDescription { get; set; }
        public string fk_categorie { get; set; }
        public string fk_author { get; set; }

        public News(string newsTiTle, string newsLink, string newsDate, string newsDescription, string fk_categorie, string fk_author)
        {
            NewsTiTle = newsTiTle;
            NewsLink = newsLink;
            NewsDate = newsDate;
            NewsDescription = newsDescription;
            this.fk_categorie = fk_categorie;
            this.fk_author = fk_author;
        }

        public News()
        {

        }
    }
}