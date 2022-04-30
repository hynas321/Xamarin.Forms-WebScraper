using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;

namespace Project_App
{
    public interface IScraper
    {
        void ScrapeWebsite();
        List<ScraperItem> GetScrapedItems();
    }
}
