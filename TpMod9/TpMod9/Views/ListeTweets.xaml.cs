using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpMod9.Models;
using TpMod9.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TpMod9.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListeTweets : ContentPage
    {
        private ObservableCollection<Tweet> tweets;
        private ITwitterService twitterService;

        public ListeTweets()
        {
            InitializeComponent();
            this.twitterService = new TwitterService();
            tweets = new ObservableCollection<Tweet>();

            foreach (var item in twitterService.GetTweets())
            {
                tweets.Add(item);
            }
            
            this.listeTweets.ItemsSource = tweets;
        }
    }
}