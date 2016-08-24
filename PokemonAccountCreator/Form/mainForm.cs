using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonAccountCreator.Form
{
    public partial class mainForm : System.Windows.Forms.Form
    {

        public static ListBox PtcAccountListBox;
        public static Label AccountsCreatedLabel;
        public static Label CaptchaBalanceLabel;

        public static ListBox LogListBox;

        public static Button StartStopButton;

        public mainForm()
        {
            InitializeComponent();
            PtcAccountListBox = ptcAccountList;
            AccountsCreatedLabel = accountsCreatedLbl;
            CaptchaBalanceLabel = captchaBalanceLbl;
            LogListBox = logList;
            StartStopButton = startBtn;
        }

        private  async void mainForm_Load(object sender, EventArgs e)
        {
            Common.loadSettings.load();
            await Captcha.getBalance.getAccounBalance();
            Form.mainForm.CaptchaBalanceLabel.Text = "Captcha Balance: " + Data.settings.captchaBalance;
            
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            Data.settings.AccountsList.Clear();
            if (Data.settings.captcahAPiKey != null && Data.settings.gmailUsername != null &&
                Data.settings.gmailPassword != null)
            {
                int numberToCreate = Convert.ToInt32(accountsToCreateNum.Value);
                Data.settings.Thread = Task.Factory.StartNew(() => Create.accountHandler.createAccounts(numberToCreate));
            }
            else
            {
                MessageBox.Show("You Need to update your settings.");
            }
        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            Form.settingsForm settingsForm = new settingsForm();
            settingsForm.Show();
        }
    }
}
