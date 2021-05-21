using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetAPI_News.Models
{
    public class News
    {
        public string TiTle { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public List<Category> Categories { get; set; }
        public List<Author> Authors { get; set; }

        public News() { }
        public News(string newsTiTle, string newsLink, DateTime newsDateTime, string newsDescription, List<Category> categories, List<Author> authors)
        {
            TiTle = newsTiTle;
            Link = newsLink;
            DateTime = newsDateTime;
            Description = newsDescription;
            this.Categories = categories;
            this.Authors = authors;
        }        
    }
}