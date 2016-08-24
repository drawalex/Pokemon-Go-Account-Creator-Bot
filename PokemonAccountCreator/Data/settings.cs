using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PokemonAccountCreator.Data
{
    class settings
    {
        public static System.Threading.Tasks.Task Thread;

        //General Details
        public static string baseUrl = "https://club.pokemon.com/us/pokemon-trainer-club";
        public static List<string> AccountsList = new List<string>(); 

        //Creating Accounts Details
        public static bool creatingAccount = false;

        //Captcha Service Details
        public static decimal captchaBalance;
        public static string captcahAPiKey;
        public static string googleReCaptchaKey = "6LdpuiYTAAAAAL6y9JNUZzJ7cF3F8MQGGKko1bCy";
        public static string CaptchaCode;

        public static string captcaBalanceString;

        //Gmail Login Info
        public static string gmailUsername;
        public static string gmailPassword;

    }
}
