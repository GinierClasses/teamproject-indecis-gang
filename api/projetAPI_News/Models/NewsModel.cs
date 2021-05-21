using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace projetAPI_News.Models
{
    public static class NewsModel
    {
        public static News GetNewsInfos()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            MySqlConnection cn = new MySqlConnection(constr);
            MySqlCommand cm;
            MySqlDataReader dataReader;
            String sqlQuery = "SELECT t_news.NewsTitle, t_news.NewsDescription, t_news.NewsLink, t_news.NewsDateTime, t_news.NewsCategory, t_news.NewsAuthor FROM t_news";





            //"SELECT t_news.NewsTitle, t_news.NewsDescription, t_news.NewsLink, t_news.NewsDateTime, t_authors.AuthorName FROM `t_news` " +
            //"JOIN t_newsauthors ON t_news.Id_News = t_newsauthors.Fk_News" +
            //"JOIN t_authors ON t_newsauthors.Fk_Author = t_authors.Id_Author";
            //SELECT t_news.NewsTitle, t_news.NewsDescription, t_news.NewsLink, t_news.NewsDateTime, t_categories.CategoryName FROM t_news 
            //JOIN t_newscategories ON t_news.Id_News = t_newscategories.Fk_News
            //JOIN t_categories ON t_newscategories.Fk_Category = t_categories.Id_Category
            
            News newsInfos = new News();
            try
            {
                cn.Open();
                cm = new MySqlCommand(sqlQuery, cn);
                dataReader = cm.ExecuteReader();
                dataReader.Read();
                
                string newsTitle = dataReader.GetValue(0).ToString();
                string newsDescription = dataReader.GetValue(1).ToString();
                string newsLink = dataReader.GetValue(2).ToString();
                string newsDateTime = dataReader.GetValue(3).ToString();
                Category newsCategory = new Category(dataReader.GetValue(4).ToString());
                Author newsAuthor = new Author(dataReader.GetValue(5).ToString());

                cn.Close();

                newsInfos = new News(newsTitle, newsLink, Convert.ToDateTime(newsDateTime), newsDescription, new List<Category> { newsCategory }, new List<Author> { newsAuthor });
                System.Diagnostics.Debug.WriteLine(newsInfos);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return newsInfos;
        }

        public static string CreateNews(string newsTitle, string newsDescription, string newsLink,  string newsDateTime, string newscategory, string newsauthor)
        {
            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            MySqlConnection cn = new MySqlConnection(constr);
            MySqlCommand cm;
            //INSERT INTO `t_news` (`Id_News`, `NewsTitle`, `NewsDescription`, `NewsLink`, `NewsDateTime`) VALUES (NULL, 'Bonjour, je suis ', 'Bonjour, je suis ', 'Bonjour, je suis ', '2021-05-05 00:00:00');
            String sqlQuery = "INSERT INTO `t_news` (`NewsTitle`, `NewsDescription`, `NewsLink`, `NewsDateTime`, `NewsCategory`, `NewsAuthor` ) VALUES ('" + newsTitle + "', '" + newsDescription + "', '" + newsLink + "', '" + newsDateTime + "', '" + newscategory + "', '" + newsauthor + "')";

            try
            {
                cn.Open();
                cm = new MySqlCommand(sqlQuery, cn);
                cm.ExecuteNonQuery();
                cn.Close();
            return "News created: " + newsTitle + " Description: " + newsDescription;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "error";
            }

        }

        public static string DeleteNews(string newsTitle, string newsDate)
        {
            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            MySqlConnection cn = new MySqlConnection(constr);
            MySqlCommand cm;
            String sqlQuery = "DELETE FROM `t_news` WHERE NewsDate= '" + newsDate + "' AND `AuthorName` LIKE '%'" + newsTitle + "'%';";

            try
            {
                cn.Open();
                cm = new MySqlCommand(sqlQuery, cn);
                cm.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return "News deleted: " + newsTitle;

        }
    }
}