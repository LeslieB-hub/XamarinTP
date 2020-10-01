using System;
using System.Collections.Generic;
using System.Text;
using TpMod9.Models;

namespace TpMod9.Services
{
    public interface ITwitterService
    {
        bool Authentificate(string utilisateur, string motDePasse);
        List<Tweet> GetTweets();
    }
}
