using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MailKit;
using MailKit.Net.Imap;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PokemonAccountCreator.Core
{
    class gmailManager
    {
        private static ImapClient imapClient;
        private static string emailBody;
        private static string activationUrl;

        public static async Task VerifyEmailTask(string username, string password)
        {
            await getUrl(username, password);

            ChromeOptions options = new ChromeOptions();

            ChromeDriverService service = ChromeDriverService.CreateDefaultService();

            service.SuppressInitialDiagnosticInformation = true;
            service.HideCommandPromptWindow = true;
            using (IWebDriver chromeWebDriver = new ChromeDriver(service, options))
            {
                chromeWebDriver.Navigate().GoToUrl(activationUrl);
            }
        }


        public static async Task getGmail(string username, string password)
        {
            imapClient = new ImapClient();
            imapClient.Connect("imap.gmail.com", 993, true);
            imapClient.AuthenticationMechanisms.Remove("XOAUTH2");
            imapClient.Authenticate(username, password);

            var inbox = imapClient.Inbox;
            inbox.Open(FolderAccess.ReadWrite);

            if (inbox.Count == 0)
            {
                System.Threading.Thread.Sleep(3000);
                getGmail(username, password);
                Console.WriteLine("There are no messages");
            }
            else
            {
                for (var i = 0; i < inbox.Count; i++)
                {
                    var message = inbox.GetMessage(i);
                    if (message.Subject.Contains("Pokémon Trainer Club Activation"))
                    {
                        Console.WriteLine("Subject: {0}", message.Subject);
                        string body = message.HtmlBody;

                        inbox.AddFlags(i, MessageFlags.Deleted, true);

                        imapClient.Disconnect(true);
                        emailBody = body;
                        break;
                    }
                }
            }
        }

        private static async Task<string> phraseLink(string email)
        {
            Match match = Regex.Match(email, "https://club.pokemon.com/us/pokemon-trainer-club/activated/(.*?)\"");
            if (match.Success)
            {
                string url = "https://club.pokemon.com/us/pokemon-trainer-club/activated/" + match.Groups[1].Value;
                Console.WriteLine(url);
                return url;
            }
            return null;
        }

        public static async Task getUrl(string username, string password)
        {
            await getGmail(username, password);
            activationUrl = phraseLink(emailBody).Result;
        }
    }
}