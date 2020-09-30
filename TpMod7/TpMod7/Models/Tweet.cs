using System;
using System.Collections.Generic;
using System.Text;

namespace TpMod7.Models
{
    public class Tweet
    {
        //identifiant, date de création,
        //texte, nom de l’utilisateur, identifiant de l’utilisateur et pseudo de l’utilisateur.
        public string Identifiant { get; set; }
        public string DateDeCreation { get; set; }
        public string Texte { get; set; }
        public string Utilisateur { get; set; }
        public string IdUtilisateur { get; set; }
        public string PseudoUtilisateur { get; set; }


    }
}
