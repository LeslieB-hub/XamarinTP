using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using TpMod7.Models;
using TpMod7.Services;

//[assembly: Dependency(typeof(TwitterService))]
namespace TpMod7.Services
{
    public class TwitterService : ITwitterService
    {
        /*
         Faire en sorte que la méthode « authenticate » retourne 
         vrai lorsqu’un couple utilisateur/mot de passe de votre 
         choix est saisi, faux sinon.
             */

        public bool Authentificate(string utilisateur, string motDePasse)
        {
            bool result = false;
            if (utilisateur.Equals("cedric") && motDePasse.Equals("cedric"))
            {
                result = true;
            }
            return result;
        }
        //Faire en sorte de retourner une liste de tweets fixe en retour 
        //de la méthode getTweets.
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
                PseudoUtilisateur= "PseudoUtilisateur"
            });
            listeTweets.Add(new Tweet
            {
                Identifiant = "leslie",
                Utilisateur = "leslie",
                DateDeCreation = "01/01/2015",
                Texte = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec euismod convallis dolor.Quisque ultricies porttitor nunc",
                IdUtilisateur = "666",
                PseudoUtilisateur = "lesliePseudoUtilisateur"
            });
            return listeTweets;
        }
    }
}
