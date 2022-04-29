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
        public ObservableCollection<ScraperItem> ObservableScraperItems { get; set; }
        public string SearchedItemValue { get; set; }

        public ScraperViewModel()
        {
            ObservableScraperItems = new ObservableCollection<ScraperItem>();
        }

        public ICommand AddScraperItemsCommand => new Command(AddScraperItemsThread);

        public void AddScraperItemsThread()
        {
            Thread t = new Thread(AddScraperItems);
            t.Start();
        }

        public void AddScraperItems()
        {
            GlobalScraper.GlobalList().Clear();
            ObservableScraperItems.Clear();
            BudvarScraper budvar = new BudvarScraper(new GlobalScraper());
            //place for more initiated classes from different pages

            foreach (var item in GlobalScraper.GlobalList())
            {
                ObservableScraperItems.Add(item);
            }
        }
    }
}
