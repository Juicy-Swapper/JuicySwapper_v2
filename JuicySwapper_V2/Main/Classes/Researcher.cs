using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuicySwapper_V2.IO
{
    class Researcher
    {
        public static bool SwapUasset(string a, long b, byte[] c)
        {
            try 
            {
                BinaryWriter binaryWriter = new BinaryWriter(File.Open(a, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(b, SeekOrigin.Begin);
                binaryWriter.Write(c);
                binaryWriter.Close();

                return true;
            }
            catch
            {
                return false;
            }   
        }

        public static bool ConvertInUasset(string file, string convert, string revert)
        {
            byte[] a = Encoding.UTF8.GetBytes(convert);
            byte[] b = Encoding.UTF8.GetBytes(revert);
            if ((convert.Length - revert.Length) >= 0)
            {
                for (int i = 0; i < convert.Length - revert.Length; i++)
                {
                    b = c(b, 0);
                }

                if (File.Exists(file))
                {
                    Stream s = File.Open(file, FileMode.Open, FileAccess.ReadWrite);

                    long offset;

                    var task = Task.Run(() => Find(s, 0, a, 0));
                    if (task.Wait(TimeSpan.FromSeconds(10)))
                    {
                        offset = task.Result;
                    }
                    else
                        offset = 0;

                    s.Close();

                    BinaryWriter binaryWriter = new BinaryWriter(File.Open(file, FileMode.Open, FileAccess.ReadWrite));
                    binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
                    binaryWriter.Write(b);
                    binaryWriter.Close();

                    return true;
                }
                else
                {

                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private static byte[] c(byte[] mahOldByteArray, byte newByte)
        {
            var mahByteArray = new List<byte>();
            mahByteArray.AddRange(mahOldByteArray);
            mahByteArray.Add(newByte);
            return mahByteArray.ToArray();
        }

        private static long Find(Stream a, long b, byte[] c, long max)
        {
            int searchPosition = 0;
            long result = 0;
            a.Position = b;
            bool max1 = false;

            if (max == 0)
                max1 = false;

            else if (max > 1)
                max1 = true;

            while (true)
            {
                if (max1)
                {
                    if (a.Position == max)
                        return result;
                }
                else
                {
                    if (a.Position == 5000000000)
                        return result;
                }

                var latestbyte = a.ReadByte();
                if (latestbyte == -1)
                    break;

                if (latestbyte == c[searchPosition])
                {
                    searchPosition++;
                    if (searchPosition == c.Length)
                    {
                        result = a.Position - c.Length;
                        return result;
                    }
                }
                else
                    searchPosition = 0;
            }
            return result;
        }
    }
}
