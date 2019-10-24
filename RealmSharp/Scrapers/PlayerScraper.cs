using RealmSharp.DataStructures;
using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmSharp.Scrapers
{
    public class PlayerScraper
    {
        public static Player ScrapePlayer(string url)
        {
            var player = new Player();

            var browser = new ScrapingBrowser();
            browser.AllowAutoRedirect = true;
            browser.AllowMetaRedirect = true;

            var page = browser.NavigateToPage(new Uri(url));

            if(page != null)
            {
                var wantedElem = page.Html.CssSelect(".col-md-12");
            }

            return player;
        }
    }
}
