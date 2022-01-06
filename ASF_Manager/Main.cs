using ASF_Manager.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace ASF_Manager
{
    public partial class Main : MetroFramework.Forms.MetroForm
    {

        public static Main _Main;
        public Main()
        {
            InitializeComponent();
            _Main = this;
            txtConsole.AppendText("Powered by Cappi_1998" + Environment.NewLine);

            if (File.Exists(Program.Config_FilePath))
            {
                Config config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(Program.Config_FilePath));
                Main._Main.txt_IPC.Text = config.IP;
                Main._Main.txt_PORT.Text = config.Port;
                Main._Main.txt_passIPC.Text = config.Password;
                Main._Main.txt_steamAPI.Text = config.SteamApiKey;
            }
            else
            {
                Config config = new Config {IP= "127.0.0.1", Port= "1242" };
                File.WriteAllText(Program.Config_FilePath, JsonConvert.SerializeObject(config));
            }

        }

        public static void SaveConfig()
        {
            Config config = new Config { IP= Main._Main.txt_IPC.Text , Port= Main._Main.txt_PORT.Text , Password= Main._Main.txt_passIPC.Text , SteamApiKey= Main._Main.txt_steamAPI.Text };
            File.WriteAllText(Program.Config_FilePath, JsonConvert.SerializeObject(config));
        }

        private void btn_check_connect_Click(object sender, EventArgs e)
        {
            lbl_status_auth.Text = "";
            string URL = $"http://{Main._Main.txt_IPC.Text}:{Main._Main.txt_PORT.Text}/Api/ASF";

            if (ckc_usepass.Checked)
            {
                if (txt_passIPC.Text == "")
                {

                    lbl_status_auth.Text = "Please enter the IPC password";
                    lbl_status_auth.ForeColor = Color.Red;
                    txt_passIPC.Focus();
                    return;
                }
                else
                {
                    URL = $"http://{Main._Main.txt_IPC.Text}:{Main._Main.txt_PORT.Text}/Api/ASF?password=" + txt_passIPC.Text;
                }

            }

            lbl_status_auth.Text = "please wait...";
            lbl_status_auth.ForeColor = Color.Orange;

            var response = new RequestBuilder(URL)
                .GET()
                .Execute();

            ASFResponse_MainConfig.Root result = JsonConvert.DeserializeObject<ASFResponse_MainConfig.Root>(response.Content);

            try
            {
                if (!result.Success == true)
                {
                    lbl_status_auth.Text = "Connection Fail";
                    lbl_status_auth.ForeColor = Color.LimeGreen;
                }

                lbl_status_auth.Text = $"Success, ASF Version -> {result.Result.Version}";
                lbl_status_auth.ForeColor = Color.LimeGreen;
                groupbox_função.Visible = true;
            }
            catch (Exception ex)
            {
                Log.error(ex.Message, ex);
                lbl_status_auth.Text = "Connection Fail";
                lbl_status_auth.ForeColor = Color.DarkRed;
            }
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (ckc_usepass.Checked)
            {
                txt_passIPC.Visible = true;
                groupbox_função.Visible = false;
            }
            else
            {
                txt_passIPC.Visible = false;
                groupbox_função.Visible = false;
            }

        }

        private void txt_passIPC_KeyPress(object sender, KeyPressEventArgs e)
        {
            lbl_status_auth.Text = "";
            groupbox_função.Visible = false;
        }

        private void btn_ASF_Restart_Click(object sender, EventArgs e)
        {
            string URL = "http://" + txt_IPC.Text + ":" + txt_PORT.Text + "/Api/ASF/Restart";

            var response = new RequestBuilder(URL)
                .POST()
                .Execute();

            ASFResponse_BotsResume.Root result = JsonConvert.DeserializeObject<ASFResponse_BotsResume.Root>(response.Content);

            if (!result.Success == true)
            {
                Log.error("ASF Restart Fail!", result);
            }
            else
            {
                Log.info("ASF successfully restarted!");
            }
        }

        private void btn_bot_Click(object sender, EventArgs e)
        {
            Thread active_games = new Thread(() => Activate_Games());
            active_games.Start();
        }

        private void txt_IPC_KeyPress(object sender, KeyPressEventArgs e)
        {
            groupbox_função.Visible = false;
            lbl_status_auth.Text = "";
        }

        private void txt_PORT_KeyPress(object sender, KeyPressEventArgs e)
        {
            groupbox_função.Visible = false;
            lbl_status_auth.Text = "";
        }

        public static void Activate_Games()
        {
            Main._Main.group_auth.Invoke(new Action(() => Main._Main.group_auth.Enabled = false));
            Main._Main.groupbox_função.Invoke(new Action(() => Main._Main.groupbox_função.Enabled = false));


            string[] gamesFiles = Directory.GetFiles(@"active", "*.txt");//pegamos informações da pasta

            string[] botinfoFiles = Directory.GetFiles(@"bots", "*.json");//pegamos informações da pasta

            List<BotInfo> Bots = new List<BotInfo> { };

            foreach (var bot in botinfoFiles)
            {
                BotInfo bot1 = JsonConvert.DeserializeObject<BotInfo>(File.ReadAllText(@bot));

                if (bot1.vds == Main._Main.txt_IPC.Text + ":" + Main._Main.txt_PORT.Text)
                {
                    Bots.Add(bot1);
                }
            }

            int process = 0;
            foreach (var gameFilePath in gamesFiles)
            {
                int max_process = Convert.ToInt32(Main._Main.txt_max_process.Text);

                if (process + 1 > max_process)
                {
                    Log.pink(max_process + " files processed, please wait a few minutes, not to be blocked by the steam network (Rate Limit Exceeded)");
                    break;
                }

                Log.orange("Processing " + gameFilePath);

                int lines = File.ReadAllLines(gameFilePath).Length;

                if (lines < 1)
                {
                    Log.orange($"File: {gameFilePath} Will not be used because it has 0 codes!");
                    continue;
                }

                process = process + 1;

                foreach (BotInfo bot in Bots)
                {
                    bool botIsOnline = CheckBotIsLogeed(bot.BotName);

                    if (botIsOnline == false)
                    {
                        Log.orange($"{bot.BotName} - is Offline");
                        continue;
                    }

                    var AppIDs = GetAppIDS(gameFilePath);

                    if(AppIDs == null)
                    {
                        break;
                    }

                    bool botNotHaveGames = CheckGameOwnsOnBot(AppIDs, bot);

                    if (botNotHaveGames)//se não tiver o jogo fazer a ativação
                    {
                        string[] Ler_Arquivo = File.ReadAllLines(gameFilePath);

                        if (Ler_Arquivo.Length == 0)
                        {
                            File.Delete(gameFilePath);
                            break;
                        }

                        string Codigo = Ler_Arquivo[0];
                        var arquivo = File.ReadAllLines(gameFilePath);
                        
                        string result = Post_Command_Active_Game(bot.BotName, bot.SteamID, Codigo, AppIDs);

                        if(result != "Timeout" && result != "AlreadyPurchased" && result != "RateLimited")
                        {
                            File.WriteAllLines(gameFilePath, arquivo.Skip(1).ToArray());
                        }

                       Thread.Sleep(500);
                    }
                }
            }

            Main._Main.group_auth.Invoke(new Action(() => Main._Main.group_auth.Enabled = true));
            Main._Main.groupbox_função.Invoke(new Action(() => Main._Main.groupbox_função.Enabled = true));
            Log.info($"All is Done!");
        }

        public static List<int> GetAppIDS(string FileName)
        {
            try
            {
                var outra = FileName.Replace("\\", ".");
                var split = outra.Split('.');
                string AppIDsString = split[1];

                List<int> AppIDS = AppIDsString.Split('_').Select(Int32.Parse).ToList();

                return AppIDS;
            }
            catch(Exception ex)
            {
                Log.error($"Error getting appid from games, file format should be AppID.txt {Environment.NewLine}If it is a Bundle the format must be AppID_AppID_AppID.txt");
                Log.error(ex.Message);
                return null;
            }
        }

        public static bool CheckBotIsLogeed(string BotName)
        {
            var URL = $"http://{Main._Main.txt_IPC.Text}:{Main._Main.txt_PORT.Text}/Api/Bot/{BotName}";

            if (Main._Main.ckc_usepass.Checked)
            {
                if (Main._Main.txt_passIPC.Text == "")
                {
                    Main._Main.lbl_status_auth.Text = "Please enter the IPC password";
                    Main._Main.lbl_status_auth.ForeColor = Color.Red;
                    Main._Main.txt_passIPC.Focus();
                    MessageBox.Show("Please enter the IPC password", "IPC password");
                    return false;
                }
                else
                {
                    URL = "http://" + Main._Main.txt_IPC.Text + ":" + Main._Main.txt_PORT.Text + $"/Api/Bot/{BotName}?password=" + Main._Main.txt_passIPC.Text;
                }

            }

            var response = new RequestBuilder(URL)
                .GET()
                .Execute();

            ASFResponse_BotsResume.Root asf_response = JsonConvert.DeserializeObject<ASFResponse_BotsResume.Root>(response.Content);

            var botInfo = asf_response.Result[BotName];

            return botInfo.IsConnectedAndLoggedOn;

        }

        //string result: Sucess, Fail, Timeout, DuplicateActivationCode
        public static string Post_Command_Active_Game(string BotName, long SteamID64, string codigo_game, List<int> AppIDs)
        {
            string URL = $"http://{Main._Main.txt_IPC.Text}:{Main._Main.txt_PORT.Text}/Api/Command";

            Exec_Command comando = new Exec_Command { Command = $"redeem {BotName} {codigo_game}" };

            string json = JsonConvert.SerializeObject(comando);

            var http = (HttpWebRequest)WebRequest.Create(new Uri(URL));
            http.Accept = "application/json";
            http.ContentType = "application/json";
            http.Method = "POST";
            http.PreAuthenticate = true;
            http.Headers.Add("Authentication", Main._Main.txt_passIPC.Text);


            ASCIIEncoding encoding = new ASCIIEncoding();
            Byte[] bytes = encoding.GetBytes(json);

            Stream newStream = http.GetRequestStream();
            newStream.Write(bytes, 0, bytes.Length);
            newStream.Close();

            var response = http.GetResponse();

            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var content = sr.ReadToEnd();

            File.AppendAllText("response.txt", content + "\n");


            if (content.Contains("OK/NoDetail"))
            {
                Update_Bots_DB.Add_active_Game_to_File(SteamID64, AppIDs);
                string msg = $"{BotName} - {codigo_game} - OK";
                File.AppendAllText("ActivatedSuccess.txt", msg + "\n");
                Log.info(msg);
                return "Sucess";
            }
            else if (content.Contains("Timeout/Timeout"))
            {
                Log.orange($"{BotName} - {codigo_game} - Timeout");
                return "Timeout";
            }
            else if (content.Contains("Fail/DuplicateActivationCode"))
            {
                Log.blue(content);
                File.AppendAllText("activation_fail.txt", content + "\n");
                return "DuplicateActivationCode";
            }
            else if (content.Contains("Fail/AlreadyPurchased"))
            {
                Update_Bots_DB.Add_active_Game_to_File(SteamID64, AppIDs);
                Log.orange(content);
                Log.pink($"The code will not be discarded, it will be used in the next bot!");
                return "AlreadyPurchased";
            }else if (content.Contains("Fail/RateLimited"))
            {
                Log.orange(content);
                Log.pink($"The code will not be discarded, it will be used in the next bot!");
                return "RateLimited";
            }
            else
            {
                Log.blue(content);
                File.AppendAllText("activation_fail.txt", content + "\n");
                return "Fail";
            }

        }

        public static bool CheckGameOwnsOnBot(List<int> AppIDs, BotInfo bot)
        {
            if(bot.GamesHave != null)
            {
                foreach(var appid in AppIDs)
                {
                    if (bot.GamesHave.Contains(appid))
                    {
                        return false;///ja tem algum dos jogos
                    }
                }
            }

            string URL = $"http://{Main._Main.txt_IPC.Text}:{Main._Main.txt_PORT.Text}/Api/Command";

            string AppIDsString = string.Join(",", AppIDs.ToArray());
            Exec_Command comando = new Exec_Command { Command = $"owns {bot.BotName} {AppIDsString}" };

            string json = JsonConvert.SerializeObject(comando);

            var http = (HttpWebRequest)WebRequest.Create(new Uri(URL));
            http.Accept = "application/json";
            http.ContentType = "application/json";
            http.Method = "POST";
            http.PreAuthenticate = true;
            http.Headers.Add("Authentication", Main._Main.txt_passIPC.Text);

            ASCIIEncoding encoding = new ASCIIEncoding();
            Byte[] bytes = encoding.GetBytes(json);

            Stream newStream = http.GetRequestStream();
            newStream.Write(bytes, 0, bytes.Length);
            newStream.Close();

            var response = http.GetResponse();

            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var content = sr.ReadToEnd();

            Exec_ComandResponse resp = JsonConvert.DeserializeObject<Exec_ComandResponse>(content);

            if (resp.Success)
            {
                List<string> Results = resp.Result.Split(new[] { "\n" }, StringSplitOptions.None).ToList();

                var OwnsGame = Results.Where(a=> a.Contains("Owned already") || a.Contains("Já possui")).FirstOrDefault();

                if (OwnsGame == null)
                {
                    return true;
                }
                else
                {
                    int gameIDOwned = AppIDs.Where(a => OwnsGame.Contains(a.ToString())).FirstOrDefault();

                    if(gameIDOwned != 0)
                    {
                        Log.orange($"<ASF_Owns> <{bot.BotName}> Have AppID {gameIDOwned}");
                        Update_Bots_DB.Add_active_Game_to_File(bot.SteamID, new List<int> { gameIDOwned });
                    }

                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private void btn_bots_update_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_steamAPI.Text))
            {
                MessageBox.Show("Error - Steam API Key is Null! Enter valid  Steam API key", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Thread th = new Thread(() => Update_Bots_DB.Update_Bots());
                th.Start();
            }
        }
        private void btn_open_web_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://" + txt_IPC.Text + ":" + txt_PORT.Text);
        }

        private void btn_active_paste_open_Click(object sender, EventArgs e)
        {
            Process.Start(@"active");
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (!File.Exists(@"Bots"))
            {
                System.IO.Directory.CreateDirectory(@"Bots");
            }

            if (!File.Exists(@"Active"))
            {
                System.IO.Directory.CreateDirectory(@"Active");
            }
        }

        private void txt_steamAPI_Leave(object sender, EventArgs e)
        {
            SaveConfig();
        }

        private void txt_IPC_Leave(object sender, EventArgs e)
        {
            try
            {
                Uri URI = new Uri(txt_IPC.Text);

                txt_IPC.Text = URI.Host;
            }
            catch{}

            SaveConfig();
        }

        private void txt_PORT_Leave(object sender, EventArgs e)
        {
            SaveConfig();
        }

        private void txt_passIPC_Leave(object sender, EventArgs e)
        {
            SaveConfig();
        }

    }

}
