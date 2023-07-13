using UnityEngine;
using UnityEditor;
namespace ABKaspo.Assets.AURW.Checker
{
    [ExecuteInEditMode]
    public class AURW_Checker : MonoBehaviour
    {
        // This script keep this gameObject in (0,0,0) to a better organitation.
        // Please don't modify AURW, Ocean_Manager and AURW_Checker
        void Start()
        {
            transform.position = new Vector3(0, 0, 0);
        }
        void Update()
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
}
namespace ABKaspo.Assets.AURW.ScriptEditor
{
    [CustomEditor(typeof(AURW.Checker.AURW_Checker))]
    public class Editor_AURW_Checker : Editor
    {
        public override void OnInspectorGUI()
        {

        }
    }
}