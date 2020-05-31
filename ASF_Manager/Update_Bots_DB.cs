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


            var URL = "http://" + Main._Main.txt_IPC.Text + ":" + Main._Main.txt_PORT.Text + "/Api/Bot/asf";

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

            JObject o = JObject.Parse(response);


            var id = o.First.First.ToString();

            JObject o1 = JObject.Parse(id);


            Log.orange("Starting Update Bots Database...");
            int counter = 0;
            foreach (var test in o1)
            {
                JObject odad = JObject.Parse(test.Value.ToString());

                ASF_Bots_Response bot_response = JsonConvert.DeserializeObject<ASF_Bots_Response>(odad.ToString());


                Log.info("Db Update.. {0}. {1}/{2}", bot_response.BotName, ++counter, o1.Count);

                if (bot_response.BotConfig.Enabled == false)
                {
                    Log.orange("Account " + bot_response.BotName + " was set to disabled, on the ASF config!");

                    try
                    {
                        File.Delete(@"Bots/" + bot_response.SteamID + ".json");
                    }
                    catch
                    {

                    }

                    continue;
                }
                
                if(bot_response.SteamID == 0)
                {
                    Log.orange("Account " + bot_response.BotName + " not yet started!");
                    continue;
                }

                string gameresponse_api = "http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key=" + Main._Main.txt_steamAPI.Text + "&steamid=" + bot_response.SteamID + "&format=json";

                var games_response = new RequestBuilder(gameresponse_api)
                .GET()
                .Execute();

                if (games_response == "{ \"response\":{ } }")
                {
                    Log.error("Account: +" + bot_response.BotName + " - games list is private please change to public!");
                }


                JObject od = JObject.Parse(games_response); //obter all appids
                JArray a = (JArray)od["response"]["games"];
                List<Json_serealize.Getappid> AppidList_UserNoEnumerated = a.ToObject<List<Json_serealize.Getappid>>();



                Json_serealize.Bot bot = new Json_serealize.Bot
                {
                    AvatarHash = bot_response.AvatarHash,
                    steamID = bot_response.SteamID,
                    BotName = bot_response.BotName,
                    NickName = bot_response.Nickname,
                    WalletBalance = bot_response.WalletBalance,
                    vds = Main._Main.txt_IPC.Text + ":" + Main._Main.txt_PORT.Text,
                    Active = true,
                    gamesHave = AppidList_UserNoEnumerated

                };

                File.WriteAllText(@"Bots/" + bot.steamID.ToString() + ".json", JsonConvert.SerializeObject(bot, Formatting.Indented));
            }

            Main._Main.group_auth.Invoke(new Action(() => Main._Main.group_auth.Enabled = true));
            Main._Main.groupbox_função.Invoke(new Action(() => Main._Main.groupbox_função.Enabled = true));

        }

        public static void Add_active_Game_to_File(long SteamID64, int Game_Code)
        {
            string diretory = @"Bots/" + SteamID64 + ".json";

            Json_serealize.Bot bot = JsonConvert.DeserializeObject<Json_serealize.Bot>(File.ReadAllText(diretory));

            Json_serealize.Getappid game_activate = new Json_serealize.Getappid { appid=Game_Code};

            bot.gamesHave.Add(game_activate);

            File.WriteAllText(@"Bots/" + SteamID64 + ".json", JsonConvert.SerializeObject(bot, Formatting.Indented));
        }
    }
}
