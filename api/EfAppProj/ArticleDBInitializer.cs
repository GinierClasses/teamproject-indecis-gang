using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfAppProj
{
    public class ArticleDBInitializer : DropCreateDatabaseAlways<ArticleContext>
    {
        protected override void Seed(ArticleContext context)
        {
            IList<CategorieModel> categories = new List<CategorieModel>();

            categories.Add(new CategorieModel() { Nom_Categorie = "Economie" });
            categories.Add(new CategorieModel() { Nom_Categorie = "Suisse" });
            categories.Add(new CategorieModel() { Nom_Categorie = "Sport" });

            context.Categories.AddRange(categories);

            IList<ArticleModel> articles = new List<ArticleModel>();
            var catMod = categories.ElementAt(0);
            articles.Add(new ArticleModel() { Titre_Article = "HelloWorld!!!", Lien_Article = "lien.lien", Createur_Article = "Schneider H", Description_Article = "blablablablablabablaalblablablalbla", Date_Article = new DateTime(12/03/2021), CategorieModel = catMod });
            
            context.Articles.AddRange(articles);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
