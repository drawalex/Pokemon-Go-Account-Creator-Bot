using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAccountCreator.Core
{
    class captchaService
    {
        public async static Task<string> exicuteSolve(string googleKey)
        {
            Common.logManager.logMessage("Solving Captcha");
            string captchaApiKey = Core.createAccount.captcahAPiKey;
            var responceKey = SendRecaptchav2Request(googleKey, captchaApiKey,
                "https://club.pokemon.com/uk/pokemon-trainer-club/sign-up/");
            char[] characters = {'O', 'K', '|'};
            var id = responceKey.TrimStart(characters);
            System.Threading.Thread.Sleep(15000);
            var solvedCaptcha = getRecaptchav2Request(id, captchaApiKey);

            while(solvedCaptcha == "CAPCHA_NOT_READY")
            {
                Console.WriteLine("Captcha not Ready.");
                System.Threading.Thread.Sleep(5000);
                solvedCaptcha = getRecaptchav2Request(id, captchaApiKey);
                
            }
            var code = solvedCaptcha.TrimStart(characters);
            return code;
        }


        private static string SendRecaptchav2Request(string googleKey, string captchaApiKey, string pageUrl)
        {
            //POST
            try
            {
                System.Net.ServicePointManager.Expect100Continue = false;
                var request = (HttpWebRequest) WebRequest.Create("http://2captcha.com/in.php");

                var postData = String.Format("key={0}&method=userrecaptcha&googlekey={1}&pageurl={2}", captchaApiKey,
                    googleKey, pageUrl);
                var data = Encoding.ASCII.GetBytes(postData);

                request.Method = "POST";

                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse) request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return responseString;
            }
            catch (Exception e)
            {
                string tt = e.Message;
                return tt;
            }

        }

        private static string getRecaptchav2Request(string requestKey, string captcahApiKey)
        {
            //GET
                string urlAddress = "http://2captcha.com/res.php";

                var postData = String.Format("?key={0}&action=get&id={1}", captcahApiKey, requestKey);
                using (WebClient client = new WebClient())
                {
                    client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) " + "(compatible; MSIE 6.0; Windows NT 5.1; " + ".NET CLR 1.1.4322; .NET CLR 2.0.50727)";

                    var code = client.DownloadString(urlAddress + postData);

                    char[] characters = { 'O', 'K', '|' };
                    code.TrimStart(characters);

                    return code;
                } 
        }
    }
}