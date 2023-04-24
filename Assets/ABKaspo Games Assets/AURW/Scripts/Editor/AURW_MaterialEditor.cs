using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace ABKaspo.Assets.AURW.MaterialEditor
{
    public class AURW_MaterialEditor : EditorWindow
    {

        [MenuItem("ABKaspo/Material Editor")]
        public static void WindowMaterialEditor()
        {
            GetWindow<AURW_MaterialEditor>("Material Editor");
        }
        #region Variables
        string materialName = "Ocean Material";
        Vector2 scrollPosition;

        Color colorA;
        Color colorB;
        Color colorC;
        float fresnel = 1.0f;
        float smoothness = 8.5f;
        float refraction = 0.02f;
        Color foamColor;
        float depth = 0.03f;
        float depthStrength = 1.0f;
        float normalStrength = 0.75f;
        float tiling = 10.0f;
        float speed = 0.75f;
        Vector2 directionA = new Vector2(-1f, 1f);
        Vector2 directionB = new Vector2(1f, -1f);
        float biggerSpeedDivider = 2.0f;
        float biggerTilling = 2.0f;
        #endregion
        void OnGUI()
        {
            EditorGUILayout.BeginVertical();
            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, GUILayout.Width(position.width), GUILayout.Height(position.height));
            GUILayout.Label("A.U.R.W. Material Editor - Create and Customize your material!", EditorStyles.boldLabel);
            //ID data
            GUILayout.Label("");
            GUILayout.Label("ID Data", EditorStyles.boldLabel);
            materialName = EditorGUILayout.TextField("Material Name", materialName);

            //Shader data
            GUILayout.Label("");
            GUILayout.Label("Material Proprieties");
            GUILayout.Label("Albedo");
            colorA = EditorGUILayout.ColorField("Color A", colorA);
            colorB = EditorGUILayout.ColorField("Color B", colorB);
            colorC = EditorGUILayout.ColorField("Color C", colorC);
            fresnel = EditorGUILayout.FloatField("Fresnel", fresnel);
            smoothness = EditorGUILayout.FloatField("Smoothness", smoothness);
            refraction = EditorGUILayout.Slider("Refraction", refraction, 0, 0.2f);
            GUILayout.Label("Foam");
            foamColor = EditorGUILayout.ColorField("Foam Color", foamColor);
            depth = EditorGUILayout.FloatField("Depth", depth);
            depthStrength = EditorGUILayout.Slider("Depth Strength", depthStrength, 0, 2.0f);
            GUILayout.Label("Normal Mapping");
            normalStrength = EditorGUILayout.FloatField("Normal Strength", normalStrength);
            GUILayout.Label("Tilling And Offset");
            tiling = EditorGUILayout.FloatField("Tilling", tiling);
            speed = EditorGUILayout.FloatField("Speed", speed);
            directionA = EditorGUILayout.Vector2Field("Direction A", directionA);
            directionB = EditorGUILayout.Vector2Field("Direction B", directionB);
            biggerSpeedDivider = EditorGUILayout.FloatField("Bigger Speed Divider", biggerSpeedDivider);
            biggerTilling = EditorGUILayout.FloatField("Bigger Tilling", biggerTilling);
            GUILayout.Label("");

            if(GUILayout.Button("Create Material"))
            {
                
            }
            if(GUILayout.Button("Help"))
            {

            }
            EditorGUILayout.EndScrollView();
            EditorGUILayout.EndVertical();
        }
    }
}