using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PokemonAccountCreator.Common;

namespace PokemonAccountCreator.Core
{
    class createAccount
    {
        public static bool creatingAccounts = false;
        public static int accountBalance = 1;
        public static int accountsCreated = 0;

        public static string rootEmail = "letsjustadapt+test@gmail.com";
        public static string rootPassword = "81poma81";

        public static string captcahAPiKey = "3aa4153f168cda10d31ba7ca4cd85639";

        public static List<string> accountsList = new List<string>();

        public static async void startCreating(int numberToCreate)
        {
            if (creatingAccounts == false)
            {
                creatingAccounts = true;
                for (int i = 0; i < numberToCreate; i++)
                {
                    Common.logManager.logMessage("Creating Account " + (i + 1));
                    if (creatingAccounts == true)
                    {
                        if (accountBalance != 0)
                        {
                            UpdateGuiTask();

                            var Thread = Task.Factory.StartNew(() => captchaService.exicuteSolve(Core.createHandler.googleKey));

                            exicute();
                            accountsCreated++;
                            UpdateGuiTask();

                        }

                        else
                        {
                            Common.logManager.logMessage("Your Captcha Balance is 0 please top up your accout");
                            break;

                        }
                    }
                    else
                    {
                        Common.logManager.logMessage("Bot Stoped");
                        creatingAccounts = false;
                        break;

                    }
                }
                creatingAccounts = false;
            }
            else
            {
                Common.logManager.logMessage("Please Wait Stopping Bot...");
                creatingAccounts = false;

            }
        }


        public static async Task exicute()
        {
            //Create Account
            await Core.createHandler.createAccount();

            //Verify Email
            await Core.gmailManager.VerifyEmailTask(rootEmail, rootPassword);

            var accountString = currentAccountDetails.info.Username + ":" + currentAccountDetails.info.Password;
            accountsList.Add(accountString);

            await
                Common.logManager.logMessage("Account Created: " + currentAccountDetails.info.Username + ":" +
                                             currentAccountDetails.info.Password);
        }

        public static async Task UpdateGuiTask()
        {
            if (Form.mainForm.StartStopButton.InvokeRequired)
            {
                if (creatingAccounts == true)
                {
                    Form.mainForm.StartStopButton.BeginInvoke((MethodInvoker)delegate ()
                    {
                        Form.mainForm.StartStopButton.Text = "Stop";
                    });
                }
                else
                {
                    Form.mainForm.StartStopButton.BeginInvoke((MethodInvoker)delegate ()
                    {
                        Form.mainForm.StartStopButton.Text = "Start";
                    });
                }
            }
            else
            {
                if (creatingAccounts == true)
                {
                        Form.mainForm.StartStopButton.Text = "Stop";
                }
                else
                {
                        Form.mainForm.StartStopButton.Text = "Start";
                }
            }



            if (Form.mainForm.PtcAccountListBox.InvokeRequired)
            {
                Form.mainForm.PtcAccountListBox.BeginInvoke((MethodInvoker)delegate ()
                {
                    Form.mainForm.PtcAccountListBox.Items.Clear();
                    Form.mainForm.PtcAccountListBox.Items.AddRange(accountsList.ToArray());
                });

            }
            else
            {
                Form.mainForm.PtcAccountListBox.Items.Clear();
                Form.mainForm.PtcAccountListBox.Items.AddRange(accountsList.ToArray());
            }

            if (Form.mainForm.AccountsCreatedLabel.InvokeRequired)
            {
                Form.mainForm.AccountsCreatedLabel.BeginInvoke((MethodInvoker) delegate()
                {
                    Form.mainForm.AccountsCreatedLabel.Text = "PTC Accounts Created: " + accountsCreated;
                });

            }
            else
            {
                Form.mainForm.AccountsCreatedLabel.Text = "PTC Accounts Created: " + accountsCreated;
            }

            if (Form.mainForm.CaptchaBalanceLabel.InvokeRequired)
            {
                Form.mainForm.CaptchaBalanceLabel.BeginInvoke((MethodInvoker) delegate()
                {
                    Form.mainForm.CaptchaBalanceLabel.Text = "Captcha Balance: " + accountBalance;

                });

            }
            else
            {
                Form.mainForm.CaptchaBalanceLabel.Text = "Captcha Balance: " + accountBalance;
            }

        }
    }
}
