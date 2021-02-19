namespace _301072868_meko__Lab1
{
    partial class frmSubscriptionManager
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
            this.cbNotificationByEmail = new System.Windows.Forms.CheckBox();
            this.cbNotificationBySms = new System.Windows.Forms.CheckBox();
            this.lblInvalidEmail = new System.Windows.Forms.Label();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.btnSubscibe = new System.Windows.Forms.Button();
            this.btnUnsubscribe = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblInvalidPhone = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbNotificationByEmail
            // 
            this.cbNotificationByEmail.AutoSize = true;
            this.cbNotificationByEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNotificationByEmail.Location = new System.Drawing.Point(37, 78);
            this.cbNotificationByEmail.Name = "cbNotificationByEmail";
            this.cbNotificationByEmail.Size = new System.Drawing.Size(252, 24);
            this.cbNotificationByEmail.TabIndex = 0;
            this.cbNotificationByEmail.Text = "Notification Sent By Email";
            this.cbNotificationByEmail.UseVisualStyleBackColor = true;
            this.cbNotificationByEmail.CheckedChanged += new System.EventHandler(this.cbNotificationByEmail_CheckedChanged);
            // 
            // cbNotificationBySms
            // 
            this.cbNotificationBySms.AutoSize = true;
            this.cbNotificationBySms.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNotificationBySms.Location = new System.Drawing.Point(37, 135);
            this.cbNotificationBySms.Name = "cbNotificationBySms";
            this.cbNotificationBySms.Size = new System.Drawing.Size(244, 24);
            this.cbNotificationBySms.TabIndex = 1;
            this.cbNotificationBySms.Text = "Notification Sent By SMS";
            this.cbNotificationBySms.UseVisualStyleBackColor = true;
            this.cbNotificationBySms.CheckedChanged += new System.EventHandler(this.cbNotificationBySms_CheckedChanged);
            // 
            // lblInvalidEmail
            // 
            this.lblInvalidEmail.AutoSize = true;
            this.lblInvalidEmail.ForeColor = System.Drawing.Color.Red;
            this.lblInvalidEmail.Location = new System.Drawing.Point(345, 103);
            this.lblInvalidEmail.Name = "lblInvalidEmail";
            this.lblInvalidEmail.Size = new System.Drawing.Size(0, 17);
            this.lblInvalidEmail.TabIndex = 3;
            this.lblInvalidEmail.Visible = false;
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Enabled = false;
            this.txtMobileNo.Location = new System.Drawing.Point(336, 137);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(320, 22);
            this.txtMobileNo.TabIndex = 4;
            this.txtMobileNo.TextChanged += new System.EventHandler(this.txtMobileNo_TextChanged);
            // 
            // btnSubscibe
            // 
            this.btnSubscibe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubscibe.Location = new System.Drawing.Point(67, 271);
            this.btnSubscibe.Name = "btnSubscibe";
            this.btnSubscibe.Size = new System.Drawing.Size(155, 55);
            this.btnSubscibe.TabIndex = 6;
            this.btnSubscibe.Text = "Subscribe";
            this.btnSubscibe.UseVisualStyleBackColor = true;
            this.btnSubscibe.Click += new System.EventHandler(this.btnSubscibe_Click);
            // 
            // btnUnsubscribe
            // 
            this.btnUnsubscribe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnsubscribe.Location = new System.Drawing.Point(279, 271);
            this.btnUnsubscribe.Name = "btnUnsubscribe";
            this.btnUnsubscribe.Size = new System.Drawing.Size(166, 55);
            this.btnUnsubscribe.TabIndex = 7;
            this.btnUnsubscribe.Text = "Unsubscribe";
            this.btnUnsubscribe.UseVisualStyleBackColor = true;
            this.btnUnsubscribe.Click += new System.EventHandler(this.btnUnsubscribe_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(500, 271);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(128, 55);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Enabled = false;
            this.txtEmail.Location = new System.Drawing.Point(336, 78);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(320, 22);
            this.txtEmail.TabIndex = 2;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // lblInvalidPhone
            // 
            this.lblInvalidPhone.AutoSize = true;
            this.lblInvalidPhone.ForeColor = System.Drawing.Color.Red;
            this.lblInvalidPhone.Location = new System.Drawing.Point(345, 162);
            this.lblInvalidPhone.Name = "lblInvalidPhone";
            this.lblInvalidPhone.Size = new System.Drawing.Size(0, 17);
            this.lblInvalidPhone.TabIndex = 9;
            this.lblInvalidPhone.Visible = false;
            // 
            // frmSubscriptionManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 397);
            this.Controls.Add(this.lblInvalidPhone);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUnsubscribe);
            this.Controls.Add(this.btnSubscibe);
            this.Controls.Add(this.txtMobileNo);
            this.Controls.Add(this.lblInvalidEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.cbNotificationBySms);
            this.Controls.Add(this.cbNotificationByEmail);
            this.Name = "frmSubscriptionManager";
            this.Text = "Manage Subscription";
            this.Load += new System.EventHandler(this.SubscriptionManager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbNotificationByEmail;
        private System.Windows.Forms.CheckBox cbNotificationBySms;
        private System.Windows.Forms.Label lblInvalidEmail;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.Button btnSubscibe;
        private System.Windows.Forms.Button btnUnsubscribe;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblInvalidPhone;
    }
}