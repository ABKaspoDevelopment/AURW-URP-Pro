using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ABKaspo.Scriptables
{
    [CreateAssetMenu(fileName = "Meshes", menuName = "ABKaspo/AURW/Meshes", order = 0)]
    public class Meshes : ScriptableObject
    {
        public Mesh biggerWater;
        public Mesh smallerWater;
        public GameObject Procedural;
    }
}