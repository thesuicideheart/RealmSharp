using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmSharp.DataStructures
{
    public struct Player
    {
        public int Stars { get; set; }
        public int Fame { get; set; }
        public int Skins { get; set; }
        public int Exp { get; set; }
        public int Accountfame { get; set; }
        public string Guild { get; set; }
        public string GuildRank { get; set; }
        public string DescriptionLine1 { get; set; }
        public string DescriptionLine2 { get; set; }
        public string DescriptionLine3 { get; set; }
    }
}
