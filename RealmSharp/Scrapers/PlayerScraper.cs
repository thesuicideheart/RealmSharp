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
                bool foundPlayer = wantedElem.CssSelect(".player-not-found").Count() == 0;
                if (foundPlayer)
                {
                    //
                    var mainElem = wantedElem.First();
                    if(mainElem != null)
                    {
                        var statsXpath = "div[1]/div[1]/table[1]/";
                        var descXPath = "div[1]/div[2]/div[1]/";
                        var nameElem = mainElem.SelectSingleNode("h1[1]/span[1]");
                        
                        if(nameElem != null)    
                        {
                            var charCount = mainElem.SelectSingleNode(statsXpath + "tr[1]/td[2]");
                            var skins = mainElem.SelectSingleNode(statsXpath + "tr[2]/td[2]/span[1]");
                            var fame = mainElem.SelectSingleNode(statsXpath + "tr[3]/td[2]/span[1]");
                            var exp = mainElem.SelectSingleNode(statsXpath + "tr[4]/td[2]/span[1]");
                            var rank = mainElem.SelectSingleNode(statsXpath + "tr[5]/td[2]/div[1]");
                            var accountFame = mainElem.SelectSingleNode(statsXpath + "tr[6]/td[2]/span[1]");
                            var guild = mainElem.SelectSingleNode(statsXpath + "tr[7]/td[2]/a[1]");
                            var guildRank = mainElem.SelectSingleNode(statsXpath + "tr[8]/td[2]");
                            var created = mainElem.SelectSingleNode(statsXpath + "tr[9]/td[2]");
                            var lastSeen = mainElem.SelectSingleNode(statsXpath + "tr[10]/td[2]");

                            var line1 = mainElem.SelectSingleNode(descXPath + "div[1]").InnerText;
                            var line2 = mainElem.SelectSingleNode(descXPath + "div[2]").InnerText;
                            var line3 = mainElem.SelectSingleNode(descXPath + "div[3]").InnerText;

                            Console.WriteLine(mainElem.SelectSingleNode(statsXpath + "tr[1]") != null);
                            
                            if (int.TryParse(charCount.InnerText, out int iCharCount))
                                player.CharacterCount = iCharCount;

                            if (int.TryParse(skins.InnerText, out int iSkins))
                                player.Skins = iSkins;

                            if (int.TryParse(fame.InnerText, out int iFame))
                                player.Fame = iFame;

                            if (int.TryParse(exp.InnerText, out int iExp))
                                player.Exp = iExp;

                            if (int.TryParse(rank.InnerText, out int iRank))
                                player.Stars = iRank;

                            if (int.TryParse(accountFame.InnerText, out int iAccFame))
                                player.AccountFame = iAccFame;

                            player.Guild = guild.InnerText;
                            player.GuildRank = guildRank.InnerText;
                            player.Created = created.InnerText;
                            player.LastSeen = lastSeen.InnerText;
                            player.Name = nameElem.InnerText;
                            
                        }
                    }
                }
                else
                {
                    player.Name = "Player Not Found";
                    player.CharacterCount = 0;
                    player.Skins = 0;
                    player.Fame = 0;
                    player.Exp = 0;
                    player.Stars = 0;
                    player.AccountFame = 0;
                    player.Guild = "No Guild";
                    player.GuildRank = "Not In A Guild";
                    player.Created = "Player Not Found";
                    player.LastSeen = "Player Not Found";
                    
                }
            }

            return player;
        }
    }
}
