using Newtonsoft.Json.Linq;
using System.IO;
using CUE4Parse.FileProvider;
using System.Net;
using System.Threading.Tasks;
using CUE4Parse.UE4.Versions;
using CUE4Parse.Encryption.Aes;
using CUE4Parse.UE4.Vfs;
using System.Collections.Generic;
using System;
using System.Windows.Forms;
using CUE4Parse.UE4.Objects.Core.Misc;
using System.Text;
using System.Threading;

namespace JuicySwapper_V2.IO
{
    class Engine
    {
        public static DefaultFileProvider _Provider;

        public static void disope()
        {
            _Provider.Dispose();
        }

        public static bool ExportCompressed(string assetDir, string dir)
        {
            _Provider = new DefaultFileProvider(Directory.GetCurrentDirectory() + "\\PakTemps", SearchOption.TopDirectoryOnly);

            _Provider.Initialize();

            _Provider.SubmitKey(new FGuid("00000000000000000000000000000000"), new FAesKey(AES()));

            _Provider.LoadLocalization();

            try
            {
                Directory.CreateDirectory($"{dir}\\{assetDir.Replace(Path.GetFileName(assetDir), "")}");

                if (!_Provider.TrySavePackage(assetDir, out var assets))
                    return false;

                foreach (var kvp in assets)
                {
                    File.WriteAllBytes(Path.Combine(dir, kvp.Key), kvp.Value);
                }

                _Provider.Dispose();

                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        private static string AES()
        {
            dynamic parse = JObject.Parse(new WebClient().DownloadString("https://benbot.app/api/v1/aes"));
            return parse.mainKey;
        }
    }
}

