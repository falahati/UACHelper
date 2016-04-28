namespace UACHelper.Sample
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_username = new System.Windows.Forms.Label();
            this.lbl_isAdministrator = new System.Windows.Forms.Label();
            this.lbl_isElevated = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_behavior = new System.Windows.Forms.Label();
            this.btn_restartElevated = new System.Windows.Forms.Button();
            this.btn_restartNormal = new System.Windows.Forms.Button();
            this.lbl_uacEnable = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cb_userConsent = new System.Windows.Forms.CheckBox();
            this.cb_forceSecureScreen = new System.Windows.Forms.CheckBox();
            this.lbl_5 = new System.Windows.Forms.Label();
            this.lbl_0 = new System.Windows.Forms.Label();
            this.lbl_4 = new System.Windows.Forms.Label();
            this.lbl_1 = new System.Windows.Forms.Label();
            this.lbl_3 = new System.Windows.Forms.Label();
            this.lbl_2 = new System.Windows.Forms.Label();
            this.tb_uacLevel = new System.Windows.Forms.TrackBar();
            this.btn_disable = new System.Windows.Forms.Button();
            this.btn_enable = new System.Windows.Forms.Button();
            this.lb_processes = new System.Windows.Forms.ListBox();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.lbl_uacSupported = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_sessionOwner = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_sameUser = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.btn_exit = new System.Windows.Forms.Button();
            this.gb_information = new System.Windows.Forms.GroupBox();
            this.gb_status = new System.Windows.Forms.GroupBox();
            this.gb_uac = new System.Windows.Forms.GroupBox();
            this.gb_uacNotifications = new System.Windows.Forms.GroupBox();
            this.gb_processes = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_customDialog = new System.Windows.Forms.Button();
            this.btn_folderDialog = new System.Windows.Forms.Button();
            this.btn_fontDialog = new System.Windows.Forms.Button();
            this.btn_saveFileDialog = new System.Windows.Forms.Button();
            this.btn_openFileDialog = new System.Windows.Forms.Button();
            this.btn_colorBox = new System.Windows.Forms.Button();
            this.btn_messageBox = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tb_uacLevel)).BeginInit();
            this.gb_information.SuspendLayout();
            this.gb_status.SuspendLayout();
            this.gb_uac.SuspendLayout();
            this.gb_uacNotifications.SuspendLayout();
            this.gb_processes.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Process Owner:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Is Administrator?";
            // 
            // lbl_username
            // 
            this.lbl_username.Location = new System.Drawing.Point(122, 23);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(164, 13);
            this.lbl_username.TabIndex = 1;
            this.lbl_username.Text = "%USERNAME%";
            // 
            // lbl_isAdministrator
            // 
            this.lbl_isAdministrator.Location = new System.Drawing.Point(122, 49);
            this.lbl_isAdministrator.Name = "lbl_isAdministrator";
            this.lbl_isAdministrator.Size = new System.Drawing.Size(164, 13);
            this.lbl_isAdministrator.TabIndex = 3;
            this.lbl_isAdministrator.Text = "%ADMINISTRATOR%";
            // 
            // lbl_isElevated
            // 
            this.lbl_isElevated.Location = new System.Drawing.Point(122, 23);
            this.lbl_isElevated.Name = "lbl_isElevated";
            this.lbl_isElevated.Size = new System.Drawing.Size(164, 13);
            this.lbl_isElevated.TabIndex = 5;
            this.lbl_isElevated.Text = "%ELEVATED%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Is Elevated?";
            // 
            // lbl_behavior
            // 
            this.lbl_behavior.Location = new System.Drawing.Point(122, 48);
            this.lbl_behavior.Name = "lbl_behavior";
            this.lbl_behavior.Size = new System.Drawing.Size(164, 13);
            this.lbl_behavior.TabIndex = 7;
            this.lbl_behavior.Text = "%BEHAVIOR%";
            // 
            // btn_restartElevated
            // 
            this.btn_restartElevated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_restartElevated.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_restartElevated.Location = new System.Drawing.Point(17, 78);
            this.btn_restartElevated.Name = "btn_restartElevated";
            this.btn_restartElevated.Size = new System.Drawing.Size(131, 23);
            this.btn_restartElevated.TabIndex = 10;
            this.btn_restartElevated.Text = "Restart Elevated";
            this.btn_restartElevated.UseVisualStyleBackColor = true;
            this.btn_restartElevated.Click += new System.EventHandler(this.RestartElevated);
            // 
            // btn_restartNormal
            // 
            this.btn_restartNormal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_restartNormal.Location = new System.Drawing.Point(155, 78);
            this.btn_restartNormal.Name = "btn_restartNormal";
            this.btn_restartNormal.Size = new System.Drawing.Size(131, 23);
            this.btn_restartNormal.TabIndex = 11;
            this.btn_restartNormal.Text = "Restart Normal";
            this.btn_restartNormal.UseVisualStyleBackColor = true;
            this.btn_restartNormal.Click += new System.EventHandler(this.RestartNormal);
            // 
            // lbl_uacEnable
            // 
            this.lbl_uacEnable.Location = new System.Drawing.Point(125, 49);
            this.lbl_uacEnable.Name = "lbl_uacEnable";
            this.lbl_uacEnable.Size = new System.Drawing.Size(161, 13);
            this.lbl_uacEnable.TabIndex = 9;
            this.lbl_uacEnable.Text = "%UACENABLE%";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(14, 49);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(82, 13);
            this.label16.TabIndex = 8;
            this.label16.Text = "Is UAC Enable?";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(14, 49);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(89, 13);
            this.label18.TabIndex = 6;
            this.label18.Text = "Default Behavior:";
            // 
            // cb_userConsent
            // 
            this.cb_userConsent.AutoSize = true;
            this.cb_userConsent.Location = new System.Drawing.Point(6, 196);
            this.cb_userConsent.Name = "cb_userConsent";
            this.cb_userConsent.Size = new System.Drawing.Size(274, 30);
            this.cb_userConsent.TabIndex = 30;
            this.cb_userConsent.Text = "Allow Standard Users to start elevated processes by \r\nentering the Administrator " +
    "Credentials";
            this.cb_userConsent.UseVisualStyleBackColor = true;
            // 
            // cb_forceSecureScreen
            // 
            this.cb_forceSecureScreen.AutoSize = true;
            this.cb_forceSecureScreen.Location = new System.Drawing.Point(6, 178);
            this.cb_forceSecureScreen.Name = "cb_forceSecureScreen";
            this.cb_forceSecureScreen.Size = new System.Drawing.Size(202, 17);
            this.cb_forceSecureScreen.TabIndex = 29;
            this.cb_forceSecureScreen.Text = "Force Secure Screen In All Situations";
            this.cb_forceSecureScreen.UseVisualStyleBackColor = true;
            // 
            // lbl_5
            // 
            this.lbl_5.AutoSize = true;
            this.lbl_5.Location = new System.Drawing.Point(36, 23);
            this.lbl_5.Name = "lbl_5";
            this.lbl_5.Size = new System.Drawing.Size(175, 13);
            this.lbl_5.TabIndex = 23;
            this.lbl_5.Text = "Password Prompt In Secure Screen";
            // 
            // lbl_0
            // 
            this.lbl_0.AutoSize = true;
            this.lbl_0.Location = new System.Drawing.Point(36, 153);
            this.lbl_0.Name = "lbl_0";
            this.lbl_0.Size = new System.Drawing.Size(46, 13);
            this.lbl_0.TabIndex = 28;
            this.lbl_0.Text = "Allow All";
            // 
            // lbl_4
            // 
            this.lbl_4.AutoSize = true;
            this.lbl_4.Location = new System.Drawing.Point(36, 49);
            this.lbl_4.Name = "lbl_4";
            this.lbl_4.Size = new System.Drawing.Size(126, 13);
            this.lbl_4.TabIndex = 24;
            this.lbl_4.Text = "Prompt In Secure Screen";
            // 
            // lbl_1
            // 
            this.lbl_1.AutoSize = true;
            this.lbl_1.Location = new System.Drawing.Point(36, 127);
            this.lbl_1.Name = "lbl_1";
            this.lbl_1.Size = new System.Drawing.Size(40, 13);
            this.lbl_1.TabIndex = 27;
            this.lbl_1.Text = "Prompt";
            // 
            // lbl_3
            // 
            this.lbl_3.AutoSize = true;
            this.lbl_3.Location = new System.Drawing.Point(36, 75);
            this.lbl_3.Name = "lbl_3";
            this.lbl_3.Size = new System.Drawing.Size(242, 13);
            this.lbl_3.TabIndex = 25;
            this.lbl_3.Text = "Prompt In Secure Screen - Non-Windows Binaries";
            // 
            // lbl_2
            // 
            this.lbl_2.AutoSize = true;
            this.lbl_2.Location = new System.Drawing.Point(36, 101);
            this.lbl_2.Name = "lbl_2";
            this.lbl_2.Size = new System.Drawing.Size(89, 13);
            this.lbl_2.TabIndex = 26;
            this.lbl_2.Text = "Password Prompt";
            // 
            // tb_uacLevel
            // 
            this.tb_uacLevel.Location = new System.Drawing.Point(6, 16);
            this.tb_uacLevel.Maximum = 5;
            this.tb_uacLevel.Name = "tb_uacLevel";
            this.tb_uacLevel.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tb_uacLevel.Size = new System.Drawing.Size(45, 157);
            this.tb_uacLevel.TabIndex = 22;
            // 
            // btn_disable
            // 
            this.btn_disable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_disable.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_disable.Location = new System.Drawing.Point(17, 78);
            this.btn_disable.Name = "btn_disable";
            this.btn_disable.Size = new System.Drawing.Size(131, 23);
            this.btn_disable.TabIndex = 22;
            this.btn_disable.Text = "Disable UAC";
            this.btn_disable.UseVisualStyleBackColor = true;
            this.btn_disable.Click += new System.EventHandler(this.DisableUAC);
            // 
            // btn_enable
            // 
            this.btn_enable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_enable.Location = new System.Drawing.Point(155, 78);
            this.btn_enable.Name = "btn_enable";
            this.btn_enable.Size = new System.Drawing.Size(131, 23);
            this.btn_enable.TabIndex = 23;
            this.btn_enable.Text = "Enable UAC";
            this.btn_enable.UseVisualStyleBackColor = true;
            this.btn_enable.Click += new System.EventHandler(this.EnableUAC);
            // 
            // lb_processes
            // 
            this.lb_processes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_processes.FormattingEnabled = true;
            this.lb_processes.Location = new System.Drawing.Point(6, 26);
            this.lb_processes.Name = "lb_processes";
            this.lb_processes.Size = new System.Drawing.Size(291, 277);
            this.lb_processes.TabIndex = 24;
            // 
            // btn_refresh
            // 
            this.btn_refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_refresh.Location = new System.Drawing.Point(238, -1);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(59, 21);
            this.btn_refresh.TabIndex = 26;
            this.btn_refresh.Text = "Refresh";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(ProcessRefresh);
            // 
            // lbl_uacSupported
            // 
            this.lbl_uacSupported.Location = new System.Drawing.Point(125, 23);
            this.lbl_uacSupported.Name = "lbl_uacSupported";
            this.lbl_uacSupported.Size = new System.Drawing.Size(161, 13);
            this.lbl_uacSupported.TabIndex = 30;
            this.lbl_uacSupported.Text = "%UACSUPPORTED%";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Is UAC Supported?";
            // 
            // lbl_sessionOwner
            // 
            this.lbl_sessionOwner.Location = new System.Drawing.Point(122, 75);
            this.lbl_sessionOwner.Name = "lbl_sessionOwner";
            this.lbl_sessionOwner.Size = new System.Drawing.Size(164, 13);
            this.lbl_sessionOwner.TabIndex = 34;
            this.lbl_sessionOwner.Text = "%SESSIONOWNER%";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Desktop Owner:";
            // 
            // lbl_sameUser
            // 
            this.lbl_sameUser.Location = new System.Drawing.Point(122, 101);
            this.lbl_sameUser.Name = "lbl_sameUser";
            this.lbl_sameUser.Size = new System.Drawing.Size(164, 13);
            this.lbl_sameUser.TabIndex = 38;
            this.lbl_sameUser.Text = "%SAMEUSER%";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(14, 101);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(98, 13);
            this.label19.TabIndex = 37;
            this.label19.Text = "Is Desktop Owner?";
            // 
            // btn_exit
            // 
            this.btn_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_exit.Location = new System.Drawing.Point(12, 527);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(303, 23);
            this.btn_exit.TabIndex = 39;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.Exit);
            // 
            // gb_information
            // 
            this.gb_information.Controls.Add(this.label1);
            this.gb_information.Controls.Add(this.lbl_username);
            this.gb_information.Controls.Add(this.lbl_sameUser);
            this.gb_information.Controls.Add(this.label2);
            this.gb_information.Controls.Add(this.label19);
            this.gb_information.Controls.Add(this.lbl_isAdministrator);
            this.gb_information.Controls.Add(this.lbl_sessionOwner);
            this.gb_information.Controls.Add(this.label6);
            this.gb_information.Location = new System.Drawing.Point(12, 12);
            this.gb_information.Name = "gb_information";
            this.gb_information.Size = new System.Drawing.Size(303, 128);
            this.gb_information.TabIndex = 40;
            this.gb_information.TabStop = false;
            this.gb_information.Text = "Information";
            // 
            // gb_status
            // 
            this.gb_status.Controls.Add(this.label7);
            this.gb_status.Controls.Add(this.lbl_isElevated);
            this.gb_status.Controls.Add(this.lbl_behavior);
            this.gb_status.Controls.Add(this.label18);
            this.gb_status.Controls.Add(this.btn_restartElevated);
            this.gb_status.Controls.Add(this.btn_restartNormal);
            this.gb_status.Location = new System.Drawing.Point(321, 12);
            this.gb_status.Name = "gb_status";
            this.gb_status.Size = new System.Drawing.Size(303, 108);
            this.gb_status.TabIndex = 41;
            this.gb_status.TabStop = false;
            this.gb_status.Text = "Current Status";
            // 
            // gb_uac
            // 
            this.gb_uac.Controls.Add(this.label16);
            this.gb_uac.Controls.Add(this.lbl_uacEnable);
            this.gb_uac.Controls.Add(this.label5);
            this.gb_uac.Controls.Add(this.lbl_uacSupported);
            this.gb_uac.Controls.Add(this.btn_disable);
            this.gb_uac.Controls.Add(this.btn_enable);
            this.gb_uac.Location = new System.Drawing.Point(321, 126);
            this.gb_uac.Name = "gb_uac";
            this.gb_uac.Size = new System.Drawing.Size(303, 108);
            this.gb_uac.TabIndex = 42;
            this.gb_uac.TabStop = false;
            this.gb_uac.Text = "UAC";
            // 
            // gb_uacNotifications
            // 
            this.gb_uacNotifications.Controls.Add(this.cb_userConsent);
            this.gb_uacNotifications.Controls.Add(this.cb_forceSecureScreen);
            this.gb_uacNotifications.Controls.Add(this.lbl_2);
            this.gb_uacNotifications.Controls.Add(this.lbl_5);
            this.gb_uacNotifications.Controls.Add(this.lbl_3);
            this.gb_uacNotifications.Controls.Add(this.lbl_0);
            this.gb_uacNotifications.Controls.Add(this.lbl_1);
            this.gb_uacNotifications.Controls.Add(this.lbl_4);
            this.gb_uacNotifications.Controls.Add(this.tb_uacLevel);
            this.gb_uacNotifications.Location = new System.Drawing.Point(12, 146);
            this.gb_uacNotifications.Name = "gb_uacNotifications";
            this.gb_uacNotifications.Size = new System.Drawing.Size(303, 230);
            this.gb_uacNotifications.TabIndex = 43;
            this.gb_uacNotifications.TabStop = false;
            this.gb_uacNotifications.Text = "UAC Notifications";
            // 
            // gb_processes
            // 
            this.gb_processes.Controls.Add(this.lb_processes);
            this.gb_processes.Controls.Add(this.btn_refresh);
            this.gb_processes.Location = new System.Drawing.Point(321, 240);
            this.gb_processes.Name = "gb_processes";
            this.gb_processes.Size = new System.Drawing.Size(303, 310);
            this.gb_processes.TabIndex = 44;
            this.gb_processes.TabStop = false;
            this.gb_processes.Text = "Elevated Proceses";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_customDialog);
            this.groupBox1.Controls.Add(this.btn_folderDialog);
            this.groupBox1.Controls.Add(this.btn_fontDialog);
            this.groupBox1.Controls.Add(this.btn_saveFileDialog);
            this.groupBox1.Controls.Add(this.btn_openFileDialog);
            this.groupBox1.Controls.Add(this.btn_colorBox);
            this.groupBox1.Controls.Add(this.btn_messageBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 382);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(303, 139);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Goodies";
            // 
            // btn_customDialog
            // 
            this.btn_customDialog.Location = new System.Drawing.Point(17, 110);
            this.btn_customDialog.Name = "btn_customDialog";
            this.btn_customDialog.Size = new System.Drawing.Size(269, 23);
            this.btn_customDialog.TabIndex = 6;
            this.btn_customDialog.Text = "Custom Dialog";
            this.btn_customDialog.UseVisualStyleBackColor = true;
            this.btn_customDialog.Click += new System.EventHandler(this.ShowGoodies);
            // 
            // btn_folderDialog
            // 
            this.btn_folderDialog.Location = new System.Drawing.Point(155, 81);
            this.btn_folderDialog.Name = "btn_folderDialog";
            this.btn_folderDialog.Size = new System.Drawing.Size(131, 23);
            this.btn_folderDialog.TabIndex = 5;
            this.btn_folderDialog.Text = "Folder Dialog";
            this.btn_folderDialog.UseVisualStyleBackColor = true;
            this.btn_folderDialog.Click += new System.EventHandler(this.ShowGoodies);
            // 
            // btn_fontDialog
            // 
            this.btn_fontDialog.Location = new System.Drawing.Point(17, 81);
            this.btn_fontDialog.Name = "btn_fontDialog";
            this.btn_fontDialog.Size = new System.Drawing.Size(131, 23);
            this.btn_fontDialog.TabIndex = 4;
            this.btn_fontDialog.Text = "Font Dialog";
            this.btn_fontDialog.UseVisualStyleBackColor = true;
            this.btn_fontDialog.Click += new System.EventHandler(this.ShowGoodies);
            // 
            // btn_saveFileDialog
            // 
            this.btn_saveFileDialog.Location = new System.Drawing.Point(155, 52);
            this.btn_saveFileDialog.Name = "btn_saveFileDialog";
            this.btn_saveFileDialog.Size = new System.Drawing.Size(131, 23);
            this.btn_saveFileDialog.TabIndex = 3;
            this.btn_saveFileDialog.Text = "Save File Dialog";
            this.btn_saveFileDialog.UseVisualStyleBackColor = true;
            this.btn_saveFileDialog.Click += new System.EventHandler(this.ShowGoodies);
            // 
            // btn_openFileDialog
            // 
            this.btn_openFileDialog.Location = new System.Drawing.Point(17, 52);
            this.btn_openFileDialog.Name = "btn_openFileDialog";
            this.btn_openFileDialog.Size = new System.Drawing.Size(131, 23);
            this.btn_openFileDialog.TabIndex = 2;
            this.btn_openFileDialog.Text = "Open File Dialog";
            this.btn_openFileDialog.UseVisualStyleBackColor = true;
            this.btn_openFileDialog.Click += new System.EventHandler(this.ShowGoodies);
            // 
            // btn_colorBox
            // 
            this.btn_colorBox.Location = new System.Drawing.Point(155, 23);
            this.btn_colorBox.Name = "btn_colorBox";
            this.btn_colorBox.Size = new System.Drawing.Size(131, 23);
            this.btn_colorBox.TabIndex = 1;
            this.btn_colorBox.Text = "Color Box";
            this.btn_colorBox.UseVisualStyleBackColor = true;
            this.btn_colorBox.Click += new System.EventHandler(this.ShowGoodies);
            // 
            // btn_messageBox
            // 
            this.btn_messageBox.Location = new System.Drawing.Point(17, 23);
            this.btn_messageBox.Name = "btn_messageBox";
            this.btn_messageBox.Size = new System.Drawing.Size(131, 23);
            this.btn_messageBox.TabIndex = 0;
            this.btn_messageBox.Text = "Message Box";
            this.btn_messageBox.UseVisualStyleBackColor = true;
            this.btn_messageBox.Click += new System.EventHandler(this.ShowGoodies);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btn_exit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_exit;
            this.ClientSize = new System.Drawing.Size(636, 562);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_processes);
            this.Controls.Add(this.gb_uacNotifications);
            this.Controls.Add(this.gb_uac);
            this.Controls.Add(this.gb_status);
            this.Controls.Add(this.gb_information);
            this.Controls.Add(this.btn_exit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UAC Helper Sample";
            this.Load += new System.EventHandler(this.FormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.tb_uacLevel)).EndInit();
            this.gb_information.ResumeLayout(false);
            this.gb_information.PerformLayout();
            this.gb_status.ResumeLayout(false);
            this.gb_status.PerformLayout();
            this.gb_uac.ResumeLayout(false);
            this.gb_uac.PerformLayout();
            this.gb_uacNotifications.ResumeLayout(false);
            this.gb_uacNotifications.PerformLayout();
            this.gb_processes.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_username;
        private System.Windows.Forms.Label lbl_isAdministrator;
        private System.Windows.Forms.Label lbl_isElevated;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_behavior;
        private System.Windows.Forms.Button btn_restartElevated;
        private System.Windows.Forms.Button btn_restartNormal;
        private System.Windows.Forms.Label lbl_uacEnable;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.CheckBox cb_userConsent;
        private System.Windows.Forms.TrackBar tb_uacLevel;
        private System.Windows.Forms.CheckBox cb_forceSecureScreen;
        private System.Windows.Forms.Label lbl_5;
        private System.Windows.Forms.Label lbl_0;
        private System.Windows.Forms.Label lbl_4;
        private System.Windows.Forms.Label lbl_1;
        private System.Windows.Forms.Label lbl_3;
        private System.Windows.Forms.Label lbl_2;
        private System.Windows.Forms.Button btn_disable;
        private System.Windows.Forms.Button btn_enable;
        private System.Windows.Forms.ListBox lb_processes;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Label lbl_uacSupported;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_sessionOwner;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_sameUser;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.GroupBox gb_information;
        private System.Windows.Forms.GroupBox gb_status;
        private System.Windows.Forms.GroupBox gb_uac;
        private System.Windows.Forms.GroupBox gb_uacNotifications;
        private System.Windows.Forms.GroupBox gb_processes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_saveFileDialog;
        private System.Windows.Forms.Button btn_openFileDialog;
        private System.Windows.Forms.Button btn_colorBox;
        private System.Windows.Forms.Button btn_messageBox;
        private System.Windows.Forms.Button btn_folderDialog;
        private System.Windows.Forms.Button btn_fontDialog;
        private System.Windows.Forms.Button btn_customDialog;
    }
}

