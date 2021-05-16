using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace projetAPI_News.Tests
{
    [TestClass]
    public class DalTests
    {
        [TestInitialize]
        public void Init()
        {
            IDatabaseInitializer<projigEntities1> init = new DropCreateDatabaseAlways<projigEntities1>();
            Database.SetInitializer(init);
            init.InitializeDatabase(new projigEntities1());
        }
        [TestMethod]
        public void AjouterArticleEtVerifAjout()
        {
            

            IDal dal = new Dal();
            
            dal.AddArticle(1,"SALUASASNM", "Les feux de l'eau ", "Jean-Jac Rosbert-Pierre", 
                "Il etait une fois ou j'ai connu t'as maman dans le parc", new DateTime(12/03/2021), 1);
            
            List<t_article> articles = dal.ObtientLesArticles();

            Assert.IsNotNull(articles);
            Assert.AreEqual(1, articles.Count);
            Assert.AreEqual("SALUASASNM", articles[0].Titre_Article);
            Assert.AreEqual("Jean-Jac Rosbert-Pierre", articles[0].Createur_Article);
            
        }
    }
}
