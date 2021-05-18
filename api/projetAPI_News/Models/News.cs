using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetAPI_News.Models
{
    public class News
    {
        int IdNews;
        string NewsTitle;
        string NewsLink;
        string NewsAuthor;
        DateTime NewsDate;
        string NewsDescription;
        Category Category;
        Author Author;

        public News(int idNews, string newsTitle, string newsLink, string newsAuthor, DateTime newsDate, string newsDescription, Category category, Author author)
        {
            IdNews = idNews;
            NewsTitle = newsTitle;
            NewsLink = newsLink;
            NewsAuthor = newsAuthor;
            NewsDate = newsDate;
            NewsDescription = newsDescription;
            Category = category;
            Author = author;
        }
    }
}