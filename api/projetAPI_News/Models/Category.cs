using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetAPI_News.Models
{
    public class Category
    {
        int IdCategory;
        string CategoryName;

        public Category(int idCategory, string categoryName)
        {
            IdCategory = idCategory;
            CategoryName = categoryName;
        }
    }
}