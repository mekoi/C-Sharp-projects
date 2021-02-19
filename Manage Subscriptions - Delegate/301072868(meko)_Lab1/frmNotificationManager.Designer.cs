namespace _301072868_meko__Lab1
{
    partial class frmNotificationManager
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
            this.btnManageSubsciption = new System.Windows.Forms.Button();
            this.btnPublishNotification = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnManageSubsciption
            // 
            this.btnManageSubsciption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageSubsciption.Location = new System.Drawing.Point(70, 79);
            this.btnManageSubsciption.Name = "btnManageSubsciption";
            this.btnManageSubsciption.Size = new System.Drawing.Size(202, 56);
            this.btnManageSubsciption.TabIndex = 0;
            this.btnManageSubsciption.Text = "Manage Subscription";
            this.btnManageSubsciption.UseVisualStyleBackColor = true;
            this.btnManageSubsciption.Click += new System.EventHandler(this.btnManageSubsciption_Click);
            // 
            // btnPublishNotification
            // 
            this.btnPublishNotification.Enabled = false;
            this.btnPublishNotification.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPublishNotification.Location = new System.Drawing.Point(305, 79);
            this.btnPublishNotification.Name = "btnPublishNotification";
            this.btnPublishNotification.Size = new System.Drawing.Size(202, 56);
            this.btnPublishNotification.TabIndex = 1;
            this.btnPublishNotification.Text = "Publish Notification";
            this.btnPublishNotification.UseVisualStyleBackColor = true;
            this.btnPublishNotification.Click += new System.EventHandler(this.btnPublishNotification_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(545, 79);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(89, 56);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmNotificationManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 221);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPublishNotification);
            this.Controls.Add(this.btnManageSubsciption);
            this.Name = "frmNotificationManager";
            this.Text = "Notification Manager";
            this.Activated += new System.EventHandler(this.frmNotificationManager_Activated);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnManageSubsciption;
        private System.Windows.Forms.Button btnPublishNotification;
        private System.Windows.Forms.Button btnExit;
    }
}