using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF_Manager.Models
{
    class ASFResponse_MainConfig
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class GlobalConfig
        {
            public bool AutoRestart { get; set; }
            public List<object> Blacklist { get; set; }
            public string CommandPrefix { get; set; }
            public int ConfirmationsLimiterDelay { get; set; }
            public int ConnectionTimeout { get; set; }
            public string CurrentCulture { get; set; }
            public bool Debug { get; set; }
            public int FarmingDelay { get; set; }
            public int GiftsLimiterDelay { get; set; }
            public bool Headless { get; set; }
            public int IdleFarmingPeriod { get; set; }
            public int InventoryLimiterDelay { get; set; }
            public bool IPC { get; set; }
            public int IPCPasswordFormat { get; set; }
            public int LoginLimiterDelay { get; set; }
            public int MaxFarmingTime { get; set; }
            public int MaxTradeHoldDuration { get; set; }
            public int OptimizationMode { get; set; }
            public bool Statistics { get; set; }
            public string SteamMessagePrefix { get; set; }
            public long SteamOwnerID { get; set; }
            public int SteamProtocols { get; set; }
            public int UpdateChannel { get; set; }
            public int UpdatePeriod { get; set; }
            public int WebLimiterDelay { get; set; }
            public object WebProxy { get; set; }
            public object WebProxyUsername { get; set; }
            public string s_SteamOwnerID { get; set; }
        }

        public class Result
        {
            public string BuildVariant { get; set; }
            public bool CanUpdate { get; set; }
            public GlobalConfig GlobalConfig { get; set; }
            public int MemoryUsage { get; set; }
            public DateTime ProcessStartTime { get; set; }
            public string Version { get; set; }
        }

        public class Root
        {
            public Result Result { get; set; }
            public string Message { get; set; }
            public bool Success { get; set; }
        }


    }
}
