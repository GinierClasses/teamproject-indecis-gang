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
            cn.Close();
            
            User userInfos = new User(telegramId, notificationState);
            System.Diagnostics.Debug.WriteLine(userInfos);


            return userInfos;
        }

        public static string CreateUser(string userID )
        {
            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            MySqlConnection cn = new MySqlConnection(constr);
            MySqlCommand cm;
            String sqlQuery = "INSERT INTO `t_user` (`id_user`, `id_telegram`, `NotificationState`) VALUES (NULL, '" + userID + "', '1');";
            cn.Open();
            cm = new MySqlCommand(sqlQuery, cn);
            cm.ExecuteNonQuery();
            cn.Close();
            return "toto";
        }

    }
}