using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpMod8.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TpMod8
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private const string LOGIN_ERROR = "Login invalide, doit contenir au moins 3 caractères";
        private const string PASSWORD_ERROR = "Password invalide, doit contenir au moins 6 caractères";
        private const string AUTH_ERROR = "id et mdp non conforme";
        private const string CONNECT_ERROR = "pas de connexion internet";
        ITwitterService twitterService = new TwitterService();

        public MainPage()
        {
            InitializeComponent();
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                this.btnConnecter.Clicked += TwitterConnect_Clicked;
                this.LoadTweets(this.listeTweets);
            }
            else
            {
                this.erreur.Text = "pas de connexion internet";
                this.erreur.IsVisible = true;
            }
        }

        private void LoadTweets(StackLayout listeTweets)
        {
            foreach (var item in twitterService.GetTweets())
            {
                listeTweets.Children.Add(new ViewTweet().LoadData(item));
            }
        }


        private void TwitterConnect_Clicked(object sender, EventArgs e)
        {
            Debug.WriteLine("Clicked");
            var testLogin = true;
            var testPassword = true;
            StringBuilder builder = new StringBuilder();

            if (this.identifiant.Text == null || this.identifiant.Text.Length < 3)
            {
                testLogin = false;
                builder.Append(LOGIN_ERROR);
            }

            if (string.IsNullOrEmpty(this.motDePasse.Text) || this.motDePasse.Text.Length < 6)
            {
                testPassword = false;
                if (!testLogin)
                {
                    builder.Append("\n");
                }
                builder.Append(PASSWORD_ERROR);
            }


            if (testLogin && testPassword)
            {
                
                if (twitterService.Authentificate(this.identifiant.Text, this.motDePasse.Text))
                {
                    this.listeTweets.IsVisible = !this.listeTweets.IsVisible;
                    this.connectForm.IsVisible = false;
                    this.erreur.IsVisible = false;
                }
                else
                {
                    this.erreur.Text = builder.Append(AUTH_ERROR).ToString();
                    this.erreur.IsVisible = true;
                }

            }

            if (!testLogin || !testPassword)
            {
                this.erreur.Text = builder.ToString();
                this.erreur.IsVisible = true;
            }
        }
    }
}
