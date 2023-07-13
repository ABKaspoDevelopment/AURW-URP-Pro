using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if !UNITY_2021_3_OR_NEWER
#error This unity version isn't compatible with AURW, please update your unity editor
#endif
// Custom namespaces
using ABKaspo.Assets.AURW.Checker;
using ABKaspo.Assets.AURW.EnumsScript;
using ABKaspo.Assets.AURW.Scriptables;
// AURW script and manages all aurw system values
// Please don't modify AURW, Ocean_Manager and AURW_Checker
namespace ABKaspo.Assets.AURW.Ocean
{
    [AddComponentMenu("ABKaspo/AURW/AURW Script")]
    [ExecuteAlways,RequireComponent(typeof(AURW_Checker))]
    public class AURW : MonoBehaviour
    {
        #region Variables
        //basic
        public Material OceanMat;
        public Camera _cam;
        public GameObject player;
        public OceanGeneration oceanGeneration;
        public MeshType meshType;
        public Vector3 Scale = new Vector3(1, 1, 1);
        public Vector3 Position;
        public AURW_Mesh aurw_mesh;
        public Mesh sus;
        // advanced
        public int MeshResolution = 128;
        public int Waves = 4;
        #endregion
        #region StaticValues

        #endregion
        void Start()
        {

        }
        void Update()
        {
            if(oceanGeneration == OceanGeneration.Procedural)
            {
               
            }
            if (meshType == MeshType.Water100x100) sus = aurw_mesh.biggerMesh;
            if (meshType == MeshType.Water16x16) sus = aurw_mesh.smallerMesh;
        }
    }
}