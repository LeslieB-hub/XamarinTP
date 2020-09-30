using System;
using System.Collections.Generic;
using System.Text;
using TpMod7.Models;

namespace TpMod7.Services
{
    public interface ITwitterService
    {
        bool Authentificate(string utilisateur, string motDePasse);
        List<Tweet> GetTweets();
    }

    /*
     « authenticate » qui prend en paramètres un
        utilisateur et un mot de passe et retourne un booléen et 
        « getTweets » qui prend en paramètre une chaîne de caractères
        et retourne une liste de tweets.
     */
}
