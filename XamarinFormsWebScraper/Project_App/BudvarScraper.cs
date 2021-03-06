using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Project_App
{
    public class BudvarScraper : IScraper
    {
        private ScraperItem[] scrapedItems = new ScraperItem[6];
        private string link = "https://www.budvarcentrum.pl/typ-produktu/okna-pvc/";
        private HtmlWeb web = new HtmlWeb();
        private HtmlDocument doc;
        public BudvarScraper()
        {
            try
            {
                doc = web.Load(link);
            }
            catch 
            {
                
            }
        }

        public List<ScraperItem> GetScrapedItems()
        {
            return scrapedItems.ToList();
        }
        public void ScrapeWebsite()
        {
            string[] titles = GetInformationFromPath("//div[@class='product-box__title']");
            string[] descriptions = GetInformationFromPath("//div[@class='product-box__excerpt']");
            string[] imgUrls = GetImgUrlsFromPath("//div[@class='product-box__photo ']/img[@height='510']");

            for (int i = 0; i < scrapedItems.Length; i++)
            {
                scrapedItems[i] = new ScraperItem() { Name = titles[i], Description = descriptions[i], ImageUrl = imgUrls[i], Website = "www.budvarcentrum.pl" };
            }
        }

        private string[] GetInformationFromPath(string path)
        {
            int count = 0;
            string[] elements = new string[6];

            foreach (var element in doc.DocumentNode.SelectNodes(path))
            {
                try
                {
                    elements[count] = element.InnerText;
                    count++;
                }
                catch { break; }
            }

            return elements;
        }

        private string[] GetImgUrlsFromPath(string path)
        {
            int count = 0;
            string[] elements = new string[6];

            foreach (var element in doc.DocumentNode.SelectNodes(path))
            {
                try
                {
                    elements[count] = element.GetAttributeValue("src", "src");
                    count++;
                }
                catch { break; }
            }

            return elements;
        }
    }
}
