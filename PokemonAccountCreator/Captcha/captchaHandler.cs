using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAccountCreator.Captcha
{
    class captchaHandler
    {
        public static async Task CreateCaptchaKeyTask()
        {
            Common.logManager.logMessage("Creating Captcha Key.");

            var requestKey = PostRequest().Result;
            if (requestKey != "Error")
            {
                char[] characters = {'O', 'K', '|'};
                var id = requestKey.TrimStart(characters);
                System.Threading.Thread.Sleep(15000);

                await waitForCaptchaKeyTask(id);

                Common.logManager.logMessage("Created Captcha Key.");
            }
        }

        private static async Task waitForCaptchaKeyTask(string id)
        {
            var solvedCaptchaKey = await GetRequest(id);

            int loops = 1;
            while (solvedCaptchaKey == "CAPCHA_NOT_READY")
            {

                Common.logManager.logMessage("Captcha not ready Waiting...");
                System.Threading.Thread.Sleep(10000);
                solvedCaptchaKey = GetRequest(id).Result;

                if (loops == 10)
                {
                    //Make new Captcha
                    await Captcha.captchaHandler.CreateCaptchaKeyTask();
                    return;
                }

                loops++;
            }
            if (solvedCaptchaKey == "ERROR_CAPTCHA_UNSOLVABLE")
            {
                await CreateCaptchaKeyTask();
                
            }
            else
            {
                char[] characters = { 'O', 'K', '|' };
                var captcaCode = solvedCaptchaKey.TrimStart(characters);


                Data.settings.CaptchaCode = captcaCode;
            }
        }

        private static async Task<string> PostRequest()
        {
            try
            {
                System.Net.ServicePointManager.Expect100Continue = false;
                var request = (HttpWebRequest)WebRequest.Create("http://2captcha.com/in.php");

                var postData = String.Format("key={0}&method=userrecaptcha&googlekey={1}&pageurl={2}", Data.settings.captcahAPiKey,
                    Data.settings.googleReCaptchaKey, Data.settings.baseUrl);
                var data = Encoding.ASCII.GetBytes(postData);

                request.Method = "POST";

                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return responseString;
            }
            catch (Exception e)
            {
                Common.logManager.logMessage("ERROR - " + e.Message);
                return "Error";
            }

        }

        private static async Task<string> GetRequest(string requestKey)
        {
            string urlAddress = "http://2captcha.com/res.php";

            var postData = String.Format("?key={0}&action=get&id={1}", Data.settings.captcahAPiKey, requestKey);
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
