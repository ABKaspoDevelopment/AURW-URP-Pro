using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ABKaspo.Assets.AURW.Scriptables
{
    [CreateAssetMenu(fileName ="AURW_Mesh", menuName ="ABKaspo/AURW/Utility/Mesh", order = 0)]
    public class AURW_Mesh : ScriptableObject
    {
        public Mesh biggerMesh;
        public Mesh smallerMesh;
    }
}