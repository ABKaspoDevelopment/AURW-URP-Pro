using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class ColorEditor : EditorWindow
{
    [ColorUsage(true, true)] public Color colorA;
    public static ColorEditor window;
    [MenuItem("Window/HDR Color Editor")]
    public static void ShowWindow()
    {
        window = (ColorEditor)EditorWindow.GetWindow(typeof(ColorEditor));
        window.titleContent.text = "HDR Color Editor";
    }
    private void OnGUI()
    {
        colorA = EditorGUILayout.ColorField("Color A :", colorA);
    }
}
