using UnityEngine;
using UnityEditor;
// Custom namespaces
using ABKaspo.Assets.AURW.EnumsScript;
public class AURW_MaterialEditor : EditorWindow
{
    public static AURW_MaterialEditor window;


    [MenuItem("ABKaspo/A.U.R.W./Material Editor")]
    public static void ShowWindow()
    {
        window = (AURW_MaterialEditor)EditorWindow.GetWindow(typeof(AURW_MaterialEditor));
        window.titleContent.text = "A.U.R.W. Material Editor";
    }
    MaterialType matType;
    #region New Styles
    GUIStyle AURW_Title;
    GUIStyle AURW_Header;
    GUIStyle AURW_Header1;
    GUIStyle AURW_Header2;
    GUIStyle BoxPanel;
    Texture2D BoxPanelColor;
    #endregion
    Vector2 scrollPos;
    string matName;
    #region MatGesternWave
    float Phase = 0.0f;
    float DepthWave = 9.0f;
    float gravity = 9.0f;
    Vector3 direction1 = new Vector3(0.05f, 0.0f, 0.07f);
    Vector3 direction2 = new Vector3(0.1f, 0.0f, 0.06f);
    Vector3 direction3 = new Vector3(0.01f, 0.0f, 0.06f);
    Vector3 direction4 = new Vector3(0.0f, 0.0f, -0.12f);
    float amplitude1 = 3.96f;
    float amplitude2 = 1.0f;
    float amplitude3 = 1.0f;
    float amplitude4 = 1.0f;
    Vector4 TimeScales = new Vector4(0.1f, 0.2f, 0.3f, 0.4f);
    #endregion
    #region Pro & Gestern
    Color colorA = new Vector4(0, 0.196f, 1, 0.8f);
    Color colorB = new Vector4(0, 0.631f, 1, 1);
    Color colorC = new Vector4(0.03137254f, 0.2137541f, 0.772549f, 1);
    Color colorD = new Vector4(0, 0.745283f, 0.6610448f, 1);
    float fresnel = 1;
    float smoothness = 0.9f;
    float refraction = 0.02f;

    Texture2D foamTexture;
    Color FoamColor = new Vector4(0.6415094f, 0.6415094f, 0.6415094f, 1);
    float Depth;
    float DepthStrength;

    Texture2D mainNormal;
    Texture2D secondNormal;
    Texture2D biggerNormal;
    Texture2D foamNormal;
    float normalStrength = 0.75f;

    float tilling = 1.0f;
    float speed = 1.0f;
    Vector2 directionA = new Vector2(1f, -1f);
    Vector2 directionB = new Vector2(-1f, 1f);
    float biggerSpeedDivider = 1.5f;
    float biggerTilling = 2f;

