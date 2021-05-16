using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetAPI_News
{
    public interface IDal : IDisposable
    {
        void AddArticle(int id,string titre_article,
        string lien_article, string createur_article,
        string description_article, System.DateTime date_article,
        int fk_categorie);

        void AddCategorie(string nomCategorie);
        List<t_article> ObtientLesArticles();
        List<t_categorie> ObtientCategories();
    }
}
