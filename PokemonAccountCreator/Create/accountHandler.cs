using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonAccountCreator.Common;
using PokemonAccountCreator.Core;

namespace PokemonAccountCreator.Create
{
    class accountHandler
    {
        public static async Task createAccounts(int numberToCreate)
        {
            
            if (Data.settings.creatingAccount == false)
            {
                Data.settings.creatingAccount = true;
                for (int i = 0; i < numberToCreate; i++)
                {
                    Captcha.getBalance.getAccounBalance();
                    Common.logManager.logMessage("Creating Account " + (i + 1));

                    if (Data.settings.creatingAccount == true)
                    {
                        if (Data.settings.captchaBalance != 0)
                        {
                            GUI.updater.updateMainForm();


                            await exicute();

                            GUI.updater.updateMainForm();

                        }
                        else
                        {
                            Common.logManager.logMessage("Your Captcha Balance is 0 please top up your accout");
                            break;

                        }
                    }
                    else
                    {
                        Common.logManager.logMessage("Bot Stoped");
                        Data.settings.creatingAccount = false;
                        break;

                    }
                }
                Data.settings.creatingAccount = false;
                await Core.saveAccounts.save();
                Common.logManager.logMessage("Accounts Saved!");
            }
            else
            {
                Common.logManager.logMessage("Please Wait Stopping Bot...");
                Data.settings.creatingAccount = false;
            }
        }


        public static async Task exicute()
        {
            //Create Captcha
            await Captcha.captchaHandler.CreateCaptchaKeyTask();

            //Create Account
            await Create.accountCreate.createAccount();

            //Verify Email
            await email.emailHandler.CheckForMailTask();

            var accountString = currentAccountDetails.info.Username + ":" + currentAccountDetails.info.Password;
            Data.settings.AccountsList.Add(accountString);

            await Common.logManager.logMessage("Account Created: " + currentAccountDetails.info.Username + ":" +
                                             currentAccountDetails.info.Password);
        }

    }
}
