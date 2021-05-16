using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projetAPI_News
{
    [Table("T_Article")]
    public class Articleklk
    {
        [Key]
        [Column("Id_Article")]
        public int Id_Article { get; set; }

        [Column("Titre_Article", TypeName = "ntext")]
        [MaxLength(50)]
        public string Titre_Article { get; set; }
        [Column("Lien_Article", TypeName = "nvarchar")]
        public string Lien_Article { get; set; }
        [Column("Createur_Article", TypeName = "nvarchar")]
        public string Createur_Article { get; set; }
        [Column("Description_Article", TypeName = "ntext")]
        public string Description_Article { get; set; }
        [Column("Date_Article", TypeName = "datetime")]
        public DateTime Date_Article { get; set; }

        public int? Id_Categorie { get; set; }
        public virtual CategorieModel CategorieModel { get; set; }
        
    }
}