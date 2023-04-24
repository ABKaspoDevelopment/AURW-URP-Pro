using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace ABKaspo.Assets.AURW.AURW_Editor {
    public class AURW_MenuBarEditor : EditorWindow
    {
        [MenuItem("ABKaspo/About/A.U.R.W. Version")]
        public static void ShowAURWVersion()
        {
            AURW_MenuBarEditor window = (AURW_MenuBarEditor)EditorWindow.GetWindow(typeof(AURW_MenuBarEditor));
            window.titleContent.text = "A.U.R.W. Version";
            window.GetType();
            window.Show();
            
        }
        [MenuItem("ABKaspo/About/Contact Us/YouTube Channel")]
        public static void OpenYoutubeChannel()
        {
            Application.OpenURL("https://www.youtube.com/@ABKaspo-Games");
        }
        [MenuItem("ABKaspo/About/Contact Us/Instagram")]
        public static void OpenInstagramAccount()
        {
            Application.OpenURL("https://www.instagram.com/abkaspo_games");
        }
        [MenuItem("ABKaspo/About/Contact Us/Send An E-mail")]
        public static void SendAnEmail()
        {
            Application.OpenURL("mailto:abkaspo@gmail.com");
        }
        string currentAURWVersion;
        string lastAURWVersion;
        private void OnGUI()
        {
            GUILayout.Label("About A.U.R.W.", EditorStyles.boldLabel);
            GUILayout.Label("Your Current AURW Version is :" + currentAURWVersion);
            GUILayout.Label("Last AURW Version is :" + lastAURWVersion);

        }
    }
}