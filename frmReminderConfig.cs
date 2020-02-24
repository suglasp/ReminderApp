using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReminderApp
{

    /// <summary>
    /// Reminder App Configuration form
    /// </summary>
    public partial class frmReminderConfig : Form
    {



        #region Private Vars
        private string strRATitle, strRAMessage;
        private int iRAInterval;
        #endregion

        #region Getters & Setters
        public string ReminderTitle
        {
            get { return this.strRATitle; }
            set { this.strRATitle = value; }
        }

        public string ReminderMessage
        {
            get { return this.strRAMessage; }
            set { this.strRAMessage = value; }
        }

        public int ReminderInterval
        {
            get { return this.iRAInterval; }
            set { this.iRAInterval = value; }
        }
        #endregion

        #region Constructor
        public frmReminderConfig(string title, string message, int interval)
        {
            InitializeComponent();

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.CenterToParent();

            ReminderTitle = title;
            ReminderMessage = message;
            ReminderInterval = interval;

            this.PropToGUI();
        }
        #endregion


        #region Conversion
        /// <summary>
        /// Microseconds to Seconds (convert a timer format to seconds)
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        private int MSecondsToSeconds(int seconds) {
            int m = seconds / 1000;
            return m;
        }

        /// <summary>
        /// Seconds to Microseconds (convert seconds to a timer format)
        /// </summary>
        /// <param name="minutes"></param>
        /// <returns></returns>
        private int SecondsToMSeconds(int minutes)
        {
            int s = minutes * 1000;
            return s;
        }
        #endregion

        #region Form validation
        private void PropToGUI() {
            this.txtTitle.Text = ReminderTitle;
            this.txtMessage.Text = ReminderMessage;
            this.nudInterval.Value = MSecondsToSeconds(ReminderInterval);
        }

        private void GUIToProp()
        {
            ReminderTitle = this.txtTitle.Text;
            ReminderMessage = this.txtMessage.Text;
            ReminderInterval = SecondsToMSeconds((int)this.nudInterval.Value);
        }
        #endregion

        private void BtnSave_Click(object sender, EventArgs e)
        {
            this.GUIToProp();
        }

        private void FrmReminderConfig_Load(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
