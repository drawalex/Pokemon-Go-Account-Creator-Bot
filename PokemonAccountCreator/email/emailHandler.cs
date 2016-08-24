using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MailKit;
using MailKit.Net.Imap;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace PokemonAccountCreator.email
{
    class emailHandler
    {
        
        public static async Task CheckForMailTask()
        {
            using (ImapClient imapClient = new ImapClient())
            {
                imapClient.Connect("imap.gmail.com", 993, true);
                imapClient.AuthenticationMechanisms.Remove("XOAUTH2");
                imapClient.Authenticate(Data.settings.gmailUsername, Data.settings.gmailPassword);

                var inbox = imapClient.Inbox;
                inbox.Open(FolderAccess.ReadWrite);

                if (inbox.Count == 0)
                {
                    imapClient.Disconnect(true);
                    return;
                }
                else
                {
                    int inboxNo = 0;
                    foreach (var item in inbox)
                    {
                        var subject = inbox.GetMessage(inboxNo);
                        if (subject.Subject.Contains("Pokémon Trainer Club Activation"))
                        {
                            string body = item.HtmlBody;

                            await ActivateEmailTask(body);
                            inbox.AddFlags(inboxNo, MessageFlags.Deleted, true);
                        }
                        inboxNo++;
                    }
                    imapClient.Disconnect(true);
                }
            }
            
        }

        private static async Task ActivateEmailTask(string body)
        {
            Match match = Regex.Match(body, "https://club.pokemon.com/us/pokemon-trainer-club/activated/(.*?)\"");
            if (match.Success)
            {
                string activationUrl = "https://club.pokemon.com/us/pokemon-trainer-club/activated/" + match.Groups[1].Value;

                ChromeOptions options = new ChromeOptions();
                ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                service.SuppressInitialDiagnosticInformation = true;
                service.HideCommandPromptWindow = true;
                using (IWebDriver chromeWebDriver = new ChromeDriver(service, options))
                {
                    chromeWebDriver.Navigate().GoToUrl(activationUrl);
                }
            }
        }

    }
}