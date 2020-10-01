using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpMod9.Services;
using TpMod9.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TpMod9
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ConnectForm : ContentPage
    {
        private const string LOGIN_ERROR = "Login invalide, doit contenir au moins 3 caractères";
        private const string PASSWORD_ERROR = "Password invalide, doit contenir au moins 6 caractères";
        private const string AUTH_FAILED = "Authentication failed";
        private const string INTERNET_FAILED = "No internet connection";
       
        private ITwitterService twitterService;
        public ConnectForm()
        {
            this.twitterService = new TwitterService();
            InitializeComponent();
            this.btnConnecter.Clicked += TwitterConnect_Clicked;
        }

        private void TwitterConnect_Clicked(object sender, EventArgs e)
        {
            Debug.WriteLine("Clicked");
            var testLogin = true;
            var testPassword = true;
            var testAuth = true;
            var testInternet = true;

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
                if (Xamarin.Essentials.Connectivity.NetworkAccess == Xamarin.Essentials.NetworkAccess.Internet)
                {
                    if (this.twitterService.Authentificate(this.identifiant.Text, this.motDePasse.Text))
                    {
                        Navigation.PushAsync(new ListeTweets());
                        this.erreur.IsVisible = false;
                    }
                    else
                    {
                        if (!testLogin || !testPassword)
                        {
                            builder.Append("\n");
                        }
                        builder.Append(AUTH_FAILED);
                        testAuth = false;
                    }
                }
                else
                {
                    if (!testLogin || !testPassword || !testAuth)
                    {
                        builder.Append("\n");
                    }
                    builder.Append(INTERNET_FAILED);
                    testInternet = false;
                }
            }

            if (!testLogin || !testPassword || !testAuth || !testInternet)
            {
                this.erreur.Text = builder.ToString();
                this.erreur.IsVisible = true;
            }
        }
    }
}
