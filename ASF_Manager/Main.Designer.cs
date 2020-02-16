namespace ASF_Manager
{
    partial class Main
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtConsole = new System.Windows.Forms.RichTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txt_IPC = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.group_auth = new System.Windows.Forms.GroupBox();
            this.txt_steamAPI = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.ckc_usepass = new MetroFramework.Controls.MetroCheckBox();
            this.txt_PORT = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.lbl_status_auth = new MetroFramework.Controls.MetroLabel();
            this.btn_check_connect = new MetroFramework.Controls.MetroButton();
            this.txt_passIPC = new MetroFramework.Controls.MetroTextBox();
            this.btn_ASF_Restart = new MetroFramework.Controls.MetroButton();
            this.btn_bot = new MetroFramework.Controls.MetroButton();
            this.groupbox_função = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.btn_bots_update = new MetroFramework.Controls.MetroButton();
            this.btn_wallet = new MetroFramework.Controls.MetroButton();
            this.btn_open_web = new MetroFramework.Controls.MetroButton();
            this.btn_active_paste_open = new MetroFramework.Controls.MetroButton();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.txt_max_process = new MetroFramework.Controls.MetroTextBox();
            this.group_auth.SuspendLayout();
            this.groupbox_função.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtConsole
            // 
            this.txtConsole.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtConsole.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtConsole.Location = new System.Drawing.Point(595, 228);
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtConsole.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtConsole.Size = new System.Drawing.Size(563, 417);
            this.txtConsole.TabIndex = 5;
            this.txtConsole.TabStop = false;
            this.txtConsole.Text = "";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.ForeColor = System.Drawing.Color.Lime;
            this.metroLabel1.Location = new System.Drawing.Point(21, 34);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(83, 19);
            this.metroLabel1.TabIndex = 6;
            this.metroLabel1.Text = "IPC Address:";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel1.UseCustomBackColor = true;
            this.metroLabel1.UseCustomForeColor = true;
            // 
            // txt_IPC
            // 
            // 
            // 
            // 
            this.txt_IPC.CustomButton.Image = null;
            this.txt_IPC.CustomButton.Location = new System.Drawing.Point(128, 1);
            this.txt_IPC.CustomButton.Name = "";
            this.txt_IPC.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_IPC.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_IPC.CustomButton.TabIndex = 1;
            this.txt_IPC.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_IPC.CustomButton.UseSelectable = true;
            this.txt_IPC.CustomButton.Visible = false;
            this.txt_IPC.ForeColor = System.Drawing.Color.Lime;
            this.txt_IPC.Lines = new string[] {
        "127.118.119.122"};
            this.txt_IPC.Location = new System.Drawing.Point(127, 30);
            this.txt_IPC.MaxLength = 32767;
            this.txt_IPC.Name = "txt_IPC";
            this.txt_IPC.PasswordChar = '\0';
            this.txt_IPC.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_IPC.SelectedText = "";
            this.txt_IPC.SelectionLength = 0;
            this.txt_IPC.SelectionStart = 0;
            this.txt_IPC.ShortcutsEnabled = true;
            this.txt_IPC.Size = new System.Drawing.Size(150, 23);
            this.txt_IPC.TabIndex = 7;
            this.txt_IPC.Text = "127.118.119.122";
            this.txt_IPC.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txt_IPC.UseCustomForeColor = true;
            this.txt_IPC.UseSelectable = true;
            this.txt_IPC.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_IPC.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txt_IPC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_IPC_KeyPress);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.ForeColor = System.Drawing.Color.Lime;
            this.metroLabel2.Location = new System.Drawing.Point(595, 206);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(64, 19);
            this.metroLabel2.TabIndex = 8;
            this.metroLabel2.Text = "Main Log";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel2.UseCustomBackColor = true;
            this.metroLabel2.UseCustomForeColor = true;
            // 
            // group_auth
            // 
            this.group_auth.Controls.Add(this.txt_steamAPI);
            this.group_auth.Controls.Add(this.metroLabel3);
            this.group_auth.Controls.Add(this.ckc_usepass);
            this.group_auth.Controls.Add(this.txt_PORT);
            this.group_auth.Controls.Add(this.metroLabel5);
            this.group_auth.Controls.Add(this.lbl_status_auth);
            this.group_auth.Controls.Add(this.btn_check_connect);
            this.group_auth.Controls.Add(this.txt_passIPC);
            this.group_auth.Controls.Add(this.txt_IPC);
            this.group_auth.Controls.Add(this.metroLabel1);
            this.group_auth.ForeColor = System.Drawing.Color.Lime;
            this.group_auth.Location = new System.Drawing.Point(23, 69);
            this.group_auth.Name = "group_auth";
            this.group_auth.Size = new System.Drawing.Size(1135, 134);
            this.group_auth.TabIndex = 10;
            this.group_auth.TabStop = false;
            this.group_auth.Text = "Authentication";
            // 
            // txt_steamAPI
            // 
            // 
            // 
            // 
            this.txt_steamAPI.CustomButton.Image = null;
            this.txt_steamAPI.CustomButton.Location = new System.Drawing.Point(214, 1);
            this.txt_steamAPI.CustomButton.Name = "";
            this.txt_steamAPI.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_steamAPI.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_steamAPI.CustomButton.TabIndex = 1;
            this.txt_steamAPI.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_steamAPI.CustomButton.UseSelectable = true;
            this.txt_steamAPI.CustomButton.Visible = false;
            this.txt_steamAPI.ForeColor = System.Drawing.Color.Lime;
            this.txt_steamAPI.Lines = new string[] {
        "64316556E0CC54AA8606D099D5E9DBFC"};
            this.txt_steamAPI.Location = new System.Drawing.Point(522, 30);
            this.txt_steamAPI.MaxLength = 32767;
            this.txt_steamAPI.Name = "txt_steamAPI";
            this.txt_steamAPI.PasswordChar = '\0';
            this.txt_steamAPI.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_steamAPI.SelectedText = "";
            this.txt_steamAPI.SelectionLength = 0;
            this.txt_steamAPI.SelectionStart = 0;
            this.txt_steamAPI.ShortcutsEnabled = true;
            this.txt_steamAPI.Size = new System.Drawing.Size(236, 23);
            this.txt_steamAPI.TabIndex = 16;
            this.txt_steamAPI.Text = "64316556E0CC54AA8606D099D5E9DBFC";
            this.txt_steamAPI.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txt_steamAPI.UseCustomForeColor = true;
            this.txt_steamAPI.UseSelectable = true;
            this.txt_steamAPI.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_steamAPI.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.ForeColor = System.Drawing.Color.Lime;
            this.metroLabel3.Location = new System.Drawing.Point(413, 32);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(103, 19);
            this.metroLabel3.TabIndex = 15;
            this.metroLabel3.Text = "Steam API Key>";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel3.UseCustomBackColor = true;
            this.metroLabel3.UseCustomForeColor = true;
            // 
            // ckc_usepass
            // 
            this.ckc_usepass.AutoSize = true;
            this.ckc_usepass.Location = new System.Drawing.Point(21, 64);
            this.ckc_usepass.Name = "ckc_usepass";
            this.ckc_usepass.Size = new System.Drawing.Size(97, 15);
            this.ckc_usepass.TabIndex = 15;
            this.ckc_usepass.Text = "Use Pass Auth";
            this.ckc_usepass.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ckc_usepass.UseCustomBackColor = true;
            this.ckc_usepass.UseCustomForeColor = true;
            this.ckc_usepass.UseSelectable = true;
            this.ckc_usepass.CheckedChanged += new System.EventHandler(this.metroCheckBox1_CheckedChanged);
            // 
            // txt_PORT
            // 
            // 
            // 
            // 
            this.txt_PORT.CustomButton.Image = null;
            this.txt_PORT.CustomButton.Location = new System.Drawing.Point(46, 1);
            this.txt_PORT.CustomButton.Name = "";
            this.txt_PORT.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_PORT.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_PORT.CustomButton.TabIndex = 1;
            this.txt_PORT.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_PORT.CustomButton.UseSelectable = true;
            this.txt_PORT.CustomButton.Visible = false;
            this.txt_PORT.ForeColor = System.Drawing.Color.Lime;
            this.txt_PORT.Lines = new string[] {
        "1719"};
            this.txt_PORT.Location = new System.Drawing.Point(326, 30);
            this.txt_PORT.MaxLength = 32767;
            this.txt_PORT.Name = "txt_PORT";
            this.txt_PORT.PasswordChar = '\0';
            this.txt_PORT.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_PORT.SelectedText = "";
            this.txt_PORT.SelectionLength = 0;
            this.txt_PORT.SelectionStart = 0;
            this.txt_PORT.ShortcutsEnabled = true;
            this.txt_PORT.Size = new System.Drawing.Size(68, 23);
            this.txt_PORT.TabIndex = 14;
            this.txt_PORT.Text = "1719";
            this.txt_PORT.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txt_PORT.UseCustomForeColor = true;
            this.txt_PORT.UseSelectable = true;
            this.txt_PORT.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_PORT.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txt_PORT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_PORT_KeyPress);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.ForeColor = System.Drawing.Color.Lime;
            this.metroLabel5.Location = new System.Drawing.Point(283, 32);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(37, 19);
            this.metroLabel5.TabIndex = 13;
            this.metroLabel5.Text = "Port:";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel5.UseCustomBackColor = true;
            this.metroLabel5.UseCustomForeColor = true;
            // 
            // lbl_status_auth
            // 
            this.lbl_status_auth.AutoSize = true;
            this.lbl_status_auth.Location = new System.Drawing.Point(148, 100);
            this.lbl_status_auth.Name = "lbl_status_auth";
            this.lbl_status_auth.Size = new System.Drawing.Size(21, 19);
            this.lbl_status_auth.TabIndex = 12;
            this.lbl_status_auth.Text = "--";
            this.lbl_status_auth.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.lbl_status_auth.UseCustomBackColor = true;
            this.lbl_status_auth.UseCustomForeColor = true;
            // 
            // btn_check_connect
            // 
            this.btn_check_connect.Location = new System.Drawing.Point(6, 95);
            this.btn_check_connect.Name = "btn_check_connect";
            this.btn_check_connect.Size = new System.Drawing.Size(124, 33);
            this.btn_check_connect.TabIndex = 11;
            this.btn_check_connect.Text = "Check Connection";
            this.btn_check_connect.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_check_connect.UseSelectable = true;
            this.btn_check_connect.Click += new System.EventHandler(this.btn_check_connect_Click);
            // 
            // txt_passIPC
            // 
            // 
            // 
            // 
            this.txt_passIPC.CustomButton.Image = null;
            this.txt_passIPC.CustomButton.Location = new System.Drawing.Point(128, 1);
            this.txt_passIPC.CustomButton.Name = "";
            this.txt_passIPC.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_passIPC.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_passIPC.CustomButton.TabIndex = 1;
            this.txt_passIPC.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_passIPC.CustomButton.UseSelectable = true;
            this.txt_passIPC.CustomButton.Visible = false;
            this.txt_passIPC.ForeColor = System.Drawing.Color.Lime;
            this.txt_passIPC.Lines = new string[0];
            this.txt_passIPC.Location = new System.Drawing.Point(127, 60);
            this.txt_passIPC.MaxLength = 32767;
            this.txt_passIPC.Name = "txt_passIPC";
            this.txt_passIPC.PasswordChar = '\0';
            this.txt_passIPC.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_passIPC.SelectedText = "";
            this.txt_passIPC.SelectionLength = 0;
            this.txt_passIPC.SelectionStart = 0;
            this.txt_passIPC.ShortcutsEnabled = true;
            this.txt_passIPC.Size = new System.Drawing.Size(150, 23);
            this.txt_passIPC.TabIndex = 9;
            this.txt_passIPC.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txt_passIPC.UseCustomForeColor = true;
            this.txt_passIPC.UseSelectable = true;
            this.txt_passIPC.Visible = false;
            this.txt_passIPC.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_passIPC.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txt_passIPC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_passIPC_KeyPress);
            // 
            // btn_ASF_Restart
            // 
            this.btn_ASF_Restart.Location = new System.Drawing.Point(6, 378);
            this.btn_ASF_Restart.Name = "btn_ASF_Restart";
            this.btn_ASF_Restart.Size = new System.Drawing.Size(124, 33);
            this.btn_ASF_Restart.TabIndex = 12;
            this.btn_ASF_Restart.Text = "Restart ASF";
            this.btn_ASF_Restart.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_ASF_Restart.UseSelectable = true;
            this.btn_ASF_Restart.Click += new System.EventHandler(this.btn_ASF_Restart_Click);
            // 
            // btn_bot
            // 
            this.btn_bot.Location = new System.Drawing.Point(17, 97);
            this.btn_bot.Name = "btn_bot";
            this.btn_bot.Size = new System.Drawing.Size(203, 33);
            this.btn_bot.TabIndex = 13;
            this.btn_bot.Text = "Active all files from \"/active\" folder";
            this.btn_bot.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_bot.UseSelectable = true;
            this.btn_bot.Click += new System.EventHandler(this.btn_bot_Click);
            // 
            // groupbox_função
            // 
            this.groupbox_função.Controls.Add(this.btn_open_web);
            this.groupbox_função.Controls.Add(this.groupBox2);
            this.groupbox_função.Controls.Add(this.btn_bots_update);
            this.groupbox_função.Controls.Add(this.btn_wallet);
            this.groupbox_função.Controls.Add(this.btn_ASF_Restart);
            this.groupbox_função.ForeColor = System.Drawing.Color.Lime;
            this.groupbox_função.Location = new System.Drawing.Point(23, 222);
            this.groupbox_função.Name = "groupbox_função";
            this.groupbox_função.Size = new System.Drawing.Size(566, 423);
            this.groupbox_função.TabIndex = 14;
            this.groupbox_função.TabStop = false;
            this.groupbox_função.Text = "Manager";
            this.groupbox_função.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_max_process);
            this.groupBox2.Controls.Add(this.metroLabel6);
            this.groupBox2.Controls.Add(this.btn_active_paste_open);
            this.groupBox2.Controls.Add(this.metroLabel4);
            this.groupBox2.Controls.Add(this.btn_bot);
            this.groupBox2.Location = new System.Drawing.Point(21, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(525, 180);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(17, 27);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(502, 19);
            this.metroLabel4.TabIndex = 16;
            this.metroLabel4.Text = "Remember to update the database if you have manually activate games on accounts";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel4.UseCustomBackColor = true;
            this.metroLabel4.UseCustomForeColor = true;
            // 
            // btn_bots_update
            // 
            this.btn_bots_update.Location = new System.Drawing.Point(21, 46);
            this.btn_bots_update.Name = "btn_bots_update";
            this.btn_bots_update.Size = new System.Drawing.Size(124, 33);
            this.btn_bots_update.TabIndex = 15;
            this.btn_bots_update.Text = "Update Bots Database";
            this.btn_bots_update.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_bots_update.UseSelectable = true;
            this.btn_bots_update.Click += new System.EventHandler(this.btn_bots_update_Click);
            // 
            // btn_wallet
            // 
            this.btn_wallet.Location = new System.Drawing.Point(136, 378);
            this.btn_wallet.Name = "btn_wallet";
            this.btn_wallet.Size = new System.Drawing.Size(124, 33);
            this.btn_wallet.TabIndex = 14;
            this.btn_wallet.Text = "Check Wallet Value";
            this.btn_wallet.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_wallet.UseSelectable = true;
            this.btn_wallet.Click += new System.EventHandler(this.btn_wallet_Click);
            // 
            // btn_open_web
            // 
            this.btn_open_web.Location = new System.Drawing.Point(266, 378);
            this.btn_open_web.Name = "btn_open_web";
            this.btn_open_web.Size = new System.Drawing.Size(153, 33);
            this.btn_open_web.TabIndex = 17;
            this.btn_open_web.Text = "Open ASF web interface";
            this.btn_open_web.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_open_web.UseSelectable = true;
            this.btn_open_web.Click += new System.EventHandler(this.btn_open_web_Click);
            // 
            // btn_active_paste_open
            // 
            this.btn_active_paste_open.Location = new System.Drawing.Point(427, 141);
            this.btn_active_paste_open.Name = "btn_active_paste_open";
            this.btn_active_paste_open.Size = new System.Drawing.Size(95, 33);
            this.btn_active_paste_open.TabIndex = 17;
            this.btn_active_paste_open.Text = "Open Folder";
            this.btn_active_paste_open.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_active_paste_open.UseSelectable = true;
            this.btn_active_paste_open.Click += new System.EventHandler(this.btn_active_paste_open_Click);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(17, 61);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(325, 19);
            this.metroLabel6.TabIndex = 18;
            this.metroLabel6.Text = "maximum number of codes activated in each account:";
            this.metroLabel6.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel6.UseCustomBackColor = true;
            this.metroLabel6.UseCustomForeColor = true;
            // 
            // txt_max_process
            // 
            // 
            // 
            // 
            this.txt_max_process.CustomButton.Image = null;
            this.txt_max_process.CustomButton.Location = new System.Drawing.Point(16, 1);
            this.txt_max_process.CustomButton.Name = "";
            this.txt_max_process.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_max_process.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_max_process.CustomButton.TabIndex = 1;
            this.txt_max_process.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_max_process.CustomButton.UseSelectable = true;
            this.txt_max_process.CustomButton.Visible = false;
            this.txt_max_process.ForeColor = System.Drawing.Color.Lime;
            this.txt_max_process.Lines = new string[] {
        "25"};
            this.txt_max_process.Location = new System.Drawing.Point(348, 61);
            this.txt_max_process.MaxLength = 32767;
            this.txt_max_process.Name = "txt_max_process";
            this.txt_max_process.PasswordChar = '\0';
            this.txt_max_process.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_max_process.SelectedText = "";
            this.txt_max_process.SelectionLength = 0;
            this.txt_max_process.SelectionStart = 0;
            this.txt_max_process.ShortcutsEnabled = true;
            this.txt_max_process.Size = new System.Drawing.Size(38, 23);
            this.txt_max_process.TabIndex = 19;
            this.txt_max_process.Text = "25";
            this.txt_max_process.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txt_max_process.UseCustomForeColor = true;
            this.txt_max_process.UseSelectable = true;
            this.txt_max_process.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_max_process.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(1164, 668);
            this.Controls.Add(this.groupbox_função);
            this.Controls.Add(this.group_auth);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtConsole);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "ASF-Manager";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.group_auth.ResumeLayout(false);
            this.group_auth.PerformLayout();
            this.groupbox_função.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RichTextBox txtConsole;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton btn_ASF_Restart;
        private MetroFramework.Controls.MetroButton btn_bot;
        private MetroFramework.Controls.MetroButton btn_wallet;
        public System.Windows.Forms.GroupBox group_auth;
        public MetroFramework.Controls.MetroLabel metroLabel1;
        public MetroFramework.Controls.MetroTextBox txt_IPC;
        public MetroFramework.Controls.MetroTextBox txt_passIPC;
        public MetroFramework.Controls.MetroButton btn_check_connect;
        public MetroFramework.Controls.MetroLabel lbl_status_auth;
        public MetroFramework.Controls.MetroCheckBox ckc_usepass;
        public MetroFramework.Controls.MetroTextBox txt_PORT;
        public MetroFramework.Controls.MetroLabel metroLabel5;
        public MetroFramework.Controls.MetroTextBox txt_steamAPI;
        public MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.GroupBox groupBox2;
        public MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroButton btn_bots_update;
        public MetroFramework.Controls.MetroButton btn_open_web;
        private MetroFramework.Controls.MetroButton btn_active_paste_open;
        public MetroFramework.Controls.MetroTextBox txt_max_process;
        public MetroFramework.Controls.MetroLabel metroLabel6;
        public System.Windows.Forms.GroupBox groupbox_função;
    }
}

