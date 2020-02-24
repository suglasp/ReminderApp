using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Reminder App
 * Pieter De Ridder
 * 
 * Creation Date : 05/08/2019
 * Updated Date  : 08/08/2019
 * 
 */

namespace ReminderApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmReminderApp());
        }
    }
}
