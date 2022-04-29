using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;

namespace Project_App
{
    public class GlobalScraper
    {
        public int ScraperItemsCount { get { return ScraperItems.Count; } } 
        public int MaxItemsCount { get; set; }
        public string Link { get; set; }
        public HtmlWeb Web { get; set; }
        public HtmlDocument Doc { get; set; }

        private static List<ScraperItem> ScraperItems = new List<ScraperItem>();
        public static List<ScraperItem> GlobalList()
        {
            return ScraperItems;
        }
    }
}
