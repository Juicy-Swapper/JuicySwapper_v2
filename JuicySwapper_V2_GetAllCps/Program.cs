using JuicySwapper_V2_GetAllCps.Exports;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JuicySwapper_V2_GetAllCps
{
    public static class Program
    {
        public static List<string> cids = new List<string>();
        static void Main(string[] args)
        {
            ids();

            

        }

        


        public static void ids()
        {
            List<string> list = new List<string>(); 
            WebClient webdownload = new WebClient();
            dynamic parsed = JArray.Parse(webdownload.DownloadString("https://benbot.app/api/v1/cosmetics/br?lang=en"));
            
            foreach(var cid in parsed)
            {
                string a = cid.id;
                if (a.Contains("CID"))
                {
                    a.Replace("CID", "HS");
                    list.Add(a.Replace("CID_", "HS_"));
                    Console.WriteLine(a.Replace("CID_", "HS_"));
                }
            }

            Console.WriteLine("\n\n");

            foreach (string cids in list)
            {

                try
                {
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }
        }
    }
}
