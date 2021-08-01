using JuicySwapper_V2.Oodle.Utilities;
using System;

namespace JuicySwapper_V2.Oodle
{
    class Oodle
    {
        public static void Compress(string decompressedFilePath, string outputPath)
        {
            JuicySwapper_V2.Oodle.Utilities.Oodle.Prepare(decompressedFilePath); // Gets the source prepared
            uint @uint; // Needs to be outside so it always has a value
            try
            {
                @uint = OodleStream.GetCompressedLength(JuicySwapper_V2.Oodle.Utilities.Oodle.SourceArray, JuicySwapper_V2.Oodle.Utilities.Oodle.SourceLength,
                    OodleFormat.Kraken, OodleCompressionLevel.Level5);
            }
            catch (AccessViolationException)
            {
                @uint = 64U;
            }

            var compressed = OodleStream.OodleCompress(JuicySwapper_V2.Oodle.Utilities.Oodle.SourceArray, JuicySwapper_V2.Oodle.Utilities.Oodle.SourceLength,
                OodleFormat.Kraken, OodleCompressionLevel.Level5, @uint);


            Helper.Write(compressed, outputPath); // Writing the data
        }
    }
}
