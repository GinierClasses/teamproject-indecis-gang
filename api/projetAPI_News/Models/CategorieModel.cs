using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace projetAPI_News.Models
{
    public static class CategorieModel
    {
        public static Categorie GetCategorieInfos()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            MySqlConnection cn = new MySqlConnection(constr);
            MySqlCommand cm;
            MySqlDataReader dataReader;
            String sqlQuery = "SELECT nom_categorie FROM t_categorie";
            String Output = "";
            Categorie CategorieInfos = new Categorie();
            try
            {
                cn.Open();
                cm = new MySqlCommand(sqlQuery, cn);
                dataReader = cm.ExecuteReader();
                while (dataReader.Read())
                {
                    Output = Output + dataReader.GetValue(0) + dataReader.GetValue(1);
                }
                string nom_categorie = dataReader.GetValue(0).ToString();
                System.Diagnostics.Debug.WriteLine("Info recup");
                cn.Close();

                CategorieInfos = new Categorie(nom_categorie);
                System.Diagnostics.Debug.WriteLine(CategorieInfos);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return CategorieInfos;
        }

        public static string CreateCategorie(string nomCategorie)
        {
            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            MySqlConnection cn = new MySqlConnection(constr);
            MySqlCommand cm;
            String sqlQuery = "INSERT INTO `t_categorie` (`ID_categorie`, `nom_categorie`) VALUES (NULL, '" + nomCategorie + "');";

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

            return "Categorie created: " + nomCategorie;
        }

        public static string DeleteCategorie(string nom_categorie)
        {
            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            MySqlConnection cn = new MySqlConnection(constr);
            MySqlCommand cm;
            String sqlQuery = "DELETE FROM `t_categorie` WHERE `nom_categorie`= '" + nom_categorie + "';";

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

            return "Categorie deleted: " + nom_categorie;

        }
    }
}