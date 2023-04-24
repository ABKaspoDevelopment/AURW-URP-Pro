using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ABKaspo.Assets.AURW.Ocean;
namespace ABKaspo.Assets.AURW.Ocean.Refraction
{
    public class RefracrionManager : MonoBehaviour
    {
        Material mat;
        Camera cam;
        void Start()
        {
            mat = OceanManager.___oceanMat;
            cam = OceanManager.____camera;
        }
    }
}