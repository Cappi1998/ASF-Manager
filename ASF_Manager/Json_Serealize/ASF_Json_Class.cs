using System;
using System.Collections.Generic;

public class GlobalConfig
{
    public int ConnectionTimeout { get; set; }
    public bool IPC { get; set; }
    public int WebLimiterDelay { get; set; }
    public long SteamOwnerID { get; set; }
    public string s_SteamOwnerID { get; set; }
    public List<string> IPCPrefixes { get; set; }
}

public class Result
{
    public string BuildVariant { get; set; }
    public GlobalConfig GlobalConfig { get; set; }
    public int MemoryUsage { get; set; }
    public DateTime ProcessStartTime { get; set; }
    public string Version { get; set; }
}

public class Main_ASD_Response
{
    public Result Result { get; set; }
    public string Message { get; set; }
    public bool Success { get; set; }
}



public class KeyToRedeem
{
    public List<string> KeysToRedeem { get; set; }
}


public class exec_comando
{
    public string Command { get; set; }
}