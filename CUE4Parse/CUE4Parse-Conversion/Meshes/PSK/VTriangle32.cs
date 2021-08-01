﻿using CUE4Parse.UE4.Writers;

namespace CUE4Parse_Conversion.Meshes.PSK
{
    public class VTriangle32
    {
        public readonly int[] WedgeIndex;
        public readonly byte MatIndex;
        public readonly byte AuxMatIndex;
        public readonly uint SmoothingGroups;

        public VTriangle32(int[] wedgeIndex, byte matIndex, byte auxMatIndex, uint smoothingGroups)
        {
            WedgeIndex = wedgeIndex;
            MatIndex = matIndex;
            AuxMatIndex = auxMatIndex;
            SmoothingGroups = smoothingGroups;
        }

        public void Serialize(FArchiveWriter writer)
        {
            writer.Write(WedgeIndex[0]);
            writer.Write(WedgeIndex[1]);
            writer.Write(WedgeIndex[2]);
            writer.Write(MatIndex);
            writer.Write(AuxMatIndex);
            writer.Write(SmoothingGroups);
        }
    }
}