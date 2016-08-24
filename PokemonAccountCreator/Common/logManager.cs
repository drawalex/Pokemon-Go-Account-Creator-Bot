using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonAccountCreator.Common
{
    class logManager
    {
        public async static Task logMessage(string message)
        {
           string time = DateTime.Now.ToString("HH:mm:ss");
            string log = "[" + time + "] " + message;


            if (Form.mainForm.LogListBox.InvokeRequired)
            {
                Form.mainForm.LogListBox.BeginInvoke((MethodInvoker)delegate () { Form.mainForm.LogListBox.Items.Add(log); });
            }
            else
            {
                Form.mainForm.LogListBox.Items.Add(log);
            }
            
        }
    }
}
