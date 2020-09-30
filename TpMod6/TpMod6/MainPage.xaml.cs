using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TpMod6
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.listeTweets.IsVisible = false;
            this.btnConnecter.Clicked += Connecter_Clicked;
            
            
        }

        private void Identifiant_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Connecter_Clicked(object sender, EventArgs e)
        {
            this.erreur.Text = "";
            System.Diagnostics.Debug.WriteLine("Connecter is Clicked");
            var id = this.identifiant.Text;
            var mdp = this.motDePasse.Text;
            System.Diagnostics.Debug.WriteLine(id);
            System.Diagnostics.Debug.WriteLine(mdp);
            if (!idIsValid(id))
            {
                this.erreur.Text = "identifiant : au moins 3 caractères!";
            }
            else
            {
                if (!mdpIsValid(mdp))
                {
                    this.erreur.Text = "Mot de passe : au moins 6 caractères!";
                }
                else
                {
                    this.erreur.Text = "";
                    this.listeTweets.IsVisible = true;
                    this.connectForm.IsVisible = false;
                }
            }



        }

       public bool idIsValid(string id)
        {
            bool result = true;
            if (id.Length < 3)
            {
                result = false;
            }
            return result;
        }

        public bool mdpIsValid(string mdp)
        {
            bool result = true;
            if (mdp.Length < 6)
            {
                result = false;
            }
            return result;
        }

    }
}
