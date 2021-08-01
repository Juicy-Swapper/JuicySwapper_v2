using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuicySwapper_V2.Oodle.Utilities
{
    class Oodle
    {
        public static byte[] SourceArray;
        private static byte[] _targetArray;
        private static readonly byte[] DestinationArray = new byte[4];
        private static string _string1;
        private static int _targetLength;
        public static int SourceLength;

        public static void Prepare(string filePath)
        {
            SourceArray = null;
            SourceArray = Reader(filePath);
            Array.Copy(SourceArray, DestinationArray, 4);
            Array.Copy(SourceArray, 12, DestinationArray, 0, 4);
            _string1 = Encoding.ASCII.GetString(DestinationArray);
            if (_string1 == "KRKN")
            {
                _targetLength = (int)BitConverter.ToUInt32(SourceArray, 20);
                _targetArray = new byte[_targetLength];
                Array.Copy(SourceArray, 24, _targetArray, 0, _targetLength);
            }

            SourceLength = SourceArray.Length;
        }

        private static byte[] Reader(string fileName)
        {
            var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite);
            var binaryReader = new BinaryReader(fileStream);
            var length = new FileInfo(fileName).Length;
            var result = binaryReader.ReadBytes((int)length);
            binaryReader.Close();
            fileStream.Close();
            return result;
        }
    }
}
