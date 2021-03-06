﻿using ASF_Manager.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

            ASFResponse_MainConfig.Root result = JsonConvert.DeserializeObject<ASFResponse_MainConfig.Root>(response);

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

            ASFResponse_BotsResume.Root result = JsonConvert.DeserializeObject<ASFResponse_BotsResume.Root>(response);

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

        private void btn_wallet_Click(object sender, EventArgs e)
        {
            var URL = $"http://{Main._Main.txt_IPC.Text}:{Main._Main.txt_PORT.Text}/Api/Bot/asf";

            var response = new RequestBuilder(URL)
                .GET()
                .Execute();

            ASFResponse_BotsResume.Root asf_response = JsonConvert.DeserializeObject<ASFResponse_BotsResume.Root>(response);

            foreach (var asf_bot in asf_response.Result)
            {
                Log.info($"{asf_bot.Value.BotName} => {asf_bot.Value.WalletBalance}");
            }

            Log.pink("Attention: this function is still not converting correctly to the account currency");
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
            foreach (var game in gamesFiles)
            {
                int max_process = Convert.ToInt32(Main._Main.txt_max_process.Text);

                if (process + 1 > max_process)
                {
                    Log.pink(max_process + " files processed, please wait a few minutes, not to be blocked by the steam network (Rate Limit Exceeded)");
                    break;
                }

                Log.orange("Processing " + game);

                string ID_GAME;

                var outra = game.Replace("\\", ".");
                var split = outra.Split('.');
                ID_GAME = split[1];

                int lines = File.ReadAllLines(game).Length;

                if (lines < 1)
                {
                    //Log.orange("AppID: " + ID_GAME + " Will not be used because it has 0 codes!");
                    //Log.error("Deleting file " + game);
                    File.Delete(game);
                    continue;
                }

                process = process + 1;

                foreach (var bot in Bots)
                {
                    if (!bot.GamesHave.Contains(ID_GAME))//se não tiver o jogo fazer a ativação
                    {
                        string[] Ler_Arquivo = File.ReadAllLines(game);
                        if (Ler_Arquivo.Length == 0)
                        {
                            File.Delete(game);
                            break;
                        }
                        string Codigo = Ler_Arquivo[0];
                        var arquivo = File.ReadAllLines(game);
                        File.WriteAllLines(game, arquivo.Skip(1).ToArray());

                        Post_Command_Active_Game(bot.BotName, bot.SteamID, Codigo, ID_GAME);
                    }
                }
            }

            Main._Main.group_auth.Invoke(new Action(() => Main._Main.group_auth.Enabled = true));
            Main._Main.groupbox_função.Invoke(new Action(() => Main._Main.groupbox_função.Enabled = true));

        }

        public static void Post_Command_Active_Game(string BotName, long SteamID64, string codigo_game, string AppID)
        {
            string URL = $"http://{Main._Main.txt_IPC.Text}:{Main._Main.txt_PORT.Text}/Api/Command";

            Exec_Command comando = new Exec_Command { Command = "redeem " + BotName + " " + codigo_game };

            string json = JsonConvert.SerializeObject(comando);

            var http = (HttpWebRequest)WebRequest.Create(new Uri(URL));
            http.Accept = "application/json";
            http.ContentType = "application/json";
            http.Method = "POST";


            ASCIIEncoding encoding = new ASCIIEncoding();
            Byte[] bytes = encoding.GetBytes(json);

            Stream newStream = http.GetRequestStream();
            newStream.Write(bytes, 0, bytes.Length);
            newStream.Close();

            var response = http.GetResponse();

            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var content = sr.ReadToEnd();

            bool sucesso = content.Contains("OK/NoDetail");


            if (sucesso == false)
            {
                Log.blue(content);
                File.AppendAllText("activation_fail.txt", content + "\n");

            }
            else
            {
                Update_Bots_DB.Add_active_Game_to_File(SteamID64, AppID);
                Log.info($"{BotName} - {codigo_game} - OK");
            }

            File.AppendAllText("response.txt", content + "\n");
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
    }

}
