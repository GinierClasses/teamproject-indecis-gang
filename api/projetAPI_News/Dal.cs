using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace projetAPI_News
{
    public class Dal : IDal
    {
        private projigEntities1 bdd;

        public Dal()
        {
            bdd = new projigEntities1();
        }
        public List<t_categorie> ObtientCategories()
        {
            return bdd.t_categories.ToList();
        }

        public List<t_article> ObtientLesArticles()
        {
            return bdd.t_articles.ToList();
        }

        public void Dispose()
        {
            bdd.Dispose();
        }
        public void AddCategorie(string nomCategorie)
        {
            bdd.t_categories.Add(new t_categorie { nom_categorie = nomCategorie});
            bdd.SaveChanges();
        }

        public void AddArticle(int id, string titre_article,
        string lien_article, string createur_article,
        string description_article, System.DateTime date_article,
        int fk_categorie)
        {
            bdd.t_articles.Add(new t_article { ID_article = id, Titre_Article = titre_article,
                    Lien_Article = lien_article, Createur_Article = createur_article, 
                    Description_Article = description_article, Date_Article = date_article,
                    Fk_Categorie = fk_categorie});

            bdd.SaveChanges();
        }


    }
}