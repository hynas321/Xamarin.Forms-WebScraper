using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;

namespace Project_App
{
    public class BudvarScraper : IScraper
    {
        private GlobalScraper gs;
		
        public BudvarScraper(GlobalScraper globalScraper)
        {
            gs = globalScraper;
            gs.MaxItemsCount = 6;

            gs.Link = "https://www.budvarcentrum.pl/typ-produktu/okna-pvc/";
            gs.Web = new HtmlWeb();
            gs.Doc = gs.Web.Load(gs.Link);
        }
		
        public void ScrapeWebsite()
        {
            int count = 0;
            foreach (var element in gs.Doc.DocumentNode.SelectNodes("//div[@class='product-box__title']"))
            {
                if (count == gs.MaxItemsCount) { break; }

                try
                {
                    var scraperitem = new ScraperItem();
                    scraperitem.Name = element.InnerText;
                    scraperitem.Website = "budvarcentrum.pl";

                    GlobalScraper.GlobalList().Add(scraperitem);
                    AddDescription(count);
                    AddImage(count);
                    count++;
                }
                catch { break; }
            }
        }

        private void AddDescription(int count)
        {
            foreach (var element in gs.Doc.DocumentNode.SelectNodes("//div[@class='product-box__excerpt']"))
            {
                if (count == gs.MaxItemsCount) { break; }

                try
                {
                    GlobalScraper.GlobalList()[count + gs.ScraperItemsCount].Description = element.InnerText;
                }
                catch { break; }
            }
        }

        private void AddImage(int count)
        {
            foreach (var element in gs.Doc.DocumentNode.SelectNodes("//div[@class='product-box__photo ']/img[@height='510']"))
            {
                if (count == gs.MaxItemsCount) { break; }

                try
                {
                    GlobalScraper.GlobalList()[count + gs.ScraperItemsCount].ImageUrl = element.GetAttributeValue("src", "src");
                }
                catch { break; }
            }
        }
    }
}
