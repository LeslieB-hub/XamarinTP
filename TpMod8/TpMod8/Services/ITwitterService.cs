using System;
using System.Collections.Generic;
using System.Text;
using TpMod8.Models;

namespace TpMod8.Services
{
    public interface ITwitterService
    {
        bool Authentificate(string utilisateur, string motDePasse);
        List<Tweet> GetTweets();
    }
}
