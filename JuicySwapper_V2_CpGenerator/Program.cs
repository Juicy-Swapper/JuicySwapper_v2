using CUE4Parse.Encryption.Aes;
using CUE4Parse.FileProvider;
using CUE4Parse.UE4.Objects.Core.Misc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace JuicySwapper_V2_CpGenerator
{
    public class jsonstuff
    {
        public string name { get; set; }
        public string icon { get; set; }
        public string HWID { get; set; }
        public string CreatedAt { get; set; }
        public bool paid { get; set; }
        public bool boost { get; set; }
    }
    class Program
    {
        

        
        static void Main(string[] args)
        {
            Emotes.getthem();
            //ids();
        }

        public static string AES()
        {
            dynamic parse = JObject.Parse(new WebClient().DownloadString("https://benbot.app/api/v1/aes"));
            return parse.mainKey;
        }

        public static void ids()
        {
            List<string> list = new List<string>();
            List<string> hslist = new List<string>();
            WebClient webdownload = new WebClient();
            dynamic parsed = JArray.Parse(webdownload.DownloadString("https://benbot.app/api/v1/cosmetics/br?lang=en"));

            foreach (var cid in parsed)
            {
                string a = cid.id + "," + cid.name;
                if (a.Contains("CID"))
                {
                    list.Add(a);
                    Console.WriteLine(a);
                }
            }

            Console.Read();


            var _Provider = new DefaultFileProvider("C:\\Program Files\\Epic Games\\Fortnite\\FortniteGame\\Content\\Paks", SearchOption.TopDirectoryOnly);

            _Provider.Initialize();

            _Provider.SubmitKey(new FGuid("00000000000000000000000000000000"), new FAesKey(AES()));

            _Provider.LoadMappings();

            foreach (string rr in list)
            {
                try
                {
                    string[] ids = rr.Split(',');
                    var exports1 = _Provider.LoadObjectExports($"FortniteGame/Content/Athena/Items/Cosmetics/Characters/{ids[0]}.uasset");
                    dynamic id = JArray.Parse(JsonConvert.SerializeObject(exports1, formatting: Formatting.Indented));

                    foreach (var export in id)
                    {
                        try
                        {
                            string gotit = export.Properties.HeroDefinition.ObjectPath;

                            var exportshd = _Provider.LoadObjectExports(gotit.Replace(".0", ""));

                            dynamic hs = JArray.Parse(JsonConvert.SerializeObject(exportshd, formatting: Formatting.Indented));

                            foreach (var parhs in hs)
                            {
                                foreach (var prhs1 in parhs.Properties.Specializations)
                                {
                                    string epot = prhs1.AssetPathName;
                                    thewlast(epot,ids[0] , ids[1], _Provider);
                                }
                            }
                        }
                        catch
                        {

                        }


                    }

                    
                }
                catch
                {

                }
                

            }
            File.WriteAllText("cps.json", jsonstr);
            Console.WriteLine("Done!!!!!!!!!!!!!!!!!!");
        }

        static string jsonstr = "";

        public static void thewlast(string cids, string icon, string ids, DefaultFileProvider _Provider)
        {
            string sss = Path.GetExtension(cids);
            string filesss = cids.Replace(sss, "");

            var exports = _Provider.LoadObjectExports(filesss);

            string thing = JsonConvert.SerializeObject(exports, formatting: Formatting.Indented);

            dynamic parsed1 = JArray.Parse(thing);

            foreach (var export in parsed1)
            {
                string head = null;
                string body = null;
                string acc = null;
                foreach (var cp in export.Properties.CharacterParts)
                {

                    string na = cp.AssetPathName;
                    if (na.Contains("/Bodies/"))
                    {
                        body = na;
                    }
                    if (na.Contains("/FaceAccessories/"))
                    {
                        acc = na;
                    }
                    if (na.Contains("/Heads/"))
                    {
                        head = na;
                    }
                }

                if (acc != null)
                {
                    head = acc;
                }

                maker(ids, icon, body, head);

                jsonstr += maker(ids, icon, body, head) + ", ";


            }

            
        }

        public static string maker(string name, string icon, string body, string head)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Formatting.Indented;

                writer.WriteStartObject();
                writer.WritePropertyName("name");
                writer.WriteValue("cp_" + name.Replace(" ", "_"));
                writer.WritePropertyName("icon");
                writer.WriteValue("https://fortnite-api.com/images/cosmetics/br/" + icon + "/smallicon.png");
                writer.WritePropertyName("Body");
                writer.WriteValue(body);
                writer.WritePropertyName("Head");
                writer.WriteValue(head);
                writer.WriteEnd();
            }

            Console.WriteLine(sb.ToString());
            return sb.ToString();
        }
    }
}
