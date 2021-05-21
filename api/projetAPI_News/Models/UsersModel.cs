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
        public static User GetUserInfos()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            MySqlConnection cn = new MySqlConnection(constr);
            MySqlCommand cm;
            MySqlDataReader dataReader;
            String sqlQuery = "SELECT id_telegram, NotificationState FROM t_user WHERE id_telegram=171717";
            String Output = "";
            User userInfos = new User();
            try
            {
                cn.Open();
                cm = new MySqlCommand(sqlQuery, cn);
                dataReader = cm.ExecuteReader();
                while (dataReader.Read())
                {
                    Output = Output + dataReader.GetValue(0) + dataReader.GetValue(1);
                }
                string telegramId = dataReader.GetValue(0).ToString();
                bool notificationState = bool.Parse(dataReader.GetValue(1).ToString());
                //System.Diagnostics.Debug.WriteLine();
                System.Diagnostics.Debug.WriteLine("Okkkkkk!!!!!!!!!!!!!!!");
                cn.Close();

                userInfos = new User(telegramId, notificationState, 17);
                System.Diagnostics.Debug.WriteLine(userInfos);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return userInfos;
        }

        public static string CreateUser(string telegramID)
        {
            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            MySqlConnection cn = new MySqlConnection(constr);
            MySqlCommand cm;
            String sqlQuery = "INSERT INTO `t_user` (`id_user`, `id_telegram`, `NotificationState`) VALUES (NULL, '" + telegramID + "', '1');";

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
            
            return "toto";
        }

        public static string DeleteUser(string userID)
        {
            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            MySqlConnection cn = new MySqlConnection(constr);
            MySqlCommand cm;
            String sqlQuery = "DELETE FROM `t_user` WHERE `id_telegram`= '" + userID + "';";

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

            return "User deleted: " + userID;

        }



    }
}