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
        public ICommand AddScraperItemsCommand => new Command(AddScraperItemsThread);
        public ObservableCollection<ScraperItem> ObservableScraperItems { get; set; } = new ObservableCollection<ScraperItem>();
        public static string EntryBarText { get; set; } = null;

        public void AddScraperItemsThread()
        {
            Thread t = new Thread(AddScraperItems);
            t.Start();
        }
        public void AddScraperItems()
        {
            ObservableScraperItems.Clear();
            AddScrapedElements(new BudvarScraper());
        }

        private void AddScrapedElements(IScraper scraper)
        {
            scraper.ScrapeWebsite();

            foreach (ScraperItem item in scraper.GetScrapedItems())
            {
                if (EntryBarText == null)
                {
                    ObservableScraperItems.Add(item);
                    continue;
                }

                if (KeywordsInEntryBar(item))
                {
                    ObservableScraperItems.Add(item);
                }
            }
        }

        private bool KeywordsInEntryBar(ScraperItem item)
        {
            if (item.Name.ToLower().Contains(EntryBarText.Trim().ToLower()))
            {
                return true;
            }
            if (item.Description.ToLower().Contains(EntryBarText.Trim().ToLower()))
            {
                return true;
            }
            if (item.Website.ToLower().Contains(EntryBarText.Trim().ToLower()))
            {
                return true;
            }

            return false;
        }
    }
}
