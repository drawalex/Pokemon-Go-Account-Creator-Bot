namespace PokemonAccountCreator.Form
{
    partial class settingsForm
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
            this.saveSettingsBtn = new RPButton();
            this.label1 = new System.Windows.Forms.Label();
            this.captchaApiKeyTb = new System.Windows.Forms.TextBox();
            this.checkCaptchaKeyBtn = new RPButton();
            this.captchaBalanceLbl = new System.Windows.Forms.Label();
            this.rpGroupBox1 = new RPGroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.usernameTb = new System.Windows.Forms.TextBox();
            this.setupGmailBtn = new RPButton();
            this.rpGroupBox2 = new RPGroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.passwordTb = new System.Windows.Forms.TextBox();
            this.rpGroupBox3 = new RPGroupBox();
            this.checkGmailBtn = new RPButton();
            this.rpButton1 = new RPButton();
            this.rpGroupBox1.SuspendLayout();
            this.rpGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveSettingsBtn
            // 
            this.saveSettingsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.saveSettingsBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
            this.saveSettingsBtn.Location = new System.Drawing.Point(378, 252);
            this.saveSettingsBtn.Name = "saveSettingsBtn";
            this.saveSettingsBtn.Size = new System.Drawing.Size(75, 23);
            this.saveSettingsBtn.TabIndex = 8;
            this.saveSettingsBtn.Text = "Save";
            this.saveSettingsBtn.Click += new System.EventHandler(this.saveSettingsBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Captcha API Key:";
            // 
            // captchaApiKeyTb
            // 
            this.captchaApiKeyTb.Location = new System.Drawing.Point(104, 17);
            this.captchaApiKeyTb.Name = "captchaApiKeyTb";
            this.captchaApiKeyTb.Size = new System.Drawing.Size(331, 20);
            this.captchaApiKeyTb.TabIndex = 1;
            // 
            // checkCaptchaKeyBtn
            // 
            this.checkCaptchaKeyBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.checkCaptchaKeyBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
            this.checkCaptchaKeyBtn.Location = new System.Drawing.Point(360, 43);
            this.checkCaptchaKeyBtn.Name = "checkCaptchaKeyBtn";
            this.checkCaptchaKeyBtn.Size = new System.Drawing.Size(75, 23);
            this.checkCaptchaKeyBtn.TabIndex = 10;
            this.checkCaptchaKeyBtn.Text = "Check";
            this.checkCaptchaKeyBtn.Click += new System.EventHandler(this.checkCaptchaKeyBtn_Click);
            // 
            // captchaBalanceLbl
            // 
            this.captchaBalanceLbl.AutoSize = true;
            this.captchaBalanceLbl.Location = new System.Drawing.Point(101, 48);
            this.captchaBalanceLbl.Name = "captchaBalanceLbl";
            this.captchaBalanceLbl.Size = new System.Drawing.Size(101, 13);
            this.captchaBalanceLbl.TabIndex = 11;
            this.captchaBalanceLbl.Text = "Captcha Balance: 0";
            // 
            // rpGroupBox1
            // 
            this.rpGroupBox1.Controls.Add(this.rpButton1);
            this.rpGroupBox1.Controls.Add(this.captchaBalanceLbl);
            this.rpGroupBox1.Controls.Add(this.checkCaptchaKeyBtn);
            this.rpGroupBox1.Controls.Add(this.captchaApiKeyTb);
            this.rpGroupBox1.Controls.Add(this.label1);
            this.rpGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.rpGroupBox1.Name = "rpGroupBox1";
            this.rpGroupBox1.Size = new System.Drawing.Size(441, 74);
            this.rpGroupBox1.TabIndex = 9;
            this.rpGroupBox1.TabStop = false;
            this.rpGroupBox1.Text = "Captcha Service";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Username:";
            // 
            // usernameTb
            // 
            this.usernameTb.Location = new System.Drawing.Point(104, 17);
            this.usernameTb.Name = "usernameTb";
            this.usernameTb.Size = new System.Drawing.Size(331, 20);
            this.usernameTb.TabIndex = 1;
            // 
            // setupGmailBtn
            // 
            this.setupGmailBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.setupGmailBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
            this.setupGmailBtn.Location = new System.Drawing.Point(360, 69);
            this.setupGmailBtn.Name = "setupGmailBtn";
            this.setupGmailBtn.Size = new System.Drawing.Size(75, 23);
            this.setupGmailBtn.TabIndex = 10;
            this.setupGmailBtn.Text = "Setup";
            this.setupGmailBtn.Click += new System.EventHandler(this.setupGmailBtn_Click);
            // 
            // rpGroupBox2
            // 
            this.rpGroupBox2.Controls.Add(this.checkGmailBtn);
            this.rpGroupBox2.Controls.Add(this.rpGroupBox3);
            this.rpGroupBox2.Controls.Add(this.passwordTb);
            this.rpGroupBox2.Controls.Add(this.label2);
            this.rpGroupBox2.Controls.Add(this.setupGmailBtn);
            this.rpGroupBox2.Controls.Add(this.usernameTb);
            this.rpGroupBox2.Controls.Add(this.label3);
            this.rpGroupBox2.Location = new System.Drawing.Point(12, 92);
            this.rpGroupBox2.Name = "rpGroupBox2";
            this.rpGroupBox2.Size = new System.Drawing.Size(441, 154);
            this.rpGroupBox2.TabIndex = 12;
            this.rpGroupBox2.TabStop = false;
            this.rpGroupBox2.Text = "Gmail Account";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Password:";
            // 
            // passwordTb
            // 
            this.passwordTb.Location = new System.Drawing.Point(104, 43);
            this.passwordTb.Name = "passwordTb";
            this.passwordTb.Size = new System.Drawing.Size(331, 20);
            this.passwordTb.TabIndex = 12;
            // 
            // rpGroupBox3
            // 
            this.rpGroupBox3.Location = new System.Drawing.Point(10, 69);
            this.rpGroupBox3.Name = "rpGroupBox3";
            this.rpGroupBox3.Size = new System.Drawing.Size(344, 79);
            this.rpGroupBox3.TabIndex = 13;
            this.rpGroupBox3.TabStop = false;
            this.rpGroupBox3.Text = "How to setup Gmail";
            // 
            // checkGmailBtn
            // 
            this.checkGmailBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.checkGmailBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
            this.checkGmailBtn.Location = new System.Drawing.Point(360, 98);
            this.checkGmailBtn.Name = "checkGmailBtn";
            this.checkGmailBtn.Size = new System.Drawing.Size(75, 23);
            this.checkGmailBtn.TabIndex = 14;
            this.checkGmailBtn.Text = "Check";
            this.checkGmailBtn.Click += new System.EventHandler(this.checkGmailBtn_Click);
            // 
            // rpButton1
            // 
            this.rpButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
            this.rpButton1.Location = new System.Drawing.Point(6, 43);
            this.rpButton1.Name = "rpButton1";
            this.rpButton1.Size = new System.Drawing.Size(75, 23);
            this.rpButton1.TabIndex = 12;
            this.rpButton1.Text = "Get Key";
            this.rpButton1.Click += new System.EventHandler(this.rpButton1_Click);
            // 
            // settingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 284);
            this.Controls.Add(this.rpGroupBox2);
            this.Controls.Add(this.rpGroupBox1);
            this.Controls.Add(this.saveSettingsBtn);
            this.Name = "settingsForm";
            this.Text = "PTC Account Creator - Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.settingsForm_FormClosing);
            this.Load += new System.EventHandler(this.settingsForm_Load);
            this.rpGroupBox1.ResumeLayout(false);
            this.rpGroupBox1.PerformLayout();
            this.rpGroupBox2.ResumeLayout(false);
            this.rpGroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private RPButton saveSettingsBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox captchaApiKeyTb;
        private RPButton checkCaptchaKeyBtn;
        private System.Windows.Forms.Label captchaBalanceLbl;
        private RPGroupBox rpGroupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox usernameTb;
        private RPButton setupGmailBtn;
        private RPGroupBox rpGroupBox2;
        private RPGroupBox rpGroupBox3;
        private System.Windows.Forms.TextBox passwordTb;
        private System.Windows.Forms.Label label2;
        private RPButton checkGmailBtn;
        private RPButton rpButton1;
    }
}