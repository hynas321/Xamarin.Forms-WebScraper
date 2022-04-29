using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void SearchButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SearchPage());
        }

        private void MapButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MapPage());
        }

        private void LinkButton1_Clicked(object sender, EventArgs e)
        {
            Browser.OpenAsync("https://www.budvarcentrum.pl/porady/jakie-okna-dzwiekoszczelne-ochronia-nas-najlepiej-przed-halasem/", BrowserLaunchMode.SystemPreferred);
        }

        private void LinkButton2_Clicked(object sender, EventArgs e)
        {
            Browser.OpenAsync("https://lix.com.pl/jak-halas-wplywa-na-nasze-zdrowie/", BrowserLaunchMode.SystemPreferred);
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
                    // An unexpected error occured. No browser may be installed on the device.
                }
            }
        }
    }
}