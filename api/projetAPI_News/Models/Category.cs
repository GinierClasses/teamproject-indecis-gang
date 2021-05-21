using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetAPI_News.Models
{
    public class Category
    {
        public string Name { get; set; }
        public Category() { }
        public Category(string categoryName)
        {
            this.Name = categoryName;
        }
    }
}