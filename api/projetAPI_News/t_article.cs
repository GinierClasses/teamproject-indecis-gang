//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace projetAPI_News
{
    using System;
    using System.Collections.Generic;
    
    public partial class t_article
    {
        public int ID_article { get; set; }
        public string Titre_Article { get; set; }
        public string Lien_Article { get; set; }
        public string Createur_Article { get; set; }
        public string Description_Article { get; set; }
        public System.DateTime Date_Article { get; set; }
        public int Fk_Categorie { get; set; }
    
        public virtual t_categorie T_Categorie { get; set; }
    }
}
