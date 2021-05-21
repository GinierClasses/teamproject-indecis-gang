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
        public List<Category> Categories { get; set; }
        public List<Author> Authors { get; set; }

        public News(string newsTiTle, string newsLink, string newsDate, string newsDescription, List<Category> categories, List<Author> authors)
        {
            NewsTiTle = newsTiTle;
            NewsLink = newsLink;
            NewsDate = newsDate;
            NewsDescription = newsDescription;
            this.Categories = categories;
            this.Authors = authors;
        }

        public News()
        {

        }
    }
}