    bool KWaving;
    bool KRefraction = true;
    bool KUnderWater = true;
    #endregion
    string filename;
    private void OnEnable()
    {
        BoxPanelColor = new Texture2D(1, 1, TextureFormat.RGBAFloat, false); ;
        BoxPanelColor.SetPixel(0, 0, new Color(0f, 0f, 0f, 0.2f));
        BoxPanelColor.Apply();

    }
    private void OnGUI()
    {
       
        scrollPos = GUILayout.BeginScrollView(scrollPos, false, true);
        // Custom Style
        #region New Style Settings
        AURW_Title = AURW_Title != null ? AURW_Title : new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter, richText = true, fontSize = 16 };
        AURW_Header = AURW_Header != null ? AURW_Header : new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleLeft, fontStyle = FontStyle.Bold, fontSize = 14 };
        AURW_Header1 = AURW_Header1 != null ? AURW_Header1 : new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter, fontStyle = FontStyle.Bold, richText = true, fontSize = 14 };
        AURW_Header2 = AURW_Header2 != null ? AURW_Header2 : new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleLeft, fontStyle = FontStyle.Bold, richText = true, fontSize = 12 };
        BoxPanel = BoxPanel != null ? BoxPanel : new GUIStyle(GUI.skin.box) { normal = { background = BoxPanelColor } };
        #endregion
        EditorGUILayout.LabelField("A.U.R.W. - Material Editor", AURW_Title);
        EditorGUILayout.Space();
        EditorGUILayout.BeginVertical(BoxPanel);
        EditorGUILayout.LabelField("Settings :", AURW_Header1);
        matName = EditorGUILayout.TextField("Material Name :", matName);
        matType = (MaterialType)EditorGUILayout.EnumPopup("Select Material Type :", matType);
        EditorGUILayout.EndVertical();
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Material Propieties :", AURW_Header);
        if (matType == MaterialType.GesternWave)
        {
            Gestern();
            ProAndGesterAlbedo();
            Foam();
            Normal();
            tillingAndOffset();
            Setting();
        }
        if (matType == MaterialType.Pro)
        {
            ProAndGesterAlbedo();
            Foam();
            Normal();
            tillingAndOffset();
            Setting();
        }
        EditorGUILayout.Space();
        EditorGUILayout.BeginVertical(BoxPanel);
        EditorGUILayout.LabelField("Generate Material", AURW_Header);
        EditorGUILayout.LabelField("If you put the name like an existing mat, maybe there will be error generating material");
        if (GUILayout.Button("Generate Material"))
        {
            filename = "Assets/ABKaspo Games Assets/AURW/URP/Materials/" + matName + ".mat";
            TestMaterialCreator();
        }
        EditorGUILayout.EndVertical();
        // GUILayout.FlexibleSpace();
        EditorGUILayout.EndScrollView();
    }
    private void ProAndGesterAlbedo()
    {
        EditorGUILayout.Space();
        EditorGUILayout.BeginVertical(BoxPanel);
        EditorGUILayout.LabelField("Albedo", AURW_Header);
        colorA = EditorGUILayout.ColorField(new GUIContent("Color A :"), colorA, true, true, true);
        colorB = EditorGUILayout.ColorField(new GUIContent("Color B: "), colorB, true, true, true);
        colorC = EditorGUILayout.ColorField(new GUIContent("Color C :"), colorC, true, true, true);
        colorD = EditorGUILayout.ColorField("Color D :", colorD);
        fresnel = EditorGUILayout.FloatField("Fresnel Power :", fresnel);
        smoothness = EditorGUILayout.FloatField("Smoothness :", smoothness);
        refraction = EditorGUILayout.Slider("Refraction Strength", refraction, 0, 0.2f);
        EditorGUILayout.EndVertical();

    }
    void Gestern()
    {
        EditorGUILayout.BeginVertical(BoxPanel);
        EditorGUILayout.LabelField("Waves", AURW_Header);
        Phase = EditorGUILayout.FloatField("Phase :", Phase);
        DepthWave = EditorGUILayout.FloatField("Depth Wave :", DepthWave);
        gravity = EditorGUILayout.FloatField("Gravity :", gravity);
        direction1 = EditorGUILayout.Vector3Field("Direction 1 :", direction1);
        direction2 = EditorGUILayout.Vector3Field("Direction 2 :", direction2);
        direction3 = EditorGUILayout.Vector3Field("Direction 3 :", direction3);
        direction4 = EditorGUILayout.Vector3Field("Direction 4 :", direction4);
        amplitude1 = EditorGUILayout.FloatField("Amplitude 1 :", amplitude1);
        amplitude2 = EditorGUILayout.FloatField("Amplitude 2 :", amplitude2);
        amplitude3 = EditorGUILayout.FloatField("Amplitude 3 :", amplitude3);
        amplitude4 = EditorGUILayout.FloatField("Amplitude 4 :", amplitude4);
        EditorGUILayout.EndVertical();
    }
    void Foam()
    {
        EditorGUILayout.Space();
        EditorGUILayout.BeginVertical(BoxPanel);
        EditorGUILayout.LabelField("Foam", AURW_Header);
        foamTexture = (Texture2D)EditorGUILayout.ObjectField("Foam Texture :", foamTexture, typeof(Texture2D), false);
        FoamColor = EditorGUILayout.ColorField(new GUIContent("Foam Color :"), FoamColor, true, true, true);
        Depth = EditorGUILayout.FloatField("Depth :", Depth);
        DepthStrength = EditorGUILayout.Slider("Depth Strength :", DepthStrength, 0, 2);
        EditorGUILayout.EndVertical();
    }
    void Normal()
    {
        EditorGUILayout.Space();
        EditorGUILayout.BeginVertical(BoxPanel);
        EditorGUILayout.LabelField("Normal Mapping", AURW_Header);
        EditorGUILayout.BeginHorizontal();
        mainNormal = (Texture2D)EditorGUILayout.ObjectField("Main Normal :", mainNormal, typeof(Texture2D), false);
        secondNormal = (Texture2D)EditorGUILayout.ObjectField("Second Normal :", secondNormal, typeof(Texture2D), false);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        biggerNormal = (Texture2D)EditorGUILayout.ObjectField("Bigger Normal :", biggerNormal, typeof(Texture2D), false);
        foamNormal = (Texture2D)EditorGUILayout.ObjectField("Foam Normal :", foamNormal, typeof(Texture2D), false);
        EditorGUILayout.EndHorizontal();
        normalStrength = EditorGUILayout.FloatField("Normal Strength :", normalStrength);
        EditorGUILayout.EndVertical();
    }
    void tillingAndOffset()
    {
        EditorGUILayout.Space();
        EditorGUILayout.BeginVertical(BoxPanel);
        EditorGUILayout.LabelField("Tilling And Offset", AURW_Header);
        tilling = EditorGUILayout.FloatField("Tilling", tilling);
        speed = EditorGUILayout.FloatField("Speed", speed);
        directionA = EditorGUILayout.Vector2Field("Direction A", directionA);
        directionB = EditorGUILayout.Vector2Field("Direction B", directionB);
        biggerSpeedDivider = EditorGUILayout.FloatField("Bigger Speed Divider", biggerSpeedDivider);
        biggerTilling = EditorGUILayout.FloatField("Bigger Speed Divider", biggerTilling);
        EditorGUILayout.EndVertical();
    }
    void Setting()
    {
        EditorGUILayout.Space();
        EditorGUILayout.BeginVertical(BoxPanel);
        EditorGUILayout.LabelField("Settings", AURW_Header);
        KWaving = EditorGUILayout.Toggle("Waving", KWaving);
        KRefraction = EditorGUILayout.Toggle("Refraction", KRefraction);
        KUnderWater = EditorGUILayout.Toggle("Under Water", KUnderWater);
        EditorGUILayout.EndVertical();
    }

    string shaderPath;
    void TestMaterialCreator()
    {
        if (string.IsNullOrEmpty(matName))
        {
            EditorUtility.DisplayDialog("AURW - Material Editor", "You must set a material name", "Ok");
            return;
        }
        float _waving = KWaving ? 1f : 0f;
        float _refraction = KRefraction ? 1f : 0f;
        float _underwater = KUnderWater ? 1f : 0f;
        Material mat = new Material(Shader.Find(shaderPath));
        if (matType == MaterialType.GesternWave)
        {
            shaderPath = "ABKaspo/A.U.R.W./URP/Pro/Physicaly Based Waves";
            // Set colors
            mat.SetColor("_Color_A", colorA);
            mat.SetColor("_Color_B", colorB);
            mat.SetColor("_Color_C", colorC);
            mat.SetColor("_Color_D", colorD);
            mat.SetColor("_Foam_Color", FoamColor);
            // Set Textures
            mat.SetTexture("_Foam_Texture", foamTexture);
            mat.SetTexture("_Main_Normal", mainNormal);
            mat.SetTexture("_Second_Normal", secondNormal);
            mat.SetTexture("_Bigger_Normal", biggerNormal);
            mat.SetTexture("_Foam_Normal", foamNormal);
            // Set Float
            mat.SetFloat("_Phase", Phase);
            mat.SetFloat("_Depth_Wave", DepthWave);
            mat.SetFloat("_Gravity", gravity);
            mat.SetFloat("_Amplitude1", amplitude1);
            mat.SetFloat("_Amplitude2", amplitude2);
            mat.SetFloat("_Amplitude3", amplitude3);
            mat.SetFloat("_Amplitude4", amplitude4);
            mat.SetFloat("_Fresnel_Power", fresnel);
            mat.SetFloat("_Smoothness", smoothness);
            mat.SetFloat("_Refraction", refraction);
            mat.SetFloat("_Depth", Depth);
            mat.SetFloat("_Depth_Strength", DepthStrength);
            mat.SetFloat("_Normal_Strength", normalStrength);
            mat.SetFloat("_Tiling", tilling);
            mat.SetFloat("_Speed", speed);
            mat.SetFloat("_Bigger_Speed_Divider", biggerSpeedDivider);
            mat.SetFloat("_Bigger_Tiling", biggerTilling);
            // Set Vectors
            mat.SetVector("_Direction_A", directionA);
            mat.SetVector("_Direction_B", directionB);
            mat.SetVector("_Direction1", direction1);
            mat.SetVector("_Direction2", direction2);
            mat.SetVector("_Direction3", direction3);
            mat.SetVector("_Direction4", direction4);
            // Set Settings
            mat.SetFloat("_WAVING", _waving);
            mat.SetFloat("_REFRACTION", _refraction);
            mat.SetFloat("_UNDER_WATER", _underwater);

            mat = new Material(Shader.Find(shaderPath));
            AssetDatabase.CreateAsset(mat, filename);
            Debug.Log("Material Editor: new mat at " + filename);
        }
        if (matType == MaterialType.Pro)
        {
            shaderPath = "Shader Graphs/Water Pro";
            // Set colors
            mat.SetColor("_Color_A", colorA);
            mat.SetColor("_Color_B", colorB);
            mat.SetColor("_Color_C", colorC);
            mat.SetColor("_Color_D", colorD);
            mat.SetColor("_Foam_Color", FoamColor);
            // Set Textures
            mat.SetTexture("_Foam_Texture", foamTexture);
            mat.SetTexture("_Main_Normal", mainNormal);
            mat.SetTexture("_Second_Normal", secondNormal);
            mat.SetTexture("_Bigger_Normal", biggerNormal);
            mat.SetTexture("_Foam_Normal", foamNormal);
            // Set Float
            mat.SetFloat("_Fresnel_Power", fresnel);
            mat.SetFloat("_Smoothness", smoothness);
            mat.SetFloat("_Refraction", refraction);
            mat.SetFloat("_Depth", Depth);
            mat.SetFloat("_Depth_Strength", DepthStrength);
            mat.SetFloat("_Normal_Strength", normalStrength);
            mat.SetFloat("_Tiling", tilling);
            mat.SetFloat("_Speed", speed);
            mat.SetFloat("_Bigger_Speed_Divider", biggerSpeedDivider);
            mat.SetFloat("_Bigger_Tiling", biggerTilling);
            // Set Vectors
            mat.SetVector("_Direction_A", directionA);
            mat.SetVector("_Direction_B", directionB);
            // Set Settings
            mat.SetFloat("_WAVING", _waving);
            mat.SetFloat("_REFRACTION", _refraction);
            mat.SetFloat("_UNDER_WATER", _underwater);

            AssetDatabase.CreateAsset(mat, filename);
            Debug.Log("Material Editor: new mat at " + filename);
        }
    }
}