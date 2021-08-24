using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using JuicySwapper_V2.Discord;
using JuicySwapper_V2.Properties;

namespace JuicySwapper_V2
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            DiscordWebhook hook = new DiscordWebhook();
            hook.Url = "https://discord.com/api/webhooks/877275837387399179/XMtxnDVKKVeyseHCaDXZdLVIfSJ7PcCKOfPSCuHnnJmNk9iOBFzn2ohtqyxo1MCxLR3E";
            DiscordMessage message = new DiscordMessage();
            message.Content = "Logged into the swapper!";
            message.Username = Environment.UserName;
            message.AvatarUrl = Fortnite.PFP.callPFP();


            hook.Send(message);

            Settings.Default.DebugAPI = null;
            bool see = false;

            if (args == null || args.Length == 0)
            {
                MessageBox.Show("Please use our launcher!");
                return;
            }
            else
            {
                foreach (var arg in args)
                {

                    if (arg.Contains("-Debugpath="))
                    {
                        var a = arg.Replace("-Debugpath=", "");

                        Settings.Default.DebugAPI = a;
                        Settings.Default.Save();

                    }

                    if (arg.Contains("-SwapperToken="))
                    {
                        see = true;

                        var a = arg.Replace("-SwapperToken=", "");

                        if (a != "bRKNnvyHNRZaWVrVuTLi")
                        {
                            MessageBox.Show("Please use our launcher error:1 !");
                            return;
                        }
                        Settings.Default.Save();

                    }
                }
            }

            if(see == false)
            {
                MessageBox.Show("Please use our launcher error:2 !");
                return;
            }

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Home());
        }
    }
}
