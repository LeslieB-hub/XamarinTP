using System;
using System.Collections.Generic;
using System.Text;

namespace TpMod8.Models
{
    public class Tweet
    {
        public string Identifiant { get; set; }
        public string DateDeCreation { get; set; }
        public string Texte { get; set; }
        public string Utilisateur { get; set; }
        public string IdUtilisateur { get; set; }
        public string PseudoUtilisateur { get; set; }
    }
}
