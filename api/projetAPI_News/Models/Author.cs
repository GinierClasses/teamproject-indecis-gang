using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetAPI_News.Models
{
    public class Author
    {
        public string AuthorName { get; set; }

        public Author() { }

        public Author(string authorName)
        {
            AuthorName = authorName;
        }
    }
}