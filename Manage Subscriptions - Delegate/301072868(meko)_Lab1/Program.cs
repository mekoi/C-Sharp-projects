using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _301072868_meko__Lab1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        public static List<string> emailsList = new List<string>();
        public static List<string> smsNumbersList = new List<string>();
       
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmNotificationManager());

            //SubscriptionManager sbForm = new SubscriptionManager();


        }
    }
}
