namespace Launcher
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tbAccount = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.MaskedTextBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.lbAccount = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lbStatus = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.PictureBox();
            this.btnSettings = new System.Windows.Forms.PictureBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnRegister = new System.Windows.Forms.PictureBox();
            this.panelRegister = new System.Windows.Forms.Panel();
            this.lbRules = new System.Windows.Forms.LinkLabel();
            this.btnRegCancel = new System.Windows.Forms.PictureBox();
            this.btnRegOk = new System.Windows.Forms.PictureBox();
            this.lbRegBirth = new System.Windows.Forms.Label();
            this.lbRegEmail = new System.Windows.Forms.Label();
            this.lbRegPassword = new System.Windows.Forms.Label();
            this.lbRegAccount = new System.Windows.Forms.Label();
            this.tbRegEmail = new System.Windows.Forms.TextBox();
            this.cbRegGender = new System.Windows.Forms.ComboBox();
            this.tbRegBirth = new System.Windows.Forms.TextBox();
            this.tbRegPassword = new System.Windows.Forms.MaskedTextBox();
            this.tbRegAccount = new System.Windows.Forms.TextBox();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.btnSync = new System.Windows.Forms.PictureBox();
            this.btnSettingsCancel = new System.Windows.Forms.PictureBox();
            this.btnSettingsOk = new System.Windows.Forms.PictureBox();
            this.lbResolution = new System.Windows.Forms.ListBox();
            this.cbLogins = new System.Windows.Forms.CheckBox();
            this.cbFullscreen = new System.Windows.Forms.CheckBox();
            this.cbVsync = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRegister)).BeginInit();
            this.panelRegister.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRegCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRegOk)).BeginInit();
            this.panelSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSync)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSettingsCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSettingsOk)).BeginInit();
            this.SuspendLayout();
            // 
            // tbAccount
            // 
            this.tbAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tbAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbAccount.Enabled = false;
            this.tbAccount.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.tbAccount.Location = new System.Drawing.Point(15, 85);
            this.tbAccount.Name = "tbAccount";
            this.tbAccount.Size = new System.Drawing.Size(189, 21);
            this.tbAccount.TabIndex = 0;
            // 
            // tbPassword
            // 
            this.tbPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tbPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPassword.Enabled = false;
            this.tbPassword.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.tbPassword.Location = new System.Drawing.Point(15, 124);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '•';
            this.tbPassword.Size = new System.Drawing.Size(189, 21);
            this.tbPassword.TabIndex = 1;
            this.tbPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbPassword_KeyUp);
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.BackColor = System.Drawing.Color.Transparent;
            this.lbPassword.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lbPassword.Location = new System.Drawing.Point(12, 108);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(53, 13);
            this.lbPassword.TabIndex = 4;
            this.lbPassword.Text = "Password";
            // 
            // lbAccount
            // 
            this.lbAccount.AutoSize = true;
            this.lbAccount.BackColor = System.Drawing.Color.Transparent;
            this.lbAccount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lbAccount.Location = new System.Drawing.Point(12, 69);
            this.lbAccount.Name = "lbAccount";
            this.lbAccount.Size = new System.Drawing.Size(46, 13);
            this.lbAccount.TabIndex = 5;
            this.lbAccount.Text = "Account";
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.progressBar.Location = new System.Drawing.Point(12, 261);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(192, 14);
            this.progressBar.TabIndex = 6;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.BackColor = System.Drawing.Color.Transparent;
            this.lbStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lbStatus.Location = new System.Drawing.Point(10, 245);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(73, 13);
            this.lbStatus.TabIndex = 8;
            this.lbStatus.Text = "Connecting...";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Image = global::Launcher.Properties.Resources.close_normal;
            this.btnClose.Location = new System.Drawing.Point(183, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 9;
            this.btnClose.TabStop = false;
            this.btnClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseDown);
            this.btnClose.MouseEnter += new System.EventHandler(this.btnClose_MouseEnter);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            this.btnClose.MouseHover += new System.EventHandler(this.btnClose_MouseHover);
            this.btnClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseUp);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Transparent;
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnStart.Image = global::Launcher.Properties.Resources.start_normal;
            this.btnStart.Location = new System.Drawing.Point(85, 159);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(119, 36);
            this.btnStart.TabIndex = 10;
            this.btnStart.TabStop = false;
            this.btnStart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnStart_MouseDown);
            this.btnStart.MouseEnter += new System.EventHandler(this.btnStart_MouseEnter);
            this.btnStart.MouseLeave += new System.EventHandler(this.btnStart_MouseLeave);
            this.btnStart.MouseHover += new System.EventHandler(this.btnStart_MouseHover);
            this.btnStart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnStart_MouseUp);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSettings.Image = global::Launcher.Properties.Resources.settings_normal;
            this.btnSettings.Location = new System.Drawing.Point(156, 23);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(21, 21);
            this.btnSettings.TabIndex = 11;
            this.btnSettings.TabStop = false;
            this.btnSettings.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSettings_MouseDown);
            this.btnSettings.MouseEnter += new System.EventHandler(this.btnSettings_MouseEnter);
            this.btnSettings.MouseLeave += new System.EventHandler(this.btnSettings_MouseLeave);
            this.btnSettings.MouseHover += new System.EventHandler(this.btnSettings_MouseHover);
            this.btnSettings.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSettings_MouseUp);
            // 
            // toolTip
            // 
            this.toolTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.toolTip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.Transparent;
            this.btnRegister.Image = global::Launcher.Properties.Resources.register_normal;
            this.btnRegister.Location = new System.Drawing.Point(52, 163);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(27, 27);
            this.btnRegister.TabIndex = 12;
            this.btnRegister.TabStop = false;
            this.btnRegister.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRegister_MouseDown);
            this.btnRegister.MouseEnter += new System.EventHandler(this.btnRegister_MouseEnter);
            this.btnRegister.MouseLeave += new System.EventHandler(this.btnRegister_MouseLeave);
            this.btnRegister.MouseHover += new System.EventHandler(this.btnRegister_MouseHover);
            this.btnRegister.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnRegister_MouseUp);
            // 
            // panelRegister
            // 
            this.panelRegister.BackColor = System.Drawing.Color.Transparent;
            this.panelRegister.BackgroundImage = global::Launcher.Properties.Resources.Register_BG;
            this.panelRegister.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelRegister.Controls.Add(this.lbRules);
            this.panelRegister.Controls.Add(this.btnRegCancel);
            this.panelRegister.Controls.Add(this.btnRegOk);
            this.panelRegister.Controls.Add(this.lbRegBirth);
            this.panelRegister.Controls.Add(this.lbRegEmail);
            this.panelRegister.Controls.Add(this.lbRegPassword);
            this.panelRegister.Controls.Add(this.lbRegAccount);
            this.panelRegister.Controls.Add(this.tbRegEmail);
            this.panelRegister.Controls.Add(this.cbRegGender);
            this.panelRegister.Controls.Add(this.tbRegBirth);
            this.panelRegister.Controls.Add(this.tbRegPassword);
            this.panelRegister.Controls.Add(this.tbRegAccount);
            this.panelRegister.Location = new System.Drawing.Point(3, 48);
            this.panelRegister.Name = "panelRegister";
            this.panelRegister.Size = new System.Drawing.Size(209, 234);
            this.panelRegister.TabIndex = 13;
            this.panelRegister.Visible = false;
            // 
            // lbRules
            // 
            this.lbRules.AutoSize = true;
            this.lbRules.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lbRules.LinkColor = System.Drawing.Color.White;
            this.lbRules.Location = new System.Drawing.Point(167, 8);
            this.lbRules.Name = "lbRules";
            this.lbRules.Size = new System.Drawing.Size(33, 13);
            this.lbRules.TabIndex = 16;
            this.lbRules.TabStop = true;
            this.lbRules.Text = "Rules";
            this.lbRules.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbRules_LinkClicked);
            // 
            // btnRegCancel
            // 
            this.btnRegCancel.Image = global::Launcher.Properties.Resources.cancel_normal;
            this.btnRegCancel.Location = new System.Drawing.Point(136, 184);
            this.btnRegCancel.Name = "btnRegCancel";
            this.btnRegCancel.Size = new System.Drawing.Size(38, 38);
            this.btnRegCancel.TabIndex = 15;
            this.btnRegCancel.TabStop = false;
            this.btnRegCancel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRegCancel_MouseDown);
            this.btnRegCancel.MouseEnter += new System.EventHandler(this.btnRegCancel_MouseEnter);
            this.btnRegCancel.MouseLeave += new System.EventHandler(this.btnRegCancel_MouseLeave);
            this.btnRegCancel.MouseHover += new System.EventHandler(this.btnRegCancel_MouseHover);
            this.btnRegCancel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnRegCancel_MouseUp);
            // 
            // btnRegOk
            // 
            this.btnRegOk.Image = global::Launcher.Properties.Resources.ok_normal;
            this.btnRegOk.Location = new System.Drawing.Point(38, 184);
            this.btnRegOk.Name = "btnRegOk";
            this.btnRegOk.Size = new System.Drawing.Size(38, 38);
            this.btnRegOk.TabIndex = 14;
            this.btnRegOk.TabStop = false;
            this.btnRegOk.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRegOk_MouseDown);
            this.btnRegOk.MouseEnter += new System.EventHandler(this.btnRegOk_MouseEnter);
            this.btnRegOk.MouseLeave += new System.EventHandler(this.btnRegOk_MouseLeave);
            this.btnRegOk.MouseHover += new System.EventHandler(this.btnRegOk_MouseHover);
            this.btnRegOk.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnRegOk_MouseUp);
            // 
            // lbRegBirth
            // 
            this.lbRegBirth.AutoSize = true;
            this.lbRegBirth.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lbRegBirth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lbRegBirth.Location = new System.Drawing.Point(81, 131);
            this.lbRegBirth.Name = "lbRegBirth";
            this.lbRegBirth.Size = new System.Drawing.Size(51, 13);
            this.lbRegBirth.TabIndex = 9;
            this.lbRegBirth.Text = "Birthyear";
            // 
            // lbRegEmail
            // 
            this.lbRegEmail.AutoSize = true;
            this.lbRegEmail.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lbRegEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lbRegEmail.Location = new System.Drawing.Point(7, 86);
            this.lbRegEmail.Name = "lbRegEmail";
            this.lbRegEmail.Size = new System.Drawing.Size(35, 13);
            this.lbRegEmail.TabIndex = 8;
            this.lbRegEmail.Text = "E-Mail";
            // 
            // lbRegPassword
            // 
            this.lbRegPassword.AutoSize = true;
            this.lbRegPassword.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lbRegPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lbRegPassword.Location = new System.Drawing.Point(8, 47);
            this.lbRegPassword.Name = "lbRegPassword";
            this.lbRegPassword.Size = new System.Drawing.Size(53, 13);
            this.lbRegPassword.TabIndex = 7;
            this.lbRegPassword.Text = "Password";
            // 
            // lbRegAccount
            // 
            this.lbRegAccount.AutoSize = true;
            this.lbRegAccount.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lbRegAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lbRegAccount.Location = new System.Drawing.Point(6, 8);
            this.lbRegAccount.Name = "lbRegAccount";
            this.lbRegAccount.Size = new System.Drawing.Size(46, 13);
            this.lbRegAccount.TabIndex = 6;
            this.lbRegAccount.Text = "Account";
            // 
            // tbRegEmail
            // 
            this.tbRegEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tbRegEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRegEmail.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbRegEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.tbRegEmail.Location = new System.Drawing.Point(9, 102);
            this.tbRegEmail.MaxLength = 254;
            this.tbRegEmail.Name = "tbRegEmail";
            this.tbRegEmail.Size = new System.Drawing.Size(143, 21);
            this.tbRegEmail.TabIndex = 2;
            // 
            // cbRegGender
            // 
            this.cbRegGender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.cbRegGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRegGender.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbRegGender.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.cbRegGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.cbRegGender.FormattingEnabled = true;
            this.cbRegGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cbRegGender.Location = new System.Drawing.Point(9, 154);
            this.cbRegGender.Name = "cbRegGender";
            this.cbRegGender.Size = new System.Drawing.Size(121, 21);
            this.cbRegGender.TabIndex = 4;
            // 
            // tbRegBirth
            // 
            this.tbRegBirth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tbRegBirth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRegBirth.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbRegBirth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.tbRegBirth.Location = new System.Drawing.Point(9, 128);
            this.tbRegBirth.MaxLength = 4;
            this.tbRegBirth.Name = "tbRegBirth";
            this.tbRegBirth.Size = new System.Drawing.Size(66, 21);
            this.tbRegBirth.TabIndex = 3;
            // 
            // tbRegPassword
            // 
            this.tbRegPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tbRegPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRegPassword.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbRegPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.tbRegPassword.Location = new System.Drawing.Point(9, 63);
            this.tbRegPassword.Name = "tbRegPassword";
            this.tbRegPassword.PasswordChar = '*';
            this.tbRegPassword.Size = new System.Drawing.Size(143, 21);
            this.tbRegPassword.TabIndex = 1;
            this.tbRegPassword.TextChanged += new System.EventHandler(this.tbRegPassword_TextChanged);
            // 
            // tbRegAccount
            // 
            this.tbRegAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tbRegAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRegAccount.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbRegAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.tbRegAccount.Location = new System.Drawing.Point(9, 24);
            this.tbRegAccount.MaxLength = 20;
            this.tbRegAccount.Name = "tbRegAccount";
            this.tbRegAccount.Size = new System.Drawing.Size(143, 21);
            this.tbRegAccount.TabIndex = 0;
            // 
            // panelSettings
            // 
            this.panelSettings.BackColor = System.Drawing.Color.Transparent;
            this.panelSettings.BackgroundImage = global::Launcher.Properties.Resources.Register_BG;
            this.panelSettings.Controls.Add(this.btnSync);
            this.panelSettings.Controls.Add(this.btnSettingsCancel);
            this.panelSettings.Controls.Add(this.btnSettingsOk);
            this.panelSettings.Controls.Add(this.lbResolution);
            this.panelSettings.Controls.Add(this.cbLogins);
            this.panelSettings.Controls.Add(this.cbFullscreen);
            this.panelSettings.Controls.Add(this.cbVsync);
            this.panelSettings.Location = new System.Drawing.Point(3, 48);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(209, 234);
            this.panelSettings.TabIndex = 17;
            this.panelSettings.Visible = false;
            // 
            // btnSync
            // 
            this.btnSync.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSync.Image = global::Launcher.Properties.Resources.sync_normal;
            this.btnSync.Location = new System.Drawing.Point(153, 128);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(27, 27);
            this.btnSync.TabIndex = 17;
            this.btnSync.TabStop = false;
            this.btnSync.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSync_MouseDown);
            this.btnSync.MouseEnter += new System.EventHandler(this.btnSync_MouseEnter);
            this.btnSync.MouseLeave += new System.EventHandler(this.btnSync_MouseLeave);
            this.btnSync.MouseHover += new System.EventHandler(this.btnSync_MouseHover);
            this.btnSync.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSync_MouseUp);
            // 
            // btnSettingsCancel
            // 
            this.btnSettingsCancel.Image = global::Launcher.Properties.Resources.cancel_normal;
            this.btnSettingsCancel.Location = new System.Drawing.Point(136, 184);
            this.btnSettingsCancel.Name = "btnSettingsCancel";
            this.btnSettingsCancel.Size = new System.Drawing.Size(38, 38);
            this.btnSettingsCancel.TabIndex = 16;
            this.btnSettingsCancel.TabStop = false;
            this.btnSettingsCancel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSettingsCancel_MouseDown);
            this.btnSettingsCancel.MouseEnter += new System.EventHandler(this.btnSettingsCancel_MouseEnter);
            this.btnSettingsCancel.MouseLeave += new System.EventHandler(this.btnSettingsCancel_MouseLeave);
            this.btnSettingsCancel.MouseHover += new System.EventHandler(this.btnSettingsCancel_MouseHover);
            this.btnSettingsCancel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSettingsCancel_MouseUp);
            // 
            // btnSettingsOk
            // 
            this.btnSettingsOk.Image = global::Launcher.Properties.Resources.ok_normal;
            this.btnSettingsOk.Location = new System.Drawing.Point(38, 184);
            this.btnSettingsOk.Name = "btnSettingsOk";
            this.btnSettingsOk.Size = new System.Drawing.Size(38, 38);
            this.btnSettingsOk.TabIndex = 15;
            this.btnSettingsOk.TabStop = false;
            this.btnSettingsOk.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSettingsOk_MouseDown);
            this.btnSettingsOk.MouseEnter += new System.EventHandler(this.btnSettingsOk_MouseEnter);
            this.btnSettingsOk.MouseLeave += new System.EventHandler(this.btnSettingsOk_MouseLeave);
            this.btnSettingsOk.MouseHover += new System.EventHandler(this.btnSettingsOk_MouseHover);
            this.btnSettingsOk.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSettingsOk_MouseUp);
            // 
            // lbResolution
            // 
            this.lbResolution.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.lbResolution.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbResolution.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lbResolution.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lbResolution.FormattingEnabled = true;
            this.lbResolution.Location = new System.Drawing.Point(9, 8);
            this.lbResolution.Name = "lbResolution";
            this.lbResolution.Size = new System.Drawing.Size(192, 93);
            this.lbResolution.TabIndex = 3;
            // 
            // cbLogins
            // 
            this.cbLogins.AutoSize = true;
            this.cbLogins.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLogins.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.cbLogins.Location = new System.Drawing.Point(9, 154);
            this.cbLogins.Name = "cbLogins";
            this.cbLogins.Size = new System.Drawing.Size(83, 17);
            this.cbLogins.TabIndex = 2;
            this.cbLogins.Text = "Save Logins";
            this.cbLogins.UseVisualStyleBackColor = true;
            // 
            // cbFullscreen
            // 
            this.cbFullscreen.AutoSize = true;
            this.cbFullscreen.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.cbFullscreen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.cbFullscreen.Location = new System.Drawing.Point(9, 110);
            this.cbFullscreen.Name = "cbFullscreen";
            this.cbFullscreen.Size = new System.Drawing.Size(74, 17);
            this.cbFullscreen.TabIndex = 1;
            this.cbFullscreen.Text = "Fullscreen";
            this.cbFullscreen.UseVisualStyleBackColor = true;
            // 
            // cbVsync
            // 
            this.cbVsync.AutoSize = true;
            this.cbVsync.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.cbVsync.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.cbVsync.Location = new System.Drawing.Point(9, 131);
            this.cbVsync.Name = "cbVsync";
            this.cbVsync.Size = new System.Drawing.Size(59, 17);
            this.cbVsync.TabIndex = 0;
            this.cbVsync.Text = "V-Sync";
            this.cbVsync.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BackgroundImage = global::Launcher.Properties.Resources.Launcher_BG;
            this.ClientSize = new System.Drawing.Size(216, 300);
            this.Controls.Add(this.panelSettings);
            this.Controls.Add(this.panelRegister);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lbAccount);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbAccount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cosmic-Ascension Launcher";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRegister)).EndInit();
            this.panelRegister.ResumeLayout(false);
            this.panelRegister.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRegCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRegOk)).EndInit();
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSync)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSettingsCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSettingsOk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbAccount;
        private System.Windows.Forms.MaskedTextBox tbPassword;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label lbAccount;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.PictureBox btnStart;
        private System.Windows.Forms.PictureBox btnSettings;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.PictureBox btnRegister;
        private System.Windows.Forms.Panel panelRegister;
        private System.Windows.Forms.Label lbRegBirth;
        private System.Windows.Forms.Label lbRegEmail;
        private System.Windows.Forms.Label lbRegPassword;
        private System.Windows.Forms.Label lbRegAccount;
        private System.Windows.Forms.TextBox tbRegEmail;
        private System.Windows.Forms.ComboBox cbRegGender;
        private System.Windows.Forms.TextBox tbRegBirth;
        private System.Windows.Forms.MaskedTextBox tbRegPassword;
        private System.Windows.Forms.TextBox tbRegAccount;
        private System.Windows.Forms.PictureBox btnRegCancel;
        private System.Windows.Forms.PictureBox btnRegOk;
        private System.Windows.Forms.LinkLabel lbRules;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.CheckBox cbLogins;
        private System.Windows.Forms.CheckBox cbFullscreen;
        private System.Windows.Forms.CheckBox cbVsync;
        private System.Windows.Forms.ListBox lbResolution;
        private System.Windows.Forms.PictureBox btnSettingsCancel;
        private System.Windows.Forms.PictureBox btnSettingsOk;
        private System.Windows.Forms.PictureBox btnSync;
    }
}

