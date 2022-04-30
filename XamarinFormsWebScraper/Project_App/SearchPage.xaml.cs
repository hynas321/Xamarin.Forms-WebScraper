using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Project_App
{
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
        }

        private void SearchButton_Clicked(object sender, EventArgs e)
        {
            SearchText.IsVisible = false;
            SearchIcon.IsVisible = false;
            SearchButton.Text = "Wyszukaj ponownie";
            ScraperViewModel.FilteredText = EntryBar.Text;
        }

        private void SettingsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MapPage());
        }

        private void Frame_Clicked(object sender, EventArgs e)
        {
            Browser.OpenAsync("https://www.budvarcentrum.pl/typ-produktu/okna-pvc/", BrowserLaunchMode.SystemPreferred);
        }

        public class BrowserTest
        {
            public async Task OpenBrowser(Uri uri)
            {
                try
                {
                    await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
                }
                catch
                {
                    //No browser
                }
            }
        }
    }
}
