using ASF_Manager.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace ASF_Manager
{
    class Update_Bots_DB
    {
        Main MyForm1 = new Main();
        public static void Update_Bots()
        {
            Main._Main.group_auth.Invoke(new Action(() => Main._Main.group_auth.Enabled = false));
            Main._Main.groupbox_função.Invoke(new Action(() => Main._Main.groupbox_função.Enabled = false));

            var URL = $"http://{Main._Main.txt_IPC.Text}:{Main._Main.txt_PORT.Text}/Api/Bot/asf";

            if (Main._Main.ckc_usepass.Checked)
            {
                if (Main._Main.txt_passIPC.Text == "")
                {

                    Main._Main.lbl_status_auth.Text = "Please enter the IPC password";
                    Main._Main.lbl_status_auth.ForeColor = Color.Red;
                    Main._Main.txt_passIPC.Focus();
                    return;
                }
                else
                {
                    URL = $"{URL}?password={Main._Main.txt_passIPC.Text}";
                }
            }

            var response = new RequestBuilder(URL)
                .GET()
                .Execute();

            ASFResponse_BotsResume.Root asf_response = JsonConvert.DeserializeObject<ASFResponse_BotsResume.Root>(response.Content);

            Log.orange("Starting Update Bots Database...");
            int counter = 0;
            foreach (var asf_Bot in asf_response.Result)
            {
                
                Log.info("Db Update.. {0}. {1}/{2}", asf_Bot.Value.BotName, ++counter, asf_response.Result.Count);

                if (asf_Bot.Value.BotConfig.Enabled == false)
                {
                    Log.orange($"Account: {asf_Bot.Value.BotName} - was set to disabled, on the ASF config!");

                    try
                    {
                        File.Delete(@"Bots/" + asf_Bot.Value.SteamID + ".json");
                    }
                    catch
                    {

                    }

                    continue;
                }
                
                if(asf_Bot.Value.SteamID == 0)
                {
                    Log.orange($"Account: {asf_Bot.Value.BotName} - not yet started!");
                    continue;
                }

                var GameList = GetOwnedGames.GetGames(asf_Bot.Value.SteamID.ToString());

                BotInfo bot = new BotInfo
                {
                    AvatarHash = asf_Bot.Value.AvatarHash,
                    SteamID = asf_Bot.Value.SteamID,
                    BotName = asf_Bot.Value.BotName,
                    NickName = asf_Bot.Value.Nickname,
                    WalletBalance = asf_Bot.Value.WalletBalance,
                    vds = $"{Main._Main.txt_IPC.Text}:{Main._Main.txt_PORT.Text}",
                    Active = true,
                    GamesHave = GameList
                };

                File.WriteAllText($@"Bots/{bot.SteamID}.json", JsonConvert.SerializeObject(bot, Formatting.Indented));
            }

            Main._Main.group_auth.Invoke(new Action(() => Main._Main.group_auth.Enabled = true));
            Main._Main.groupbox_função.Invoke(new Action(() => Main._Main.groupbox_função.Enabled = true));
        }

        public static void Add_active_Game_to_File(long SteamID64, List<int> AppIDs)
        {
            string diretory = @"Bots/" + SteamID64 + ".json";

            BotInfo bot = JsonConvert.DeserializeObject<BotInfo>(File.ReadAllText(diretory));

            if (bot.GamesHave == null) bot.GamesHave = new List<int>();

            bot.GamesHave.AddRange(AppIDs);

            File.WriteAllText(@"Bots/" + SteamID64 + ".json", JsonConvert.SerializeObject(bot, Formatting.Indented));
        }
    }
}
