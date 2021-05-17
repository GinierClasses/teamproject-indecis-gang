using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetAPI_News.Models
{
    public class Author
    {
        int IdAuthor;
        string AuthorName;

        public Author(int idAuthor, string authorName)
        {
            IdAuthor = idAuthor;
            AuthorName = authorName;
        }
    }
}