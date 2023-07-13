using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
// Custom namespaces
using ABKaspo.Assets.AURW.EnumsScript;
using ABKaspo.Assets.AURW.Scriptables;

// This script modify the AURW.cs inspector!
// Please don't modify AURW, Ocean_Manager and AURW_Checker
namespace ABKaspo.Assets.AURW.ScriptEditor
{
    [CustomEditor(typeof(AURW.Ocean.AURW)), DisallowMultipleComponent]
    public class Editor_AURW : Editor
    {
        private AURW.Ocean.AURW pc;
        #region New Styles
        GUIStyle AURW_Title;
        GUIStyle AURW_Header1;
        GUIStyle AURW_Header;
        GUIStyle BoxPanel;
        Texture2D BoxPanelColor;
        #endregion
        private void OnEnable()
        {
            pc = target as AURW.Ocean.AURW;
        }
        public override void OnInspectorGUI()
        {
            // Custom Styles
            #region New Styles Settings
            AURW_Title = AURW_Title != null ? AURW_Title : new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter, richText = true, fontSize = 16 };
            AURW_Header = AURW_Header != null ? AURW_Header : new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleLeft, fontStyle = FontStyle.Bold, fontSize = 14 };
            AURW_Header1 = AURW_Header1 != null ? AURW_Header1 : new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter, fontStyle = FontStyle.Bold, richText = true, fontSize = 14 };
            BoxPanel = BoxPanel != null ? BoxPanel : new GUIStyle(GUI.skin.box) { normal = { background = BoxPanelColor } };
            #endregion
            // Title and Docs
            GUILayout.Label("AURW", AURW_Title);
            EditorGUILayout.BeginVertical(BoxPanel);
            if (GUILayout.Button("Read Documentation")) Application.OpenURL("https://docs.google.com/document/d/1FkTGD58mZlfeWaX7rTZpsTUBHmCEAJalPNYCxVOVIQ0/edit?usp=sharing");
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Report a Bug")) Application.OpenURL("https://docs.google.com/forms/d/e/1FAIpQLScYCErLxgAXTKkB8Y7beceQ9OeZ2Z9sQO6JxgOYaWgBwfbyQQ/viewform");
            if (GUILayout.Button("Client Help")) Application.OpenURL("https://docs.google.com/forms/d/e/1FAIpQLSf_D9TXyxgWlRq1WwIdEAyXJEgXmeCjgujQigvth_aziu1XQg/viewform");
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();
            if (pc.aurw_mesh == null) EditorGUILayout.HelpBox("If object reference not set to an instance of an object error please select AURW Meshes propietie!", MessageType.Info);
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider, GUILayout.MaxHeight(6)); EditorGUILayout.Space();
            //Generation Settings
            GUILayout.Label("Basic Settings", AURW_Header);
            pc.OceanMat = (Material)EditorGUILayout.ObjectField("Ocean Material", pc.OceanMat, typeof(Material), false);
            pc._cam = (Camera)EditorGUILayout.ObjectField("Main camera", pc._cam, typeof(Camera), true);
            pc.oceanGeneration = (OceanGeneration)EditorGUILayout.EnumPopup("Select type of generation", pc.oceanGeneration);
            // if bymesh is selected show some values
            if (pc.oceanGeneration == OceanGeneration.ByMesh)
            {
                pc.Position = EditorGUILayout.Vector3Field("Position", pc.Position);
                pc.Scale = EditorGUILayout.Vector3Field("Scale", pc.Scale);
                pc.meshType = (MeshType)EditorGUILayout.EnumPopup("Select type of mesh", pc.meshType);
                    EditorGUILayout.BeginVertical(BoxPanel);
                if (GUILayout.Button("Generate Water"))
                {
                    if (GameObject.Find("Ocean"))
                    {
                        EditorUtility.DisplayDialog("AURW", "AURW found an ocean, you mustn't create twice oceans!", "I Understand");
                        return;
                    }
                    if (GameObject.Find("AURW") == null)
                    {

                        bool sus = EditorUtility.DisplayDialog("AURW", "AURW Cloudn't find a GameObject with AURW as name. AURW component's GameObject's name must be as AURW! Would you like create one?", "Ok", "No, Thanks");
                        if (sus == false)
                        {
                            Debug.Log("AURW: Creating GameObject AURW was cancelled!");
                            return;
                        }
                        if (sus == true)
                        {
                            GameObject amogus = new GameObject("AURW");
                            amogus.AddComponent<AURW.Ocean.AURW>();
                            amogus.AddComponent<Checker.AURW_Checker>();
                            if (GameObject.Find("AURW") == null)
                            {
                                Debug.LogError("AURW: Creating AURW GameObject was failed! Make you shure that you have a suported version (Unity 2021.3 or newer0)");
                                return;
                            }
                            else Debug.Log("AURW: Creating AURW GameObject was successfully added!");
                        }
                    }
                    GameObject susamosus = new GameObject("AURW");
                    susamosus.name = "Ocean";
                    susamosus.transform.parent = GameObject.Find("AURW").transform;
                    susamosus.AddComponent<MeshFilter>().mesh = pc.sus;
                    susamosus.AddComponent<MeshRenderer>().material = pc.OceanMat;
                    susamosus.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                    susamosus.transform.localScale = pc.Scale;
                    susamosus.transform.position = pc.Position;
                }
                if(GUILayout.Button("Delete Ocean"))
                {
                    if (GameObject.Find("Ocean") == null)
                    {
                        EditorUtility.DisplayDialog("AURW", "AURW cloudn't find ocean GameObject! You must create one to delete it!", "SUS");
                    }   
                    GameObject sus = GameObject.Find("Ocean");
                    GameObject.DestroyImmediate(sus);
                }
                EditorGUILayout.EndVertical();
                EditorGUILayout.Space();
                EditorGUILayout.LabelField("", GUI.skin.horizontalSlider, GUILayout.MaxHeight(6)); EditorGUILayout.Space();
                GUILayout.Label("Scriptables", AURW_Title);
                pc.aurw_mesh = (AURW_Mesh)EditorGUILayout.ObjectField("AURW Mesh (Scriptable)", pc.aurw_mesh, typeof(AURW_Mesh), false);
                EditorGUILayout.Space();
                EditorGUILayout.LabelField("", GUI.skin.horizontalSlider, GUILayout.MaxHeight(6)); EditorGUILayout.Space();

            }
            if (pc.oceanGeneration == OceanGeneration.Procedural)
            {
                EditorGUILayout.Space();
                EditorGUILayout.LabelField("", GUI.skin.horizontalSlider, GUILayout.MaxHeight(6)); EditorGUILayout.Space();
                EditorGUILayout.LabelField("System settings", AURW_Header);
                EditorGUILayout.Space();
                pc.MeshResolution = EditorGUILayout.IntField("Mesh Resolution", pc.MeshResolution);
                pc.Waves = EditorGUILayout.IntField("Waves", pc.Waves);
                if (pc.Waves <= 0) EditorGUILayout.HelpBox("Waves value must be more than 1", MessageType.Warning);
                if (pc.MeshResolution <= 0) EditorGUILayout.HelpBox("Resolution values must be more than 1", MessageType.Error);
                EditorGUILayout.Space();
                EditorGUILayout.LabelField("", GUI.skin.horizontalSlider, GUILayout.MaxHeight(6)); EditorGUILayout.Space();

            }
            GUILayout.Label("Extras", AURW_Title);
            EditorGUILayout.Space();
            EditorGUILayout.BeginVertical(BoxPanel);
            if (GUILayout.Button("Visit Our Web Site")) Application.OpenURL("https://sites.google.com/view/abkaspogames");
            EditorGUILayout.EndVertical();
        }
    }
}