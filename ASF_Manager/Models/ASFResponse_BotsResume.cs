using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF_Manager.Models
{
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
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
            public bool AcceptGifts { get; set; }
            public bool AutoSteamSaleEvent { get; set; }
            public int BotBehaviour { get; set; }
            public List<object> CompleteTypesToSend { get; set; }
            public object CustomGamePlayedWhileFarming { get; set; }
            public object CustomGamePlayedWhileIdle { get; set; }
            public bool Enabled { get; set; }
            public List<object> FarmingOrders { get; set; }
            public List<object> GamesPlayedWhileIdle { get; set; }
            public int HoursUntilCardDrops { get; set; }
            public bool IdlePriorityQueueOnly { get; set; }
            public bool IdleRefundableGames { get; set; }
            public List<int> LootableTypes { get; set; }
            public List<int> MatchableTypes { get; set; }
            public int OnlineStatus { get; set; }
            public int PasswordFormat { get; set; }
            public bool Paused { get; set; }
            public int RedeemingPreferences { get; set; }
            public bool SendOnFarmingFinished { get; set; }
            public int SendTradePeriod { get; set; }
            public bool ShutdownOnFarmingFinished { get; set; }
            public int SteamMasterClanID { get; set; }
            public string SteamTradeToken { get; set; }
            public int TradingPreferences { get; set; }
            public List<int> TransferableTypes { get; set; }
            public bool UseLoginKeys { get; set; }
            public int UserInterfaceMode { get; set; }
            public string s_SteamMasterClanID { get; set; }
            public bool DismissInventoryNotifications { get; set; }
            public int FarmingOrder { get; set; }
            public bool HandleOfflineMessages { get; set; }
            public string SteamParentalPIN { get; set; }
        }
        public class BotInfo
        {
            public string AvatarHash { get; set; }
            public string BotName { get; set; }
            public CardsFarmer CardsFarmer { get; set; }
            public int GamesToRedeemInBackgroundCount { get; set; }
            public bool HasMobileAuthenticator { get; set; }
            public bool IsConnectedAndLoggedOn { get; set; }
            public bool IsPlayingPossible { get; set; }
            public string s_SteamID { get; set; }
            public int AccountFlags { get; set; }
            public BotConfig BotConfig { get; set; }
            public bool KeepRunning { get; set; }
            public string Nickname { get; set; }
            public int RequiredInput { get; set; }
            public long SteamID { get; set; }
            public int WalletBalance { get; set; }
            public int WalletCurrency { get; set; }
        }
        public class ASFResponse_BotsResume
		{
            public Dictionary<string, BotInfo> Result { get; set; }
            public string Message { get; set; }
            public bool Success { get; set; }
        }
   
}
