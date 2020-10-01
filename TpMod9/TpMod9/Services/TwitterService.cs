using System;
using System.Collections.Generic;
using System.Text;
using TpMod9.Models;

namespace TpMod9.Services
{
    public class TwitterService : ITwitterService
    {
        public bool Authentificate(string utilisateur, string motDePasse)
        {
            bool result = false;
            if (utilisateur.Equals("cedric") && motDePasse.Equals("cedric"))
            {
                result = true;
            }
            return result;
        }

        public List<Tweet> GetTweets()
        {
            List<Tweet> listeTweets = new List<Tweet>();
            listeTweets.Add(new Tweet
            {
                Identifiant = "cedric",
                Utilisateur = "cedric",
                DateDeCreation = "01/01/2015",
                Texte = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec euismod convallis dolor.Quisque ultricies porttitor nunc",
                IdUtilisateur = "5210",
                PseudoUtilisateur = "@PseudoUtilisateur"
            });
            listeTweets.Add(new Tweet
            {
                Identifiant = "leslie",
                Utilisateur = "leslie",
                DateDeCreation = "01/01/2015",
                Texte = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec euismod convallis dolor.Quisque ultricies porttitor nunc",
                IdUtilisateur = "666",
                PseudoUtilisateur = "@lesliePseudoUtilisateur"
            });
            listeTweets.Add(new Tweet
            {
                Identifiant = "lili",
                Utilisateur = "lili",
                DateDeCreation = "01/01/2015",
                Texte = "Quisque auctor orci a orci posuere, quis sollicitudin urna rutrum. Phasellus pulvinar, lacus sit amet consequat pretium, elit diam faucibus nisl, quis ornare justo risus sit amet dolor. Nam sed massa vitae",
                IdUtilisateur = "666",
                PseudoUtilisateur = "@lesliePseudoUtilisateur"
            });
            return listeTweets;
        }
    }
}
