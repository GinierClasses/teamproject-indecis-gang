using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetAPI_News.Models
{
    public class Category
    {
        public string Name { get; set; }

        public Category(string nom_categorie)
        {
            this.Name = nom_categorie;
        }

        public Category()
        {
        }
    }
}