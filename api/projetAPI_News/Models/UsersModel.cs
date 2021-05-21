using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace projetAPI_News.Models
{
    public static class UsersModel
    {

        public static User GetUserInfos(int client_id)
        {
            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            MySqlConnection cn = new MySqlConnection(constr);
            MySqlCommand cm;
            MySqlDataReader dataReader;
            String sqlQuery = "SELECT * FROM t_users WHERE ClientId=" + client_id + ";";
            User userInfos = new User();
            try
            {
                cn.Open();
                cm = new MySqlCommand(sqlQuery, cn);
                dataReader = cm.ExecuteReader();
                dataReader.Read();
                string telegramId = dataReader.GetValue(1).ToString();
                bool notificationState = bool.Parse(dataReader.GetValue(2).ToString());
                int last_news_id = int.Parse(dataReader.GetValue(3).ToString());
                cn.Close();

                userInfos = new User(telegramId, notificationState, last_news_id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return userInfos;
        }

        public static string CreateUser(string clientId)
        {
            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            MySqlConnection cn = new MySqlConnection(constr);
            MySqlCommand cm;
            String sqlQuery = "INSERT INTO `t_users` (`id_user`, `ClientId`, `NotificationState`, `LastNewsId`) VALUES (NULL, '" + clientId + "', '0', NULL);";

            try
            {
                cn.Open();
                cm = new MySqlCommand(sqlQuery, cn);
                cm.ExecuteNonQuery();
                cn.Close();
                return "Success";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Error";
            }
        }

        public static string DeleteUser(string clientId)
        {
            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            MySqlConnection cn = new MySqlConnection(constr);
            MySqlCommand cm;
            String sqlQuery = "DELETE FROM `t_users` WHERE `ClientId`= '" + clientId + "';";

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

            return "User deleted: " + clientId;

        }

        public static string UpdateUser(string clientId, bool notificationState, int lastNewsId)
        {
            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            MySqlConnection cn = new MySqlConnection(constr);
            MySqlCommand cm;
            String sqlQuery = "UPDATE `t_users` SET `NotificationState` =" + notificationState + ", `LastNewsId` = " + lastNewsId + " WHERE `t_users`.`ClientId` = " + clientId + ";";

            try
            {
                cn.Open();
                cm = new MySqlCommand(sqlQuery, cn);
                cm.ExecuteNonQuery();
                cn.Close();
                return "Success";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Error";
            }
        }


    }
}