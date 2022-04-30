using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading;

namespace Project_App
{
    public class ScraperViewModel
    {
        public ObservableCollection<ScraperItem> ObservableScraperItems { get; set; } = new ObservableCollection<ScraperItem>();
        public static string FilteredText { get; set; } = null;

        public ICommand AddScraperItemsCommand => new Command(AddScraperItemsThread);
        public void AddScraperItemsThread()
        {
            Thread t = new Thread(AddScraperItems);
            t.Start();
        }
        public void AddScraperItems()
        {
            ObservableScraperItems.Clear();

            IScraper budvarScraper = new BudvarScraper();
            budvarScraper.ScrapeWebsite();

            foreach (ScraperItem item in budvarScraper.GetScrapedItems())
            {
                if (FilteredText == null)
                {
                    ObservableScraperItems.Add(item);
                    continue;
                }

                if (item.Name.ToLower().Contains(FilteredText.ToLower()))
                {
                    ObservableScraperItems.Add(item);
                }
                else if (item.Description.ToLower().Contains(FilteredText.ToLower()))
                {
                    ObservableScraperItems.Add(item);
                }
            }
        }
    }
}
