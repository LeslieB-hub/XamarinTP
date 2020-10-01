using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpMod8.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TpMod8
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewTweet : ContentView
    {
        public ViewTweet()
        {
            InitializeComponent();
        }

        public ViewTweet LoadData(Tweet tweet)
        {
            this.utilisateur.Text = tweet.Utilisateur;
            this.pseudo.Text = tweet.PseudoUtilisateur;
            this.texte.Text = tweet.Texte;
            this.dateDeCreation.Text = tweet.DateDeCreation;

            return this;
        }
    }
}