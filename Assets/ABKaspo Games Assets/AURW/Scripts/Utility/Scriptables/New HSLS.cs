using UnityEditor;
using UnityEngine;
using System.IO;
namespace ABKaspo.Assets.AURW.Utility
{
    public class NewHLSL : EditorWindow
    {
        [MenuItem("Assets/Create/ABKaspo/AURW/Utility/Shader/HLSL")]
        public static void CreateAsset()
        {
            string functionName = "Custom Function HLSL: MyFunction";
            if (string.IsNullOrEmpty(functionName))
            {
                return;
            }
            string defSymbolName = functionName.ToUpper() + Random.Range(0, 9999999) + "_INCLUDED";
            string filecontent =
@"//UNITY_SHADER_NO_UPGRADE
#ifndef " + defSymbolName + @"
#define " + defSymbolName + @"
 
void " + functionName + @"_float(in float2 uv, in UnityTexture2D tex, in UnitySamplerState tex_sampler, out float4 color)
{
   color = SAMPLE_TEXTURE2D(tex, tex_sampler, uv);
}
 
#endif //" + defSymbolName;

            ProjectWindowUtil.CreateAssetWithContent(
            "New HLSL.hlsl",
            filecontent);
        }
    }
}