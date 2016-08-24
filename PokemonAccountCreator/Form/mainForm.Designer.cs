namespace PokemonAccountCreator.Form
{
    partial class mainForm
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
            this.ptcAccountList = new System.Windows.Forms.ListBox();
            this.settingsBtn = new RPButton();
            this.accountsCreatedLbl = new RPLabel();
            this.startBtn = new RPButton();
            this.accountsToCreateNum = new RPNumericUpDown();
            this.captchaBalanceLbl = new RPLabel();
            this.logList = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.accountsToCreateNum)).BeginInit();
            this.SuspendLayout();
            // 
            // ptcAccountList
            // 
            this.ptcAccountList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptcAccountList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ptcAccountList.FormattingEnabled = true;
            this.ptcAccountList.Location = new System.Drawing.Point(12, 41);
            this.ptcAccountList.Name = "ptcAccountList";
            this.ptcAccountList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.ptcAccountList.Size = new System.Drawing.Size(356, 288);
            this.ptcAccountList.TabIndex = 3;
            // 
            // settingsBtn
            // 
            this.settingsBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
            this.settingsBtn.Location = new System.Drawing.Point(293, 493);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(75, 23);
            this.settingsBtn.TabIndex = 5;
            this.settingsBtn.Text = "Settings";
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // accountsCreatedLbl
            // 
            this.accountsCreatedLbl.AutoSize = true;
            this.accountsCreatedLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
            this.accountsCreatedLbl.Location = new System.Drawing.Point(12, 498);
            this.accountsCreatedLbl.Name = "accountsCreatedLbl";
            this.accountsCreatedLbl.Size = new System.Drawing.Size(129, 13);
            this.accountsCreatedLbl.TabIndex = 6;
            this.accountsCreatedLbl.Text = "PTC Accounts Created: 0";
            // 
            // startBtn
            // 
            this.startBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
            this.startBtn.Location = new System.Drawing.Point(293, 13);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(75, 23);
            this.startBtn.TabIndex = 7;
            this.startBtn.Text = "Start";
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // accountsToCreateNum
            // 
            this.accountsToCreateNum.BackColor = System.Drawing.Color.White;
            this.accountsToCreateNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.accountsToCreateNum.Location = new System.Drawing.Point(212, 12);
            this.accountsToCreateNum.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.accountsToCreateNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.accountsToCreateNum.Name = "accountsToCreateNum";
            this.accountsToCreateNum.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.accountsToCreateNum.Size = new System.Drawing.Size(75, 24);
            this.accountsToCreateNum.TabIndex = 9;
            this.accountsToCreateNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // captchaBalanceLbl
            // 
            this.captchaBalanceLbl.AutoSize = true;
            this.captchaBalanceLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
            this.captchaBalanceLbl.Location = new System.Drawing.Point(9, 17);
            this.captchaBalanceLbl.Name = "captchaBalanceLbl";
            this.captchaBalanceLbl.Size = new System.Drawing.Size(104, 13);
            this.captchaBalanceLbl.TabIndex = 10;
            this.captchaBalanceLbl.Text = "Captcha Balance: 0";
            // 
            // logList
            // 
            this.logList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.logList.FormattingEnabled = true;
            this.logList.Location = new System.Drawing.Point(12, 342);
            this.logList.Name = "logList";
            this.logList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.logList.Size = new System.Drawing.Size(356, 145);
            this.logList.TabIndex = 11;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(380, 525);
            this.Controls.Add(this.logList);
            this.Controls.Add(this.captchaBalanceLbl);
            this.Controls.Add(this.accountsToCreateNum);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.accountsCreatedLbl);
            this.Controls.Add(this.settingsBtn);
            this.Controls.Add(this.ptcAccountList);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(396, 564);
            this.MinimumSize = new System.Drawing.Size(396, 564);
            this.Name = "mainForm";
            this.Text = "PTC Account Creator";
            this.Load += new System.EventHandler(this.mainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accountsToCreateNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox ptcAccountList;
        private RPButton settingsBtn;
        private RPLabel accountsCreatedLbl;
        private RPButton startBtn;
        private RPNumericUpDown accountsToCreateNum;
        private RPLabel captchaBalanceLbl;
        private System.Windows.Forms.ListBox logList;
    }
}