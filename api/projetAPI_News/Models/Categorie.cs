using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetAPI_News.Models
{
    public class Categorie
    {
        public string nom_categorie { get; set; }

        public Categorie(string nom_categorie)
        {
            this.nom_categorie = nom_categorie;
        }

        public Categorie()
        {
        }
    }
}