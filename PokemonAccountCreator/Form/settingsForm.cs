using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailKit;
using MailKit.Net.Imap;

namespace PokemonAccountCreator.Form
{
    public partial class settingsForm : System.Windows.Forms.Form
    {
        public settingsForm()
        {
            InitializeComponent();
        }

        private static bool captchaKeyOK = false;
        private static bool gmailOK = false;

        private void settingsForm_Load(object sender, EventArgs e)
        {
            captchaApiKeyTb.Text = Data.settings.captcahAPiKey;
            usernameTb.Text = Data.settings.gmailUsername;
            passwordTb.Text = Data.settings.gmailPassword;
        }

        private void checkCaptchaKeyBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var url = String.Format("{0}?key={1}&action=getbalance", "http://2captcha.com/res.php",
                    captchaApiKeyTb.Text);
                string responce;
                using (WebClient client = new WebClient())
                {
                    responce = client.DownloadString(url);
                }

                if (responce == "ERROR_KEY_DOES_NOT_EXIST")
                {
                    MessageBox.Show("Captcha Key isn't Correct.");
                }
                else
                {
                    captchaBalanceLbl.Text = "Captcha Balance: " + responce;

                    captchaKeyOK = true;
                }


            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void setupGmailBtn_Click(object sender, EventArgs e)
        {
            if (usernameTb.Text != "" && passwordTb.Text != "")
            {
                using (ImapClient imapClient = new ImapClient())
                {
                    try
                    {
                        imapClient.Connect("imap.gmail.com", 993, true);
                        imapClient.AuthenticationMechanisms.Remove("XOAUTH2");
                        imapClient.Authenticate(usernameTb.Text, passwordTb.Text);

                        var inbox = imapClient.Inbox;
                        inbox.Open(FolderAccess.ReadWrite);


                        imapClient.Disconnect(true);
                    }
                    catch (Exception exception)
                    {
                        if (exception.Message.Contains("Authentication failed"))
                        {
                            MessageBox.Show("Authentication failed");
                        }

                        if (exception.Message.Contains("Please log in via your web browser"))
                        {
                            MessageBox.Show("Log into your Gmail Account and Allow Access.");
                        }

                        Console.WriteLine(exception);
                    }

                }
            }
            else
            {
                MessageBox.Show("You are missing some Gmail Data");
            }
        }

        private void checkGmailBtn_Click(object sender, EventArgs e)
        {
            if (usernameTb.Text != "" && passwordTb.Text != "")
            {
                using (ImapClient imapClient = new ImapClient())
                {
                    try
                    {
                        imapClient.Connect("imap.gmail.com", 993, true);
                        imapClient.AuthenticationMechanisms.Remove("XOAUTH2");
                        imapClient.Authenticate(usernameTb.Text, passwordTb.Text);

                        var inbox = imapClient.Inbox;
                        inbox.Open(FolderAccess.ReadWrite);


                        imapClient.Disconnect(true);
                        MessageBox.Show("Gmail Setup Correctly");
                        gmailOK = true;
                    }
                    catch (Exception exception)
                    {
                        if (exception.Message.Contains("Authentication failed"))
                        {
                            MessageBox.Show("Authentication failed");
                        }

                        if (exception.Message.Contains("Please log in via your web browser"))
                        {
                            MessageBox.Show("You have Not setup Your Account.");
                        }

                        Console.WriteLine(exception);
                    }

                }
            }
            else
            {
                MessageBox.Show("You are missing some Gmail Data");
            }
        }

        private void saveSettingsBtn_Click(object sender, EventArgs e)
        {
            if (gmailOK == true && captchaKeyOK == true)
            {
                if (captchaApiKeyTb.Text != "" && usernameTb.Text != "" && passwordTb.Text != "")
                {
                    List<string> settingsList = new List<string>();

                    settingsList.Add("Captcha Api Key:" + captchaApiKeyTb.Text);
                    settingsList.Add("Gmail Username:" + usernameTb.Text);
                    settingsList.Add("Gmail Password:" + passwordTb.Text);

                    File.WriteAllLines("settings.txt", settingsList);

                }
                else
                {
                    MessageBox.Show("Some of your data is Missing.");
                }

            }
            else
            {
                MessageBox.Show("Make sure you have Checked both your Captcha Key and your Gmail Account");
            }

        }

        private void rpButton1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://2captcha.com/?from=2170012");
        }

        private void settingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Data.settings.captcahAPiKey = captchaApiKeyTb.Text;
            Data.settings.gmailUsername = usernameTb.Text;
            Data.settings.gmailPassword = passwordTb.Text;
        }
    }
}
