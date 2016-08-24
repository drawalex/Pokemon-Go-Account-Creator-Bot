using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonAccountCreator.GUI
{
    class updater
    {
        public static async Task updateMainForm()
        {
            if (Form.mainForm.StartStopButton.InvokeRequired)
            {

                if (Form.mainForm.PtcAccountListBox.InvokeRequired)
                {
                    Form.mainForm.PtcAccountListBox.BeginInvoke((MethodInvoker) delegate()
                    {
                        Form.mainForm.PtcAccountListBox.Items.Clear();
                        Form.mainForm.PtcAccountListBox.Items.AddRange(Data.settings.AccountsList.ToArray());
                    });

                }
                else
                {
                    Form.mainForm.PtcAccountListBox.Items.Clear();
                    Form.mainForm.PtcAccountListBox.Items.AddRange(Data.settings.AccountsList.ToArray());
                }

                if (Form.mainForm.AccountsCreatedLabel.InvokeRequired)
                {
                    Form.mainForm.AccountsCreatedLabel.BeginInvoke((MethodInvoker) delegate()
                    {
                        Form.mainForm.AccountsCreatedLabel.Text = "PTC Accounts Created: " +
                                                                  Data.settings.AccountsList.Count;
                    });

                }
                else
                {
                    Form.mainForm.AccountsCreatedLabel.Text = "PTC Accounts Created: " +
                                                              Data.settings.AccountsList.Count;
                }

                if (Form.mainForm.CaptchaBalanceLabel.InvokeRequired)
                {
                    Form.mainForm.CaptchaBalanceLabel.BeginInvoke((MethodInvoker) delegate()
                    {
                        Form.mainForm.CaptchaBalanceLabel.Text = "Captcha Balance: " + Data.settings.captchaBalance;

                    });

                }
                else
                {
                    Form.mainForm.CaptchaBalanceLabel.Text = "Captcha Balance: " + Data.settings.captchaBalance;
                }

            }
        }
    }
}