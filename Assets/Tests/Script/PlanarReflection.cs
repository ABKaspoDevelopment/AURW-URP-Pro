using System;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Serialization;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace ABKaspo.Proves
{
    public class PlanarReflection : MonoBehaviour
    {
        Camera m_reflectionCamera;
        Camera m_mainCamera;
        public GameObject m_ReflectionPlane;
        public RenderTexture m_renderTarget;
        public Material reflectionMat;
        void Start()
        {
            GameObject reflectionCameraGo = new GameObject("ReflectionCamera");
            m_reflectionCamera = reflectionCameraGo.AddComponent<Camera>();
            //m_reflectionCamera.enabled = false;
            m_mainCamera = Camera.main;
            m_renderTarget = new RenderTexture(Screen.width, Screen.height, 24);
        }
        void Update()
        {
            
        }
        private void OnPostRender()
        {
            RenderReflection();
        }
        void RenderReflection()
        {
            m_mainCamera.CopyFrom(m_mainCamera);
            Vector3 cameraDiretionWorldSpace = m_mainCamera.transform.forward;
            Vector3 cameraUpWorldSpace = m_mainCamera.transform.up;
            Vector3 cameraPositionWorldSpace = m_mainCamera.transform.position;

            //Transfor the vectors to  the floor's space
            Vector3 cameraDirectionPlaneSpace = m_ReflectionPlane.transform.InverseTransformDirection(cameraDiretionWorldSpace);
            Vector3 cameraUpPlaneSpace = m_ReflectionPlane.transform.InverseTransformDirection(cameraUpWorldSpace);
            Vector3 cameraPositionPlaneSpace = m_ReflectionPlane.transform.InverseTransformDirection(cameraPositionWorldSpace);

            //mirror the vectors
            cameraDirectionPlaneSpace *= -1.0f;
            cameraUpPlaneSpace *= -1.0f;
            cameraPositionPlaneSpace *= -1.0f;

            //Transform the vector back to world space
            cameraDiretionWorldSpace = m_ReflectionPlane.transform.TransformDirection(cameraDirectionPlaneSpace);
            cameraUpWorldSpace = m_ReflectionPlane.transform.TransformDirection(cameraUpPlaneSpace);
            cameraPositionWorldSpace = m_ReflectionPlane.transform.TransformDirection(cameraPositionPlaneSpace);

            //set camera position and rotation
            m_reflectionCamera.transform.position = cameraPositionWorldSpace;
            m_reflectionCamera.transform.LookAt(cameraPositionWorldSpace + cameraDiretionWorldSpace, cameraUpWorldSpace);

            //Set render target for the reflection camera
            m_reflectionCamera.Render();

            //Draw full screen quad
            DrawQuad();
        }
        void DrawQuad()
        {
            GL.PushMatrix();

            //use round Material to draw the quad
            reflectionMat.SetPass(0);
            reflectionMat.SetTexture("_Reflection", m_renderTarget);

            GL.LoadOrtho();

            GL.Begin(GL.QUADS);
            GL.TexCoord2(1.0f, 0.0f);
            GL.Vertex3(0.0f, 0.0f, 0.0f);
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex3(0.0f, 1.0f, 0.0f);
            GL.TexCoord2(0.0f, 1.0f);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.TexCoord2(0.0f, 0.0f);
            GL.Vertex3(1.0f, 0.0f, 0.0f);
            GL.End();
        }
    }
}