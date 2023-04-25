using UnityEngine;
#if !UNITY_2021_3_OR_NEWER
#error This Unity version isn't compatible with AURW. Please use Unity 2021.3 or newer!
#endif
using UnityEditor;
using ABKaspo.Scriptables;
namespace ABKaspo.Assets.AURW.Ocean
{
    public enum MeshType
    {
        BiggerWater = 0,
        SmallerWater = 1
    }
    public enum GenerationType
    {
        ByMesh = 0,
        SemiProcedural = 1,
        FullyProcedural = 2
    }
    [ExecuteAlways, RequireComponent(typeof(OceanChecker))]
    public class OceanManager : MonoBehaviour
    {
        #region Values      
        public Material oceanMat;
        public Camera _camera;
        public GameObject player;
        //  public Material SkyBox;
        public Vector3 Position;
        public Vector3 Scale = new Vector3(1, 1, 1);
        public MeshType meshType;
        public GenerationType generationType;
        public Meshes meshes;
#if AQUAS_2020_PRESENT
        public int resolutionMesh;
#endif
        public float underWater = 1.0f;
      //  [Header("Render Settings")]
      //  public float maxYCamFromRefraction = 15.0f;
        /* [Header("Reflection")]
         [SerializeField]private Camera reflectionCamera;
         [SerializeField] private RenderTexture reflection;
         [SerializeField] private int ReflectionResloution;
         Vector2 Resolution;*/
#endregion
#region Public Values
        public static Material ___oceanMat;
        public static Camera ____camera;
        public static GameObject _player;
        public static Material __SkyBox;
        public static Vector3 __Position;
        public static Vector3 ___Scale;
        public static Mesh waterMesh;
        public static GameObject thisGameObject;
        public static float _underWater;
        public static GenerationType ___generationType;
        public static MeshType __meshType;
        public static Meshes __meshes;
        public static int Meshresolution;
#endregion
        void Start()
        {
            if (_camera == null) _camera = Camera.main;
            thisGameObject = gameObject;
            //set static values 
            ___oceanMat = oceanMat;
            Meshresolution = resolutionMesh;
            __meshes = meshes;
            //__SkyBox = SkyBox;
            ___generationType = generationType;
            __meshType = meshType;
            __Position = Position;
            ___Scale = Scale;
            //
        }
        void Update()
        {
            ____camera = _camera;
            _player = player;
            _underWater = underWater;
            oceanMat.SetFloat("_Under_Water_Effect", underWater);
            if (meshType == MeshType.BiggerWater) waterMesh = meshes.biggerWater;
            if (meshType == MeshType.SmallerWater) waterMesh = meshes.smallerWater;
            // oceanMat.SetTexture("_Reflection", reflection);
            
        }
        void LateUpdate()
        {

        }
    }
}