using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace _301072868_meko__Lab1
{
    public partial class frmSubscriptionManager : Form
    {
        //Regular Expression for Email Validation
        static string emailCode = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        Regex regEmail = new Regex(emailCode);
        
        //Regular Expression for Mobile Number Validation
        static string smsCode = @"^((1-)?\d{3}-)?\d{3}-\d{4}$";
        Regex regSms = new Regex(smsCode);
                
        public frmSubscriptionManager()
        {
            InitializeComponent();
            lblInvalidEmail.Visible = false;
            lblInvalidPhone.Visible = false;
        }

        private void SubscriptionManager_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubscibe_Click(object sender, EventArgs e)
        { 
            if (cbNotificationByEmail.Checked)
            {
                if(txtEmail.Text.Length > 0 && regEmail.IsMatch(txtEmail.Text))
                {
                    if(!Program.emailsList.Contains(txtEmail.Text))
                    {
                        Program.emailsList.Add(txtEmail.Text);
                        Publisher.Subscribed = true;
                        MessageBox.Show("Email address " + txtEmail.Text + " was subscribed.", "Email subscription", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Email address " + txtEmail.Text + " is already subscribed.", "Email subscription", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (!regEmail.IsMatch(txtEmail.Text))
                    lblInvalidEmail.Text = "Invalid email";
            }

            if (cbNotificationBySms.Checked)
            {
                if (txtMobileNo.Text.Length > 0 && regSms.IsMatch(txtMobileNo.Text))
                {
                    if (!Program.smsNumbersList.Contains(txtMobileNo.Text))
                    {
                        Program.smsNumbersList.Add(txtMobileNo.Text);
                        Publisher.Subscribed = true;
                        MessageBox.Show("Phone number " + txtMobileNo.Text + " was subscribed.", "Phone number subscription", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Phone number " + txtMobileNo.Text + " is already subscribed.", "Phone number subscription", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (!regSms.IsMatch(txtMobileNo.Text))
                    lblInvalidPhone.Text = "Invalid phone number";
            }
        }

        private void btnUnsubscribe_Click(object sender, EventArgs e)
        {
            if (cbNotificationByEmail.Checked)
            {
                if (txtEmail.Text.Length > 0 && regEmail.IsMatch(txtEmail.Text))
                {
                    if (Program.emailsList.Contains(txtEmail.Text))
                    {
                        Program.emailsList.Remove(txtEmail.Text);
                        Publisher.Subscribed = false;
                        MessageBox.Show("Email address " + txtEmail.Text + " was unsubscribed.", "Email subscription", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Email address " + txtEmail.Text + " does not exist.", "Email subscription", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (!regEmail.IsMatch(txtEmail.Text))
                    lblInvalidEmail.Text = "Invalid email";
            }

            if (cbNotificationBySms.Checked)
            {
                if (txtMobileNo.Text.Length > 0 && regSms.IsMatch(txtMobileNo.Text))
                {
                    if (Program.smsNumbersList.Contains(txtMobileNo.Text))
                    {
                        Program.smsNumbersList.Remove(txtMobileNo.Text);
                        Publisher.Subscribed = false;
                        MessageBox.Show("Phone number " + txtMobileNo.Text + " was unsubscribed.", "Phone number subscription", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("EmailPhone number " + txtMobileNo.Text + " does not exist.", "EmailPhone number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (!regSms.IsMatch(txtMobileNo.Text))
                    lblInvalidPhone.Text = "Invalid phone number";
            }
        }

        private void cbNotificationByEmail_CheckedChanged(object sender, EventArgs e)
        {
            txtEmail.Enabled = cbNotificationByEmail.Checked ? true:false;
            lblInvalidEmail.Enabled = cbNotificationByEmail.Checked ? true:false;

            if (cbNotificationByEmail.Checked != true)
            {
                txtEmail.Text = "";
                lblInvalidEmail.Text = "";
                lblInvalidEmail.Enabled = false;
            }        
        }

        private void cbNotificationBySms_CheckedChanged(object sender, EventArgs e)
        {
            txtMobileNo.Enabled = cbNotificationBySms.Checked ? true : false;
            lblInvalidPhone.Enabled = cbNotificationBySms.Checked ? true : false;

            if (cbNotificationBySms.Checked != true)
            {
                txtMobileNo.Text = "";
                lblInvalidPhone.Text = "";
                lblInvalidPhone.Enabled = false;
            }   
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if(txtEmail.Text.Length < 1)
            {
                lblInvalidEmail.Visible = false;
            }
            if(regEmail.IsMatch(txtEmail.Text))
            {
                lblInvalidEmail.Visible = false;
                lblInvalidEmail.Text = "";
            }
            else
            {
                lblInvalidEmail.Visible = true;
            }
        }

        private void txtMobileNo_TextChanged(object sender, EventArgs e)
        {
            if (txtMobileNo.Text.Length < 1)
            {
                lblInvalidPhone.Visible = false;
            }
            if (regSms.IsMatch(txtMobileNo.Text))
            {
                lblInvalidPhone.Visible = false;
                lblInvalidPhone.Text = "";
            }
            else
            {
                lblInvalidPhone.Visible = true;
            }
        }

    }
}
