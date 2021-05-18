using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF_Manager.Models
{
    class BotInfo
    {
        public string BotName { get; set; }
        public long SteamID { get; set; }
        public string NickName { get; set; }
        public string AvatarHash { get; set; }
        public string vds { get; set; }
        public bool Active { get; set; }

        public double WalletBalance { get; set; }
        public List<string> GamesHave { get; set; }
    }
}
