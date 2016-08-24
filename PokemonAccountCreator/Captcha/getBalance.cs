using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAccountCreator.Captcha
{
    class getBalance
    {
        public static async Task getAccounBalance()
        {
            if (Data.settings.captcahAPiKey != null)
            {
                try
                {
                    var url = String.Format("{0}?key={1}&action=getbalance", "http://2captcha.com/res.php",
                        Data.settings.captcahAPiKey);

                    using (WebClient client = new WebClient())
                    {
                        Data.settings.captchaBalance = Convert.ToDecimal(client.DownloadString(url));
                    }
                }
                catch (Exception e)
                {
                    Common.logManager.logMessage("ERROR - " + e.Message);

                }
            }
        }
    }
}