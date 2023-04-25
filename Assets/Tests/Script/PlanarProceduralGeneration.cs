using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ABKaspo.Scriptables;

namespace ABKaspo.Assets.AURW.Ocean.Generation.Procedural.Planar
{
    public class PlanarProceduralGeneration : MonoBehaviour
    {
        public GameObject player = OceanManager._player;
        GameObject plane = OceanManager.__meshes.Procedural;

        Vector2 planeSize;
        int resolution;
        
        Mesh generatedMesh;
        MeshFilter meshFilter;
        MeshRenderer meshRenderer;

        List<Vector3> vertices;
        List<int> triangles;
        void Awake()
        {
            generatedMesh = plane.GetComponent<Mesh>();
            meshFilter = plane.GetComponent<MeshFilter>();
            meshFilter.mesh = generatedMesh;
            meshRenderer = plane.GetComponent<MeshRenderer>();
            meshRenderer.material = OceanManager.___oceanMat;
        }
        void Start()
        {
            
        }
        void Update()
        {
            
        }
        void GenerateOcean(Vector2 size, int resolution)
        {

        }
    }
}