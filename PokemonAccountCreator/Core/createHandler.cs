using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PokemonAccountCreator.Common;

namespace PokemonAccountCreator.Core
{
    class createHandler
    {
        private static string baseUrl = "https://club.pokemon.com/us/pokemon-trainer-club";
        public static IWebDriver chromeWebDriver;
        public static string googleKey = "6LdpuiYTAAAAAL6y9JNUZzJ7cF3F8MQGGKko1bCy";

        public static string captcaCode;
        public static bool captcahCodeCreated = false;

        public static async Task createAccount()
        {
            ChromeOptions options = new ChromeOptions();

            ChromeDriverService service = ChromeDriverService.CreateDefaultService();

            service.SuppressInitialDiagnosticInformation = true;
            service.HideCommandPromptWindow = true;

            chromeWebDriver = new ChromeDriver(service, options);

           // chromeWebDriver = new ChromeDriver(@"C:\Program Files (x86)\ChromeDriver");
            
            currentAccountDetails.info = createData.GetAccountDetails();
            currentAccountDetails.info.Email = Core.createAccount.rootEmail.Replace("@gmail.com", "") + currentAccountDetails.info.Username + "@gmail.com";
            setupWebDriver();
            completeDobPage();
            completeMainPage();
            await completeCaptcha();
            submitForm();
        }

        private static void setupWebDriver()
        {
            chromeWebDriver.Navigate().GoToUrl(baseUrl);
            chromeWebDriver.Manage().Window.Size = new Size(600, 600);
            chromeWebDriver.FindElement(By.Id("user-account-signup")).Click();
        }

        private static void completeDobPage()
        {
            Thread.Sleep(3000);
            chromeWebDriver.FindElement(By.Name("dob")).SendKeys(createData.DateOfBirth());
            //Change Country?
            chromeWebDriver.FindElement(By.XPath("//input[@type='submit']")).Click();
        }

        private static void completeMainPage()
        {
            Thread.Sleep(1000);
            inputUsername();

            chromeWebDriver.FindElement(By.Id("id_password")).SendKeys(currentAccountDetails.info.Password);
            chromeWebDriver.FindElement(By.Id("id_confirm_password")).SendKeys(currentAccountDetails.info.Password);

            chromeWebDriver.FindElement(By.Id("id_email")).SendKeys(currentAccountDetails.info.Email);
            chromeWebDriver.FindElement(By.Id("id_confirm_email")).SendKeys(currentAccountDetails.info.Email);

            chromeWebDriver.FindElement(By.Id("id_email_opt_in")).Click();
            chromeWebDriver.FindElement(By.Id("id_public_profile_opt_in_1")).Click();
            chromeWebDriver.FindElement(By.Id("id_terms")).Click();
        }

        private async static Task completeCaptcha()
        {           

                var element = chromeWebDriver.FindElement(By.Id("g-recaptcha-response"));
                IJavaScriptExecutor scriptExecutor = chromeWebDriver as IJavaScriptExecutor;
                scriptExecutor.ExecuteScript("arguments[0].setAttribute('style', 'display:true')", element);

                if (captcahCodeCreated == true)
                {
                    List<string> characters = new List<string>();
                    int chunkSize = 200;
                    int stringLength = captcaCode.Length;
                    for (int i = 0; i < stringLength; i += chunkSize)
                    {
                        if (i + chunkSize > stringLength) chunkSize = stringLength - i;
                        characters.Add(captcaCode.Substring(i, chunkSize));

                    }
                    foreach (var item in characters)
                    {
                        element.SendKeys(item);
                    }
                    captcahCodeCreated = false;
                    captcaCode = null;
                }
                else
                {
                    await captchaService.exicuteSolve(googleKey);
                }
        }

      

        private static void submitForm()
        {
            chromeWebDriver.FindElement(By.XPath("//input[@type='submit']")).Click();
            while (chromeWebDriver.Url != "https://club.pokemon.com/us/pokemon-trainer-club/parents/email")
            {
                System.Threading.Thread.Sleep(3000);
            }
           
            chromeWebDriver.Close();
        }

        private static void inputUsername()
        {
            chromeWebDriver.FindElement(By.Id("id_username")).Clear();
            chromeWebDriver.FindElement(By.Id("id_username")).SendKeys(currentAccountDetails.info.Username);
            chromeWebDriver.FindElement(By.Id("check-availability-username")).Click();
            Thread.Sleep(500);
            if (isUsernameAvailable() == false)
            {
                currentAccountDetails.info = createData.GetAccountDetails();
                currentAccountDetails.info.Email = Core.createAccount.rootEmail.Replace("@gmail.com", "") + currentAccountDetails.info.Username + "@gmail.com";
                inputUsername();
            }
            else
            {
                return;
            }
        }

        private static bool isUsernameAvailable()
        {
            foreach (
                var item in
                    chromeWebDriver.FindElements(
                        By.XPath("//*[contains(concat(' ', @class, ' '), ' alert alert-box alert-error ')]")))
            {
                if (item.Text.Contains("invalid"))
                {
                    return false;
                }
            }
            foreach (
                var item in
                    chromeWebDriver.FindElements(
                        By.XPath("//*[contains(concat(' ', @class, ' '), ' alert alert-box alert-success ')]")))
            {
                if (item.Text.Contains("available"))
                {
                    return true;
                }
            }
            return false;
        }
    }
}