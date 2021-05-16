using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace EfAppProj
{
    public class ArticleContext : DbContext
    {
        /*string ConnectionString;

        static ArticleContext() { Database.SetInitializer<ArticleContext>(null); }
        public ArticleContext() : base("DefaultConnection") {  ConnectionString = Database.Connection.ConnectionString; }
        public ArticleContext(string connStr) : base(connStr) { ConnectionString = Database.Connection.ConnectionString; *///}
        

        public ArticleContext() : base("projdb") 
        {
            Database.SetInitializer<ArticleContext>(new ArticleDBInitializer());
        }

        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
                modelBuilder.Properties().Where(p => p.Name == "Id_Article").Configure(p => p.IsKey());
                modelBuilder.Properties().Where(p => p.Name == "Titre_Article");
                modelBuilder.Properties().Where(p => p.Name == "Lien_Article");
                modelBuilder.Properties().Where(p => p.Name == "Createur_Article");
                modelBuilder.Properties().Where(p => p.Name == "Description_Article");
                modelBuilder.Properties().Where(p => p.Name == "Date_Article");
                modelBuilder.Entity<ArticleModel>()
                    .HasRequired(m => m.CategorieModel)
                    .WithMany(c => c.Articles)
                    .HasForeignKey(b => b.CategorieModel);


            modelBuilder.Entity<ArticleModel>().ToTable("T_Article");
            modelBuilder.Entity<ArticleModel>().MapToStoredProcedures();
        }

        public DbSet<ArticleModel> Articles { get; set; }
        public DbSet<CategorieModel> Categories { get; set; }
    }
}