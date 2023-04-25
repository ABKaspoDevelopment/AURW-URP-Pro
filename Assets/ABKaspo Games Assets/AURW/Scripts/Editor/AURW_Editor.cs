using UnityEngine;
using UnityEditor;
namespace ABKaspo.Assets.AURW.Ocean
{
    [CustomEditor(typeof(OceanManager)), ExecuteInEditMode]
    public class AURW_Editor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Generate Ocean"))
            {
                // On button push
                // search GameObject with name "Ocean" then cancell action
                // if "Ocean" Does't exists let's search "AURW Manager"
                //      if it doesn't exitst create one and add OceanManagerToIt
                // Create ocean if all of mentioned events are true
                if (GameObject.Find("Ocean"))
                {
                    EditorUtility.DisplayDialog("AURW Manager", "AURW found an ocean, you mustn't create twice oceans!", "I Understand");
                    return;
                }
                if (GameObject.Find("AURW Manager") == null)
                {
                    EditorUtility.DisplayDialog("AURW Manager", "AURW cloudn't find one, Do you want create one?", "Ok");
                    GameObject oceanManager = new GameObject("AURW Manager");
                    oceanManager.AddComponent<OceanChecker>();
                    oceanManager.AddComponent<OceanManager>();
                    GameObject.DestroyImmediate(OceanManager.thisGameObject);

                    if (GameObject.Find("AURW Manager") == null)
                    {
                        Debug.LogError("Adding Ocean Object failed!");
                        return;
                    }
                    else
                    {
                        Debug.Log("AURW Manager added!");
                    }
                    return;
                }
                /*if (GameObject.Find("Reflection Camera") == null)
                {
                    EditorUtility.DisplayDialog("No Reflection Camera Found", "AURW cloudnt find one, Creating one...", "Ok");
                    GameObject reflectionCamera = new GameObject("Reflection Camera");
                    reflectionCamera.AddComponent<Camera>();
                    reflectionCamera.transform.parent = GameObject.Find("Ocean Manager").transform;
                    if (GameObject.Find("Reflection Camera") == null)
                    {
                        Debug.LogError("Adding Reflection Camera failed!");
                        return;
                    }
                    else
                    {
                        Debug.Log("Reflection Camera added!");
                    }
                    Debug.LogWarning("AURW Manager: Now you should set the render texture to a correct reflection");    
                }*/

                GameObject Ocean = new GameObject("AURW Manager");
                Ocean.name = "Ocean";
                Ocean.AddComponent<MeshFilter>().mesh = OceanManager.waterMesh;
                Ocean.AddComponent<MeshRenderer>().material = OceanManager.___oceanMat;
                Ocean.transform.parent = GameObject.Find("AURW Manager").transform;
                Ocean.transform.position = OceanManager.__Position;
                Ocean.transform.localScale = OceanManager.___Scale;
                Ocean.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            }
            if (GUILayout.Button("Delete Ocean"))
            {

                if (GameObject.Find("AURW Manager") == null)
                {
                    EditorUtility.DisplayDialog("AURW Manager", "AURW Manager's GameObject must have name as AURW Manager", "OK");
                }
                if (GameObject.Find("AURW Manager"))
                {
                    if (GameObject.Find("Ocean") == null)
                    {
                        EditorUtility.DisplayDialog("AURW Manager", "AURW Manager cloudn't find a GameObject with Ocean as name", "OK");
                        return;
                    }
                    GameObject GameObjectToDelete = GameObject.Find("Ocean");
                    GameObject.DestroyImmediate(GameObjectToDelete);
                }
            }
        }
    }
}