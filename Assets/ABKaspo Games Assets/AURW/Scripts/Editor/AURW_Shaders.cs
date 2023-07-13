using UnityEngine;
using UnityEditor;

namespace ABKaspo.Assets.AURW.ShaderEditor
{

    public class WaterPro : ShaderGUI
    {
        #region New Styles
        GUIStyle AURW_Title;
        GUIStyle AURW_Header1;
        GUIStyle AURW_Header;
        GUIStyle BoxPanel;
        Texture2D BoxPanelColor;
        #endregion
        public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            Material targetMat = materialEditor.target as Material;
            #region Variables
            Color colorA = targetMat.GetColor("_Color_A");
            #endregion
            #region New Styles Settings
            AURW_Title = AURW_Title != null ? AURW_Title : new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter, richText = true, fontSize = 16 };
            AURW_Header = AURW_Header != null ? AURW_Header : new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleLeft, fontStyle = FontStyle.Bold, fontSize = 14 };
            AURW_Header1 = AURW_Header1 != null ? AURW_Header1 : new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter, fontStyle = FontStyle.Bold, richText = true, fontSize = 14 };
            BoxPanel = BoxPanel != null ? BoxPanel : new GUIStyle(GUI.skin.box) { normal = { background = BoxPanelColor } };
            #endregion
            EditorGUILayout.LabelField("Water Pro", AURW_Title);
            /*EditorGUILayout.LabelField("Surface Options", AURW_Header);
            EditorGUILayout.Space();
            EditorGUILayout.ColorField(new GUIContent("Color A :"), colorA, true ,true, true);
            EditorGUILayout.ColorField(new GUIContent("Color B :"), new Color(), true ,true, true);
            EditorGUILayout.ColorField(new GUIContent("Color C :"), targetMat.GetColor("_Color_C"), true ,true, true);
            EditorGUILayout.ColorField(("Color D :"), targetMat.GetColor("_Color_D"));
            EditorGUILayout.FloatField("Fresnel Power :", targetMat.GetFloat("_Fresnel_Power"));*/
            base.OnGUI(materialEditor, properties);

        }
    }
    public class PhysicalyWavesWater : ShaderGUI
    {
        #region New Styles
        GUIStyle AURW_Title;
        GUIStyle AURW_Header1;
        GUIStyle AURW_Header;
        GUIStyle BoxPanel;
        Texture2D BoxPanelColor;
        #endregion
         public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
         {
             #region New Styles Settings
             AURW_Title = AURW_Title != null ? AURW_Title : new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter, richText = true, fontSize = 16 };
             AURW_Header = AURW_Header != null ? AURW_Header : new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleLeft, fontStyle = FontStyle.Bold, fontSize = 14 };
             AURW_Header1 = AURW_Header1 != null ? AURW_Header1 : new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter, fontStyle = FontStyle.Bold, richText = true, fontSize = 14 };
             BoxPanel = BoxPanel != null ? BoxPanel : new GUIStyle(GUI.skin.box) { normal = { background = BoxPanelColor } };
            #endregion
            EditorGUILayout.LabelField("A.U.R.W. Gestern Wave", AURW_Title);
            base.OnGUI(materialEditor, properties);
         }
    }
}