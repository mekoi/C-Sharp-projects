using System;
using System.Windows.Forms;

namespace _301072868_meko__Lab1
{
    public partial class frmNotificationManager : Form
    {
        public frmNotificationManager()
        {
            InitializeComponent();
        }

        private void NotificationManager_Load(object sender, EventArgs e)
        {

        }

        private void btnManageSubsciption_Click(object sender, EventArgs e)
        {
            frmSubscriptionManager frmSubMng = new frmSubscriptionManager();
            frmSubMng.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void btnPublishNotification_Click(object sender, EventArgs e)
        {
            frmPublishingManager frmPubMng = new frmPublishingManager();
            frmPubMng.ShowDialog();
        }

        private void frmNotificationManager_Activated(object sender, EventArgs e)
        {
            // Check if subscriptions are empty before enabling Publish Notification button
            if (Program.emailsList.Count > 0 || Program.smsNumbersList.Count > 0)
            {
                btnPublishNotification.Enabled = true;         
            }
            else
            {
                btnPublishNotification.Enabled = false;
            }
        }

    }
}
