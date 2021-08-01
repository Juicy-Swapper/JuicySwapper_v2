﻿using CUE4Parse.UE4.Assets.Readers;
using CUE4Parse.UE4.Objects.Core.Math;
using CUE4Parse.UE4.Objects.Meshes;
using CUE4Parse.UE4.Versions;

namespace CUE4Parse.UE4.Assets.Exports.SkeletalMesh
{
    public class FSoftVertex : FSkelMeshVertexBase
    {
        private const int _MAX_SKELETAL_UV_SETS_UE4 = 4;
        
        public FMeshUVFloat[] UV;
        public FColor Color;
        
        public FSoftVertex(FAssetArchive Ar, bool isRigid = false)
        {
            SerializeForEditor(Ar);

            UV = new FMeshUVFloat[_MAX_SKELETAL_UV_SETS_UE4];
            for (var i = 0; i < UV.Length; i++)
                UV[i] = new FMeshUVFloat(Ar);

            Color = Ar.Read<FColor>();
            if (!isRigid)
            {
                Infs = new FSkinWeightInfo(Ar, Ar.Ver >= UE4Version.VER_UE4_SUPPORT_8_BONE_INFLUENCES_SKELETAL_MESHES);
            }
            else
            {
                Infs = new FSkinWeightInfo();
                Infs.BoneIndex[0] = Ar.Read<byte>();
                Infs.BoneWeight[0] = 255;
            }
        }
    }
    
    public class FRigidVertex : FSoftVertex
    {
        public FRigidVertex(FAssetArchive Ar) : base(Ar, true)
        {
            
        }
    }
}