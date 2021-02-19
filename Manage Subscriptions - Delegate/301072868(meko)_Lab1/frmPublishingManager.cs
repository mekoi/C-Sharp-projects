using System;
using System.Windows.Forms;

namespace _301072868_meko__Lab1
{
    public partial class frmPublishingManager : Form
    {
        public frmPublishingManager()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPublish_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The notification '" + txtNotificationContent.Text + "' was sent to this list of subscribers: \n\n" + String.Join("\n", Program.emailsList) + "\n\n" + String.Join("\n", Program.smsNumbersList), "Published notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
