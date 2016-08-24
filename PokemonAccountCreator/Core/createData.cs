using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PokemonAccountCreator.Common;

namespace PokemonAccountCreator.Core
{
    class createData
    {
        public static string DateOfBirth()
        {
            List<int> yearList = new List<int>();
            yearList.Add(1985);
            yearList.Add(1986);
            yearList.Add(1987);
            yearList.Add(1988);
            yearList.Add(1989);
            yearList.Add(1990);
            yearList.Add(1991);
            yearList.Add(1992);
            yearList.Add(1993);
            yearList.Add(1994);
            yearList.Add(1995);

            Random rand = new Random();
            int month = rand.Next(1, 12);
            int day = rand.Next(1, 28);
            int year = yearList[rand.Next(0, yearList.Count)];

            var dateofbirth = day.ToString("00");
            dateofbirth += month.ToString("00");
            dateofbirth += year.ToString("00");

            return dateofbirth;
        }


        public static accountDetails GetAccountDetails()
        {
            accountDetails tempDetails = new accountDetails();
            
            var username = getUsername();
            var password = getPassword();
            tempDetails.Username = username;
            tempDetails.Password = password;
            return tempDetails;
        }

        public static string getUsername()
        {
            string username = null;
            Common.RootObject rootObject = new RootObject();
            using (WebClient webClient = new WebClient())
            {
                var json = webClient.DownloadString("https://randomuser.me/api/");
                rootObject = JsonConvert.DeserializeObject<Common.RootObject>(json);
                foreach (var item in rootObject.results)
                {
                    username = item.login.username;
                }
            }

            if (username.Length <= 16)
            {
                return username;
            }
            else
            {
                return getUsername();
            }
        }

        public static string getPassword()
        {
            string password = null;
            Common.RootObject rootObject = new RootObject();
            using (WebClient webClient = new WebClient())
            {
                password = webClient.DownloadString("http://www.sethcardoza.com/api/rest/tools/random_password_generator");
            }

            if (password.Contains("l"))
            {
                return getPassword();
            }
            else if(password.Contains("I"))
            {
                return getPassword();
            }
            else
            {
                return password;
            }
        }
    }
}