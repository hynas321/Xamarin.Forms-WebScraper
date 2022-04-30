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
        public string SearchedItemValue { get; set; }

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
                ObservableScraperItems.Add(item);
            }
        }
    }
}
