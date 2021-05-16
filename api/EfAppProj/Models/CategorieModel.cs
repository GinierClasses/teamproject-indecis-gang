using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace EfAppProj
{
    public class CategorieModel
    {
        
        [Column("Id_Categorie")]
        [Key]
        public int Id_Categorie { get; set; }
        [Column("Nom_Categorie", TypeName = "nvarchar")]
        public string Nom_Categorie { get; set; }

        public virtual ICollection<ArticleModel> Articles { get; set; }
        
    }
}