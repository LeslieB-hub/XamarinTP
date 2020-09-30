using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpMod7.Services;
using Xamarin.Forms;

namespace TpMod7
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private const string LOGIN_ERROR = "Login invalide, doit contenir au moins 3 caractères";
        private const string PASSWORD_ERROR = "Password invalide, doit contenir au moins 6 caractères";

        public MainPage()
        {
            InitializeComponent();
            this.btnConnecter.Clicked += TwitterConnect_Clicked;
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

            if (!testLogin || !testPassword)
            {
                this.erreur.Text = builder.ToString();
                this.erreur.IsVisible = true;
            }

            if (testLogin && testPassword)
            {
                ITwitterService twitterService = new TwitterService();
                if (twitterService.Authentificate(this.identifiant.Text, this.motDePasse.Text))
                {
                    this.listeTweets.IsVisible = !this.listeTweets.IsVisible;
                    


                    this.connectForm.IsVisible = false;
                    this.erreur.IsVisible = false;
                }
                else
                {
                    this.erreur.Text = builder.Append("id et mdp non conforme").ToString();
                    this.erreur.IsVisible = true;
                }

            }
        }
    }
}
