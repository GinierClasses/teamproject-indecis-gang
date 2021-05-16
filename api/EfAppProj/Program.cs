using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EfAppProj
{
    class Program
    {
        static void Main(string[] args)
        {
            ArticleContext db = new ArticleContext();

            

            db.SaveChanges();
            /*meArt.Categories = new List<CategorieModel> { maCat };
            db.SaveChanges();*/
        }
    }
}
