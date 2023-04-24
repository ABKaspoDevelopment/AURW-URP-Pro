using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ABKaspo.Assets.AURW.Ocean;
namespace ABKaspo.Assets.AURW.Ocean.Generation
{
    public class OceanChunkRender : MonoBehaviour
    {
        MeshType meshType;
        void Start()
        {
            OceanManager.__meshType = meshType;
        }
        public void SemiProceduralGeneration(MeshType meshType)
        {
            if (OceanManager.___generationType == GenerationType.SemiProcedural)
            { 

            }
        }
    }
}