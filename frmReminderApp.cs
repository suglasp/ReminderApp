using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;

/* Reminder App
 * Pieter De Ridder
 * 
 * Creation Date : 05/08/2019
 * Updated Date  : 08/08/2019
 * 
 */

namespace ReminderApp
{    

    public partial class frmReminderApp : Form
    {

        #region SFX Constants                
        public const int P_DOGBRK = 0;        //standard indexing sound samples
        public const int P_DOGPRP = 1;
        public const int P_DOGPAN = 2;

        public const int P_DOGBIT = 3;        //special indexing sound samples
        public const int P_DOGLIK = 4;
        public const int P_DOGBLA = 5;
        public const int P_DOGMAN = 6;
        public const int P_DOGWOM = 7;
        #endregion
        

        #region SFX sounds
        public static string[] sounds = { "P_DOGBRK",  //sample files (dog sounds)
                                          "P_DOGPRP",
                                          "P_DOGPAN",
                                          "P_DOGBIT",
                                          "P_DOGLIK",
                                          "P_DOGBLA",
                                          "P_DOGMAN",
                                          "P_DOGWOM" };
        #endregion


        #region Private Vars
        /// <summary>
        /// Private vars
        /// </summary>
        private readonly string ReminderFile = Environment.CurrentDirectory + @"\ReminderApp_Input.txt";  // config file location
        private bool IsShown = true;     // form is shown? (internal status flag)
        private bool IsSuspended = false;   // timer suspended? (internal status flag)
        private bool IsSFXMuted = false;   // mute sound
        private int TimerInterval = 1800000;  //default 30 minutes  (get's populated with the config file)
        private int OriginalLblWidth = 0;

        private SoundPlayer sfxPlayer = null; // sound player 

        private bool P0wnMode = false;   // P0wnmode (label flashing after form pop's up, internal status flag)
        private byte P0wnTick = 255;     // counter (internal status flag)
        private int P0wnInterval = 20;   // timer interval to flash the label (internal status flag)
        #endregion


        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public frmReminderApp()
        {
            //init C# form code
            InitializeComponent();
            
            //set form icon
            this.Icon = ReminderApp.Properties.Resources.image_x_generic;

            this.OriginalLblWidth = this.lblReminder.Width;

            //load config
            this.LoadConfig();

            //enable timer
            //this.tmrReminder.Enabled = true;

            //hide main wnd
            //this.HideForm();

            //set main wnd position
            this.StartPosition = FormStartPosition.Manual;
            this.Left = (Screen.PrimaryScreen.Bounds.Width - Screen.PrimaryScreen.Bounds.Left) - this.Width - 15;
            this.Top = (Screen.PrimaryScreen.Bounds.Height - Screen.PrimaryScreen.Bounds.Top) - this.Height - 80;

            //this.Left = ((SystemInformation.FrameBorderSize.Width + Screen.PrimaryScreen.Bounds.X) - Screen.PrimaryScreen.Bounds.Left) - this.Bounds.Width - 15;
            //this.Top = ((SystemInformation.FrameBorderSize.Height + Screen.PrimaryScreen.Bounds.Y) - Screen.PrimaryScreen.Bounds.Top) - this.Height - 80;

            //enable key preview fetch
            this.KeyPreview = true;
        }
        #endregion


        #region Simple Sound Effects

        /// <summary>
        /// Mute or Unmute SFX
        /// </summary>
        private void SwapMuteSfx() {
            this.IsSFXMuted = !this.IsSFXMuted;
        }
                
        /// <summary>
        /// Load a wave file
        /// </summary>
        /// <param name="sfxfile"></param>
        public void LoadSfx(string sfxfile)
        {
            if (File.Exists(sfxfile))
            {
                //if (this.sfxPlayer == null)
                //{
                    this.sfxPlayer = new SoundPlayer(sfxfile);
                //}
            }
        }

        /// <summary>
        /// Stream a wave file
        /// </summary>
        /// <param name="sfxstream"></param>
        public void LoadSfx(Stream sfxstream)
        {
            //if (this.sfxPlayer == null)
            //{
                this.sfxPlayer = new SoundPlayer(sfxstream);
            //}
        }


