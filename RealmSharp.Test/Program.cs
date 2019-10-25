using RealmSharp.Scrapers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmSharp.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var stuff = PlayerScraper.ScrapePlayer("https://realmeye.com/player/LilCold");

            Console.WriteLine("Name: " + stuff.Name);
            Console.WriteLine("Stars: " + stuff.Stars);
            Console.WriteLine("Skins: " + stuff.Skins);
            Console.WriteLine("Fame: " + stuff.Fame);
            Console.WriteLine("Exp: " + stuff.Exp);
            Console.WriteLine("Acc fame: " + stuff.AccountFame);
            Console.WriteLine("Guild: " + stuff.Guild);
            Console.WriteLine("Guild Rank: " + stuff.GuildRank);
            Console.WriteLine("Created: " + stuff.Created);
            Console.WriteLine("Last Seen: " + stuff.LastSeen);

            Console.ReadLine();
        }
    }
}
