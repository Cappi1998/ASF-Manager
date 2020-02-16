using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF_Manager
{
    class Json_serealize
    {

        public class ASF_Restart_Response
        {
            public string Message { get; set; }
            public bool Success { get; set; }
        }


        public class Bot
        {
            public string BotName { get; set; }
            public long steamID { get; set; }
            public string NickName { get; set; }
            public string AvatarHash { get; set; }
            public string vds { get; set; }
            public bool Active { get; set; }

            public double WalletBalance { get; set; }
            public List<Getappid> gamesHave { get; set; }
        }

        public class Getappid//usado para obter os games do usuario
        {
            public int appid;
        }

    }
}


public class CurrentGamesFarming
{
    public int AppID { get; set; }
    public string GameName { get; set; }
    public int CardsRemaining { get; set; }
    public double HoursPlayed { get; set; }
}

public class GamesToFarm
{
    public int AppID { get; set; }
    public string GameName { get; set; }
    public int CardsRemaining { get; set; }
    public double HoursPlayed { get; set; }
}

public class CardsFarmer
{
    public List<CurrentGamesFarming> CurrentGamesFarming { get; set; }
    public List<GamesToFarm> GamesToFarm { get; set; }
    public string TimeRemaining { get; set; }
    public bool Paused { get; set; }
}



public class BotConfig
{
    public bool Enabled { get; set; }

    public int TradingPreferences { get; set; }
    public bool CardDropsRestricted { get; set; }
    public bool DismissInventoryNotifications { get; set; }
    public int FarmingOrder { get; set; }
    public bool HandleOfflineMessages { get; set; }
    public bool IsBotAccount { get; set; }
    public string SteamParentalPIN { get; set; }
}

public class ASF_Bots_Response
{
    public string BotName { get; set; }
    public CardsFarmer CardsFarmer { get; set; }
    public string AvatarHash { get; set; }
    public int GamesToRedeemInBackgroundCount { get; set; }
    public bool IsConnectedAndLoggedOn { get; set; }
    public bool IsPlayingPossible { get; set; }
    public string s_SteamID { get; set; }
    public int AccountFlags { get; set; }
    public BotConfig BotConfig { get; set; }
    public bool KeepRunning { get; set; }
    public string Nickname { get; set; }
    public long SteamID { get; set; }
    public int WalletBalance { get; set; }
    public int WalletCurrency { get; set; }
}
