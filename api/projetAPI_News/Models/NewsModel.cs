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
            String sqlQuery = "SELECT NewsTitle, NewsLink, NewsDate, NewsDescription, fk_category, fk_author FROM t_news";
            String Output = "";
            News newsInfos = new News();
            try
            {
                cn.Open();
                cm = new MySqlCommand(sqlQuery, cn);
                dataReader = cm.ExecuteReader();
                while (dataReader.Read())
                {
                    Output = Output + dataReader.GetValue(0) + dataReader.GetValue(1);
                }
                string newsTitle = dataReader.GetValue(0).ToString();
                string newsLink = dataReader.GetValue(1).ToString();
                string newsDate = dataReader.GetValue(2).ToString();
                string newsDescription = dataReader.GetValue(3).ToString();
                string fk_categorie = dataReader.GetValue(4).ToString();
                string fk_author = dataReader.GetValue(5).ToString();
                System.Diagnostics.Debug.WriteLine("Get News Ok!!!!!!");
                cn.Close();

                newsInfos = new News(newsTitle, newsLink, Convert.ToDateTime(newsDate), newsDescription, new List<Category> { new Category(fk_categorie) }, new List<Author> { new Author(fk_author) });
                System.Diagnostics.Debug.WriteLine(newsInfos);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return newsInfos;
        }

        public static string CreateNews(string newsTitle, string newsLink, string newsDate, string newsDescription, string fk_category, string fk_author)
        {
            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            MySqlConnection cn = new MySqlConnection(constr);
            MySqlCommand cm;
            String sqlQuery = "INSERT INTO `t_news` (`ID_News`, `NewsTitle`, `NewsLink`, `NewsDate`, `NewsDescription`, `fk_category`, `fk_author` ) VALUES (NULL, '" + newsTitle + "', '" + newsLink + "', '" + newsDate + "', '" + newsDescription + "', '" + fk_category + "', '" + fk_author + "');";

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

            return "News created: " + newsTitle + " Description: " + newsDescription;
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