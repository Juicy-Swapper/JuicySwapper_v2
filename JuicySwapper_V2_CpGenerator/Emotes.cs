using CUE4Parse.Encryption.Aes;
using CUE4Parse.FileProvider;
using CUE4Parse.UE4.Objects.Core.Misc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JuicySwapper_V2_CpGenerator
{
    class Emotes
    {
        public static string maker(string name, string icon, string CMF, string CMM)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Formatting.Indented;

                writer.WriteStartObject();
                writer.WritePropertyName("name");
                writer.WriteValue("Take_The_Elf_" + name.Replace(" ", "_"));
                writer.WritePropertyName("icon");
                writer.WriteValue("https://fortnite-api.com/images/cosmetics/br/" + icon + "/smallicon.png");
                writer.WritePropertyName("CMF");
                writer.WriteValue(CMF);
                writer.WritePropertyName("CMM");
                writer.WriteValue(CMM);
                writer.WritePropertyName("type");
                writer.WriteValue("specialTake");
                writer.WriteEnd();
            }

            Console.WriteLine(sb.ToString());
            return sb.ToString();
        }

        static string jsonstr = "";
        static int loads = 0;
        public static void getthem()
        {
            List<string> list = new List<string>();
            WebClient webdownload = new WebClient();
            dynamic parsed = JArray.Parse(webdownload.DownloadString("https://benbot.app/api/v1/cosmetics/br?lang=en"));

            foreach (var cid in parsed)
            {
                string a = cid.id + "," + cid.name;
                if (a.Contains("EID"))
                {
                    list.Add(a);
                    Console.WriteLine(a);
                }
            }
            var _Provider = new DefaultFileProvider("C:\\Program Files\\Epic Games\\Fortnite\\FortniteGame\\Content\\Paks", SearchOption.TopDirectoryOnly);

            _Provider.Initialize();

            _Provider.SubmitKey(new FGuid("00000000000000000000000000000000"), new FAesKey(Program.AES()));

            _Provider.LoadMappings();

            foreach (string rr in list)
            {
                try
                {
                    string[] ids = rr.Split(',');
                    var exports1 = _Provider.LoadObjectExports($"FortniteGame/Content/Athena/Items/Cosmetics/Dances/{ids[0]}.uasset");
                    dynamic id = JArray.Parse(JsonConvert.SerializeObject(exports1, formatting: Formatting.Indented));

                    foreach (var export in id)
                    {
                        string male = export.Properties.Animation.AssetPathName;
                        string female = export.Properties.AnimationFemaleOverride.AssetPathName;

                        if (female.Length < 101)
                        {
                            loads += 1;
                            jsonstr += maker(ids[1], ids[0], female, male) + ", ";
                        }
                    }

                }
                catch
                {

                }
            }
            Console.WriteLine(loads.ToString());
            Console.WriteLine(jsonstr.ToString());
            File.WriteAllText("emotes.json", jsonstr);
            Console.WriteLine("Done!!!!!!!!!!!!!!!!!!");
        }
    }

    
}
