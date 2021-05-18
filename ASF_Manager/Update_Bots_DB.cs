using ASF_Manager.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    URL = "http://" + Main._Main.txt_IPC.Text + ":" + Main._Main.txt_PORT.Text + "/Api/Bot/asf?password=" + Main._Main.txt_passIPC.Text;
                }

            }

            var response = new RequestBuilder(URL)
                .GET()
                .Execute();


            ASFResponse_BotsResume.Root asf_response = JsonConvert.DeserializeObject<ASFResponse_BotsResume.Root>(response);

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

                string RequestURL = $"http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key={Main._Main.txt_steamAPI.Text}&steamid={asf_Bot.Value.SteamID}&format=json";

                var Request = new RequestBuilder(RequestURL)
                .GET()
                .Execute();

                if (Request == "{ \"response\":{ } }")
                {
                    Log.error($"Account: {asf_Bot.Value.BotName} - games list is private please change to public!");
                }
                
                OwnedGames.Root OwnedGamesResponse = JsonConvert.DeserializeObject<OwnedGames.Root>(Request);

                var GameList = OwnedGamesResponse.response.games.Select(i => i.appid.ToString()).ToList();

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

        public static void Add_active_Game_to_File(long SteamID64, string AppID)
        {
            string diretory = @"Bots/" + SteamID64 + ".json";

            BotInfo bot = JsonConvert.DeserializeObject<BotInfo>(File.ReadAllText(diretory));

            bot.GamesHave.Add(AppID);

            File.WriteAllText(@"Bots/" + SteamID64 + ".json", JsonConvert.SerializeObject(bot, Formatting.Indented));
        }
    }
}
