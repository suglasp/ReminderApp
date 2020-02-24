namespace ReminderApp
{
    partial class frmReminderApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReminderApp));
            this.lblReminder = new System.Windows.Forms.Label();
            this.tmrReminder = new System.Windows.Forms.Timer(this.components);
            this.btnHide = new System.Windows.Forms.Button();
            this.btnShutup = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.rightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.controlTimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suspendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resumeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.reloadConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolMuteSFX = new System.Windows.Forms.ToolStripMenuItem();
            this.bARFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuHide = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShutup = new System.Windows.Forms.ToolStripMenuItem();
            this.rightClickMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblReminder
            // 
            this.lblReminder.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReminder.Location = new System.Drawing.Point(12, 31);
            this.lblReminder.Name = "lblReminder";
            this.lblReminder.Size = new System.Drawing.Size(431, 28);
            this.lblReminder.TabIndex = 0;
            this.lblReminder.Text = "lblReminder";
            this.lblReminder.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LblReminder_MouseMove);
            // 
            // tmrReminder
            // 
            this.tmrReminder.Enabled = true;
            this.tmrReminder.Interval = 1800000;
            this.tmrReminder.Tick += new System.EventHandler(this.TmrReminder_Tick);
            // 
            // btnHide
            // 
            this.btnHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHide.Location = new System.Drawing.Point(463, 13);
            this.btnHide.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(99, 28);
            this.btnHide.TabIndex = 1;
            this.btnHide.Text = "[Snooze]";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.BtnHide_Click);
            // 
            // btnShutup
            // 
            this.btnShutup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShutup.Location = new System.Drawing.Point(463, 48);
            this.btnShutup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnShutup.Name = "btnShutup";
            this.btnShutup.Size = new System.Drawing.Size(99, 28);
            this.btnShutup.TabIndex = 2;
            this.btnShutup.Text = "[Shutup!]";
            this.btnShutup.UseVisualStyleBackColor = true;
            this.btnShutup.Click += new System.EventHandler(this.BtnShutup_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.rightClickMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Reminder App";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.NotifyIcon_DoubleClick);
            // 
            // rightClickMenu
            // 
            this.rightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAbout,
            this.toolConfiguration,
            this.controlTimerToolStripMenuItem,
            this.toolStripSeparator3,
            this.reloadConfigToolStripMenuItem,
            this.toolStripSeparator2,
            this.toolMuteSFX,
            this.bARFToolStripMenuItem,
            this.toolStripSeparator1,
            this.mnuHide,
            this.mnuShutup});
            this.rightClickMenu.Name = "rightClickMenu";
            this.rightClickMenu.Size = new System.Drawing.Size(185, 198);
            // 
            // toolAbout
            // 
            this.toolAbout.Name = "toolAbout";
            this.toolAbout.Size = new System.Drawing.Size(184, 22);
            this.toolAbout.Text = "About ...";
            this.toolAbout.Click += new System.EventHandler(this.ToolAbout_Click);
            // 
            // toolConfiguration
            // 
            this.toolConfiguration.Name = "toolConfiguration";
            this.toolConfiguration.Size = new System.Drawing.Size(184, 22);
            this.toolConfiguration.Text = "Configuration ...";
            this.toolConfiguration.Click += new System.EventHandler(this.ToolConfiguration_Click);
            // 
            // controlTimerToolStripMenuItem
            // 
            this.controlTimerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.suspendToolStripMenuItem,
            this.resumeToolStripMenuItem});
            this.controlTimerToolStripMenuItem.Name = "controlTimerToolStripMenuItem";
            this.controlTimerToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.controlTimerToolStripMenuItem.Text = "Control Timer";
            // 
            // suspendToolStripMenuItem
            // 
            this.suspendToolStripMenuItem.Name = "suspendToolStripMenuItem";
            this.suspendToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.suspendToolStripMenuItem.Text = "Suspend";
            this.suspendToolStripMenuItem.Click += new System.EventHandler(this.SuspendToolStripMenuItem_Click);
            // 
            // resumeToolStripMenuItem
            // 
            this.resumeToolStripMenuItem.Checked = true;
            this.resumeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.resumeToolStripMenuItem.Name = "resumeToolStripMenuItem";
            this.resumeToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.resumeToolStripMenuItem.Text = "Resume";
            this.resumeToolStripMenuItem.Click += new System.EventHandler(this.ResumeToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(181, 6);
            // 
            // reloadConfigToolStripMenuItem
            // 
            this.reloadConfigToolStripMenuItem.Name = "reloadConfigToolStripMenuItem";
            this.reloadConfigToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.reloadConfigToolStripMenuItem.Text = "Reload config";
            this.reloadConfigToolStripMenuItem.Click += new System.EventHandler(this.ReloadConfigToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(181, 6);
            // 
            // toolMuteSFX
            // 
            this.toolMuteSFX.Name = "toolMuteSFX";
            this.toolMuteSFX.Size = new System.Drawing.Size(184, 22);
            this.toolMuteSFX.Text = "Mute Sound";
            this.toolMuteSFX.Click += new System.EventHandler(this.ToolMuteSFX_Click);
            // 
            // bARFToolStripMenuItem
            // 
            this.bARFToolStripMenuItem.Name = "bARFToolStripMenuItem";
            this.bARFToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.bARFToolStripMenuItem.Text = "BARF! (make sound!)";
            this.bARFToolStripMenuItem.Click += new System.EventHandler(this.BARFToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // mnuHide
            // 
            this.mnuHide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mnuHide.Name = "mnuHide";
            this.mnuHide.Size = new System.Drawing.Size(184, 22);
            this.mnuHide.Text = "Snooze (go Dark)";
            this.mnuHide.Click += new System.EventHandler(this.MnuHide_Click);
            // 
            // mnuShutup
            // 
            this.mnuShutup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mnuShutup.Name = "mnuShutup";
            this.mnuShutup.Size = new System.Drawing.Size(184, 22);
            this.mnuShutup.Text = "Shutup! (Quit)";
            this.mnuShutup.Click += new System.EventHandler(this.MnuShutup_Click);
            // 
            // frmReminderApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(575, 91);
            this.Controls.Add(this.btnShutup);
            this.Controls.Add(this.btnHide);
            this.Controls.Add(this.lblReminder);
            this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReminderApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Reminder App";
            this.Load += new System.EventHandler(this.FrmReminderApp_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmReminderApp_KeyDown);
            this.rightClickMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblReminder;
        private System.Windows.Forms.Timer tmrReminder;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Button btnShutup;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip rightClickMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuHide;
        private System.Windows.Forms.ToolStripMenuItem mnuShutup;
        private System.Windows.Forms.ToolStripMenuItem reloadConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem bARFToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem controlTimerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suspendToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resumeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolConfiguration;
        private System.Windows.Forms.ToolStripMenuItem toolAbout;
        private System.Windows.Forms.ToolStripMenuItem toolMuteSFX;
    }
}

