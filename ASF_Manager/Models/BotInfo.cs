using System.Collections.Generic;

namespace ASF_Manager.Models
{
   public class BotInfo
    {
        public string BotName { get; set; }
        public long SteamID { get; set; }
        public string NickName { get; set; }
        public string AvatarHash { get; set; }
        public string vds { get; set; }
        public bool Active { get; set; }
        public double WalletBalance { get; set; }
        public List<int> GamesHave { get; set; }
    }
}
