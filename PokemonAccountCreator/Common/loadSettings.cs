using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonAccountCreator.Common
{
    class loadSettings
    {
        public static void load()
        {
            if (File.Exists("settings.txt"))
            {
                foreach (var line in File.ReadAllLines("settings.txt"))
                {
                    if (line.Contains("Captcha Api Key:"))
                    {
                        Data.settings.captcahAPiKey = line.Replace("Captcha Api Key:", "");
                    }
                    else if (line.Contains("Gmail Username:"))
                    {
                        Data.settings.gmailUsername = line.Replace("Gmail Username:", "");
                    }
                    else if (line.Contains("Gmail Password:"))
                    {
                        Data.settings.gmailPassword = line.Replace("Gmail Password:", "");
                    }
                }
            }
            else
            {
                MessageBox.Show("You need to update your settings");
            }
        }
    }
}