        /// <summary>
        /// Play a wave file
        /// </summary>
        public void PlaySfx(bool showWarn = false)
        {
            if (!IsSFXMuted)
            {
                if (this.sfxPlayer != null)
                {
                    //if (this.sfxPlayer.IsLoadCompleted)
                    //{
                    this.sfxPlayer.Play();
                    //}
                }
            }
            else {
                //sound is muted currently
                if (showWarn)
                {
                    if (MessageBox.Show("Sounds are muted!\nDo want to un-mute the sound?", "Remote App - whaat muted?!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes) {
                        this.SwapMuteSfx();
                        this.toolMuteSFX.Checked = this.IsSFXMuted;
                    }
                }
            }
        }

        /// <summary>
        /// Stream a random sound en play it
        /// </summary>
        private void LoadAndPlayFromStreamRandom(bool showWarn = false)
        {            
            Random rnd = new Random();
            int songToPlay = rnd.Next(P_DOGBRK, P_DOGBLA + 1);  //random "standard" sound samples
            string songToName = sounds[songToPlay];
            //this.LoadSfx(Environment.CurrentDirectory + @"\" + songToName + ".WAV");  // load as file

            System.IO.Stream dogsfxrnd = (System.IO.Stream)Properties.Resources.ResourceManager.GetObject(songToName);
            this.LoadSfx(dogsfxrnd); // load as stream

            this.PlaySfx(showWarn); // play the sound      
        }
        #endregion


        #region Config file
        /// <summary>
        /// Load config from file
        /// </summary>
        private void LoadConfig() {
            // load details from config file
            string sFormText = "ReminderApp";
            string sReminderText = string.Empty;
            //int iInterval = 1800000; //default 30 minutes

            //try
            //{
            if (File.Exists(this.ReminderFile))
            {
                string[] sFileLines = File.ReadAllLines(this.ReminderFile);
                sFormText = sFileLines[0];
                sReminderText = sFileLines[1];
                TimerInterval = int.Parse(sFileLines[2]);
            }
            //}
            //catch {
            //    this.ExitForm();
            //}

            // set form title
            this.Text = sFormText;

            // set input text
            this.lblReminder.Text = sReminderText;

            // if label text is to large for form, resize the form
            this.AdjustForm(); 

            // set timer interval
            this.tmrReminder.Interval = TimerInterval;

            // load SFX from resources (stream)
            /*System.IO.Stream dogsfx = Properties.Resources.P_DOGBRK;
            this.LoadSfx(dogsfx);
            this.PlaySfx();*/
        }

        /// <summary>
        /// Save config to file. Very simple technique.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="msg"></param>
        /// <param name="timerInt"></param>
        private void SaveConfig(string title, string msg, string timerInt)
        {
            string[] sFileLines = new string[3];
            sFileLines[0] = title;
            sFileLines[1] = msg;
            sFileLines[2] = timerInt;
            
            File.WriteAllLines(this.ReminderFile, sFileLines);
        }
        #endregion


        #region Color Effects
            /// <summary>
            /// Random color generator. Generates RGB color.
            /// </summary>
            private Color GenRandomColor()
        {
            Random rnd = new Random();
            byte r = (byte)rnd.Next(0, 255);
            byte g = (byte)rnd.Next(0, 255);
            byte b = (byte)rnd.Next(0, 255);

            Color color = Color.FromArgb(r, g, b);

            return color;
        }

        /// <summary>
        /// Start the P0wn Mode (enable label flashing effect)
        /// </summary>
        private void EnableP0wnMode() {
            this.P0wnTick = 0;
            this.tmrReminder.Interval = this.P0wnInterval;

            //this.P0wnMode = true;  //this is done in the timer_tick event
        }

        /// <summary>
        /// Stop the P0wn mode
        /// </summary>
        private void DisableP0wnMode() {
            if (this.P0wnMode)
            {
                this.P0wnMode = false;
                this.P0wnTick = 255;
            }

            this.tmrReminder.Interval = this.TimerInterval; //reset timer
            this.tmrReminder.Enabled = true; // stop timer, so it does not repeat sounds while showing form
        }
        #endregion


        #region Form Adjustments
        /// <summary>
        /// Show App
        /// </summary>
        private void ShowForm()
        {
            if (!this.IsShown) {
                this.IsShown = true;
                
                //this.ShowDialog();
                this.Show();
                this.Focus();

                //if (!this.IsSuspended) {
                //this.tmrReminder.Enabled = false; // stop timer, so it does not repeat sounds while showing form
                //this.tmrReminder.Interval = TimerInterval; //reset timer
                //}

                
            }
        }

        /// <summary>
        /// change label color to random RGB color palette
        /// </summary>
        private void FlashLabelColor()
        {
            this.lblReminder.ForeColor = this.GenRandomColor();
        }

        /// <summary>
        /// Hide App
        /// </summary>
        private void HideForm()
        {
            if (this.IsShown)
            {
                this.IsShown = false;

                this.DisableP0wnMode();

                this.Hide();

                if (!this.IsSuspended) {
                    this.tmrReminder.Enabled = true;
                }               
            }
        }

        /// <summary>
        /// Soft Exit app
        /// </summary>
        private void SoftExitForm()
        {
            if (MessageBox.Show("Are you sure you want to Quit?", "Reminder App - ShutUp now? [Quit]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                this.ExitForm();
            }
        }

        /// <summary>
        /// Exit app
        /// </summary>
        private void ExitForm()
        {
            this.tmrReminder.Enabled = false;

            Environment.Exit(0);
        }

        /// <summary>
        /// Adjust the windows Form to a larger extend if needed.
        /// </summary>
        private void AdjustForm()
        {
            this.lblReminder.AutoSize = true;

            if (this.OriginalLblWidth <= this.lblReminder.Width)
            {
                this.Width = this.lblReminder.Width + 200;
                this.btnHide.Left = this.Width - 130;
                this.btnShutup.Left = this.Width - 130;
            }
            else
            {
                this.lblReminder.Width = this.OriginalLblWidth;
                this.lblReminder.AutoSize = false;
                this.lblReminder.Width = 420;
            }
        }
        #endregion


        #region Timer stuff
        /// <summary>
        /// Suspend app
        /// </summary>
        private void SuspendTimer() {
            this.IsSuspended = true;

            this.suspendToolStripMenuItem.Checked = true;
            this.resumeToolStripMenuItem.Checked = false;

            if (!IsShown)
            {
                this.tmrReminder.Enabled = false;
            }

            MessageBox.Show("The Reminder App is still running, but won't bother you anymore!", "Reminder App - suspended!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Resume app
        /// </summary>
        private void ResumeTimer() {
            this.IsSuspended = false;

            this.suspendToolStripMenuItem.Checked = false;
            this.resumeToolStripMenuItem.Checked = true;

            if (!IsShown) {
                this.tmrReminder.Enabled = true;
            }

            MessageBox.Show("The Reminder App will notify you again!", "Reminder App - resumed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion



        /// <summary>
        /// Timer Tick (automated interaction)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TmrReminder_Tick(object sender, EventArgs e)
        {
            if (!this.IsShown)
            {
                //time has come after x-time to show the Form with message
                this.ShowForm();

                // always play "random" when trigger
                //this.LoadAndPlayFromStreamRandom();

                // always play 'bark' when trigger
                System.IO.Stream dogsfx = Properties.Resources.P_DOGBRK;
                this.LoadSfx(dogsfx);
                this.PlaySfx();

                // switch on P0wnage timer (for label falsh effects)
                this.EnableP0wnMode();
            }
            else {
                // recycle the timer for a label flashing event when needed.
                // if Form is shown by timer_tick event, flash the label with colors to track attention of user.

                switch (this.P0wnTick) {
                    case 0:
                        this.P0wnMode = true;                        
                        break;
                    case 255:
                        this.DisableP0wnMode();
                        break;
                }

                if (this.P0wnMode) {
                    this.P0wnTick++;
                    this.FlashLabelColor();
                }
            }
        }

        /// <summary>
        /// Load basic stuff and config
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmReminderApp_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Hide form (user interaction)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnHide_Click(object sender, EventArgs e)
        {
            this.HideForm();
        }

        /// <summary>
        /// Kill the app (user interaction)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnShutup_Click(object sender, EventArgs e)
        {
            this.SoftExitForm();
        }

        /// <summary>
        /// Keyboard input (user interaction)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmReminderApp_KeyDown(object sender, KeyEventArgs e)
        {
            // hide on ESC
            if (e.KeyCode == Keys.Escape) {
                this.HideForm();
            }

            // random bark!
            if (e.KeyCode == Keys.F1) {
                this.LoadAndPlayFromStreamRandom(true);
            }
        }

        /// <summary>
        /// Change color on Reminder text move (user interaction)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblReminder_MouseMove(object sender, MouseEventArgs e)
        {
            this.FlashLabelColor();
        }

        /// <summary>
        /// Popup the form (user interaction)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.ShowForm();
        }

        /// <summary>
        /// Hide app through notification tray
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MnuHide_Click(object sender, EventArgs e)
        {
            this.HideForm();
        }

        /// <summary>
        /// Exit app through notification tray
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MnuShutup_Click(object sender, EventArgs e)
        {
            this.SoftExitForm();
        }

        /// <summary>
        /// Reload config file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReloadConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            this.LoadConfig();
            this.ShowForm();

            MessageBox.Show("Reloaded the config file!", "Reminder App - Config is reloaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// It's just, ... this is funny! :']
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BARFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.PlaySfx(true);
            this.LoadAndPlayFromStreamRandom(true);
        }

        /// <summary>
        /// Suspend the timer function through GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SuspendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SuspendTimer();
        }

        /// <summary>
        /// Resume the timer function through GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ResumeTimer();
        }


        /// <summary>
        /// Config form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolConfiguration_Click(object sender, EventArgs e)
        {
            frmReminderConfig frmCfg = new frmReminderConfig(this.Text, this.lblReminder.Text, this.TimerInterval);

            frmCfg.ShowDialog();

            if (frmCfg.DialogResult == DialogResult.OK) {
                // save
                this.SaveConfig(frmCfg.ReminderTitle, frmCfg.ReminderMessage, frmCfg.ReminderInterval.ToString());
                
                // reload
                this.LoadConfig();
            }

            frmCfg.Dispose();
            frmCfg = null;
        }

        /// <summary>
        /// About Dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Reminder App     \nCreator : Pieter De Ridder\nCreated in : August 2019\n\n Just a small app to remind of things.", "Reminder App - About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Mute- or Unmute sound
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolMuteSFX_Click(object sender, EventArgs e)
        {
            this.SwapMuteSfx();
            this.toolMuteSFX.Checked = this.IsSFXMuted;
        }
    }
}
