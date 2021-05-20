using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace projetAPI_News.Models
{
    public static class AuthorModel
    {
        public static Author GetAuthorInfos()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            MySqlConnection cn = new MySqlConnection(constr);
            MySqlCommand cm;
            MySqlDataReader dataReader;
            String sqlQuery = "SELECT AuthorName FROM t_author";
            String Output = "";
            Author authorInfos = new Author();
            try
            {
                cn.Open();
                cm = new MySqlCommand(sqlQuery, cn);
                dataReader = cm.ExecuteReader();
                while (dataReader.Read())
                {
                    Output = Output + dataReader.GetValue(0) + dataReader.GetValue(1);
                }
                string authorName = dataReader.GetValue(0).ToString();
                System.Diagnostics.Debug.WriteLine("Okkkkkk!!!!!!!!!!!!!!!");
                cn.Close();

                authorInfos = new Author(authorName);
                System.Diagnostics.Debug.WriteLine(authorInfos);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return authorInfos;
        }

        public static string CreateAuthor(string authorName)
        {
            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            MySqlConnection cn = new MySqlConnection(constr);
            MySqlCommand cm;
            String sqlQuery = "INSERT INTO `t_author` (`ID_author`, `AuthorName`) VALUES (NULL, '" + authorName + "');";

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

            return "Author added";
        }

        public static string DeleteAuthor(string authorName)
        {
            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            MySqlConnection cn = new MySqlConnection(constr);
            MySqlCommand cm;
            String sqlQuery = "DELETE FROM `t_author` WHERE `AuthorName` LIKE '%'" + authorName + "'%';";

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

            return "Author deleted: " + authorName;

        }
    }
}