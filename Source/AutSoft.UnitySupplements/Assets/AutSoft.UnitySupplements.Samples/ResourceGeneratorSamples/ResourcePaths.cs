//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.SceneManagement;

namespace AutSoft.UnitySupplements.Samples.ResourceGeneratorSamples
{
    public static partial class ResourcePaths
    {
        public static partial class Scenes
        {

            public const string TimelineSample = "AutSoft.UnitySupplements.Samples/TimelineSamples/TimelineSample";
            public static void LoadTimelineSample(LoadSceneMode mode = LoadSceneMode.Single) => SceneManager.LoadScene(TimelineSample, mode);
            public static AsyncOperation LoadAsyncTimelineSample(LoadSceneMode mode = LoadSceneMode.Single) => SceneManager.LoadSceneAsync(TimelineSample, mode);

            public const string CreatePrefab = "AutSoft.UnitySupplements.Samples/ResourceGeneratorSamples/Scenes/CreatePrefab";
            public static void LoadCreatePrefab(LoadSceneMode mode = LoadSceneMode.Single) => SceneManager.LoadScene(CreatePrefab, mode);
            public static AsyncOperation LoadAsyncCreatePrefab(LoadSceneMode mode = LoadSceneMode.Single) => SceneManager.LoadSceneAsync(CreatePrefab, mode);

            public const string LoadSceneInitial = "AutSoft.UnitySupplements.Samples/ResourceGeneratorSamples/Scenes/LoadSceneInitial";
            public static void LoadLoadSceneInitial(LoadSceneMode mode = LoadSceneMode.Single) => SceneManager.LoadScene(LoadSceneInitial, mode);
            public static AsyncOperation LoadAsyncLoadSceneInitial(LoadSceneMode mode = LoadSceneMode.Single) => SceneManager.LoadSceneAsync(LoadSceneInitial, mode);

            public const string LoadSceneNext = "AutSoft.UnitySupplements.Samples/ResourceGeneratorSamples/Scenes/LoadSceneNext";
            public static void LoadLoadSceneNext(LoadSceneMode mode = LoadSceneMode.Single) => SceneManager.LoadScene(LoadSceneNext, mode);
            public static AsyncOperation LoadAsyncLoadSceneNext(LoadSceneMode mode = LoadSceneMode.Single) => SceneManager.LoadSceneAsync(LoadSceneNext, mode);

            public const string BillboardTest = "AutSoft.UnitySupplements.Samples/VitaminsSamples/Scenes/BillboardTest";
            public static void LoadBillboardTest(LoadSceneMode mode = LoadSceneMode.Single) => SceneManager.LoadScene(BillboardTest, mode);
            public static AsyncOperation LoadAsyncBillboardTest(LoadSceneMode mode = LoadSceneMode.Single) => SceneManager.LoadSceneAsync(BillboardTest, mode);

            public const string Binding = "AutSoft.UnitySupplements.Samples/VitaminsSamples/Scenes/Binding";
            public static void LoadBinding(LoadSceneMode mode = LoadSceneMode.Single) => SceneManager.LoadScene(Binding, mode);
            public static AsyncOperation LoadAsyncBinding(LoadSceneMode mode = LoadSceneMode.Single) => SceneManager.LoadSceneAsync(Binding, mode);

            public const string GeneratePolygon = "AutSoft.UnitySupplements.Samples/VitaminsSamples/Scenes/GeneratePolygon";
            public static void LoadGeneratePolygon(LoadSceneMode mode = LoadSceneMode.Single) => SceneManager.LoadScene(GeneratePolygon, mode);
            public static AsyncOperation LoadAsyncGeneratePolygon(LoadSceneMode mode = LoadSceneMode.Single) => SceneManager.LoadSceneAsync(GeneratePolygon, mode);

        }

        public static partial class Prefabs
        {

            public const string Cube = "Cube";
            public static GameObject LoadCube() => Resources.Load<GameObject>(Cube);

        }

        public static partial class Materials
        {

            public const string Cube = "Cube";
            public static Material LoadCube() => Resources.Load<Material>(Cube);

            public const string CubeAlt = "CubeAlt";
            public static Material LoadCubeAlt() => Resources.Load<Material>(CubeAlt);

            public const string LiberationSansSDF_DropShadow = "Fonts & Materials/LiberationSans SDF - Drop Shadow";
            public static Material LoadLiberationSansSDF_DropShadow() => Resources.Load<Material>(LiberationSansSDF_DropShadow);

            public const string LiberationSansSDF_Outline = "Fonts & Materials/LiberationSans SDF - Outline";
            public static Material LoadLiberationSansSDF_Outline() => Resources.Load<Material>(LiberationSansSDF_Outline);

        }

        public static partial class AudioClips
        {

            public const string CoinSpin = "Coin Spin";
            public static AudioClip LoadCoinSpin() => Resources.Load<AudioClip>(CoinSpin);

            public const string Coin1 = "Coin 1";
            public static AudioClip LoadCoin1() => Resources.Load<AudioClip>(Coin1);

            public const string Coin = "Coin";
            public static AudioClip LoadCoin() => Resources.Load<AudioClip>(Coin);

        }

        public static partial class TextAssets
        {

            public const string LineBreakingFollowingCharacters = "LineBreaking Following Characters";
            public static TextAsset LoadLineBreakingFollowingCharacters() => Resources.Load<TextAsset>(LineBreakingFollowingCharacters);

            public const string LineBreakingLeadingCharacters = "LineBreaking Leading Characters";
            public static TextAsset LoadLineBreakingLeadingCharacters() => Resources.Load<TextAsset>(LineBreakingLeadingCharacters);

            public const string AppSettings = "AppSettings";
            public static TextAsset LoadAppSettings() => Resources.Load<TextAsset>(AppSettings);

        }

#if UNITY_EDITOR
        public static partial class KnownEditorPrefs
        {

            public static partial class Android
            {

                public static string JdkUseEmbedded { get; } = "JdkUseEmbedded";
                public static bool GetJdkUseEmbedded() => UnityEditor.EditorPrefs.GetBool(JdkUseEmbedded);
                public static void SetJdkUseEmbedded(bool value) => UnityEditor.EditorPrefs.SetBool(JdkUseEmbedded, value);
                public static void DeleteJdkUseEmbedded() => UnityEditor.EditorPrefs.DeleteKey(JdkUseEmbedded);

                public static string SdkUseEmbedded { get; } = "SdkUseEmbedded";
                public static bool GetSdkUseEmbedded() => UnityEditor.EditorPrefs.GetBool(SdkUseEmbedded);
                public static void SetSdkUseEmbedded(bool value) => UnityEditor.EditorPrefs.SetBool(SdkUseEmbedded, value);
                public static void DeleteSdkUseEmbedded() => UnityEditor.EditorPrefs.DeleteKey(SdkUseEmbedded);

                public static string NdkUseEmbedded { get; } = "NdkUseEmbedded";
                public static bool GetNdkUseEmbedded() => UnityEditor.EditorPrefs.GetBool(NdkUseEmbedded);
                public static void SetNdkUseEmbedded(bool value) => UnityEditor.EditorPrefs.SetBool(NdkUseEmbedded, value);
                public static void DeleteNdkUseEmbedded() => UnityEditor.EditorPrefs.DeleteKey(NdkUseEmbedded);

                public static string GradleUseEmbedded { get; } = "GradleUseEmbedded";
                public static bool GetGradleUseEmbedded() => UnityEditor.EditorPrefs.GetBool(GradleUseEmbedded);
                public static void SetGradleUseEmbedded(bool value) => UnityEditor.EditorPrefs.SetBool(GradleUseEmbedded, value);
                public static void DeleteGradleUseEmbedded() => UnityEditor.EditorPrefs.DeleteKey(GradleUseEmbedded);

                public static string JdkPath { get; } = "JdkPath";
                public static string GetJdkPath() => UnityEditor.EditorPrefs.GetString(JdkPath);
                public static void SetJdkPath(string value) => UnityEditor.EditorPrefs.SetString(JdkPath, value);
                public static void DeleteJdkPath() => UnityEditor.EditorPrefs.DeleteKey(JdkPath);

                public static string AndroidSdkRoot { get; } = "AndroidSdkRoot";
                public static string GetAndroidSdkRoot() => UnityEditor.EditorPrefs.GetString(AndroidSdkRoot);
                public static void SetAndroidSdkRoot(string value) => UnityEditor.EditorPrefs.SetString(AndroidSdkRoot, value);
                public static void DeleteAndroidSdkRoot() => UnityEditor.EditorPrefs.DeleteKey(AndroidSdkRoot);

                public static string AndroidNdkRootR21D { get; } = "AndroidNdkRootR21D";
                public static string GetAndroidNdkRootR21D() => UnityEditor.EditorPrefs.GetString(AndroidNdkRootR21D);
                public static void SetAndroidNdkRootR21D(string value) => UnityEditor.EditorPrefs.SetString(AndroidNdkRootR21D, value);
                public static void DeleteAndroidNdkRootR21D() => UnityEditor.EditorPrefs.DeleteKey(AndroidNdkRootR21D);

                public static string GradlePath { get; } = "GradlePath";
                public static string GetGradlePath() => UnityEditor.EditorPrefs.GetString(GradlePath);
                public static void SetGradlePath(string value) => UnityEditor.EditorPrefs.SetString(GradlePath, value);
                public static void DeleteGradlePath() => UnityEditor.EditorPrefs.DeleteKey(GradlePath);

            }

            public static partial class CodeEditor
            {

                public static string kScriptsDefaultApp { get; } = "kScriptsDefaultApp";
                public static string GetkScriptsDefaultApp() => UnityEditor.EditorPrefs.GetString(kScriptsDefaultApp);
                public static void SetkScriptsDefaultApp(string value) => UnityEditor.EditorPrefs.SetString(kScriptsDefaultApp, value);
                public static void DeletekScriptsDefaultApp() => UnityEditor.EditorPrefs.DeleteKey(kScriptsDefaultApp);

                public static string unity_project_generation_flag { get; } = "unity_project_generation_flag";
                public static int Getunity_project_generation_flag() => UnityEditor.EditorPrefs.GetInt(unity_project_generation_flag);
                public static void Setunity_project_generation_flag(int value) => UnityEditor.EditorPrefs.SetInt(unity_project_generation_flag, value);
                public static void Deleteunity_project_generation_flag() => UnityEditor.EditorPrefs.DeleteKey(unity_project_generation_flag);

            }

        }
#endif

        public static partial class Layers
        {

            public const string Default = "Default";
            public static int GetDefaultIndex() => LayerMask.NameToLayer(Default);
            public static int GetDefaultMask() => LayerMask.GetMask(Default);
            public const string TransparentFX = "TransparentFX";
            public static int GetTransparentFXIndex() => LayerMask.NameToLayer(TransparentFX);
            public static int GetTransparentFXMask() => LayerMask.GetMask(TransparentFX);
            public const string IgnoreRaycast = "Ignore Raycast";
            public static int GetIgnoreRaycastIndex() => LayerMask.NameToLayer(IgnoreRaycast);
            public static int GetIgnoreRaycastMask() => LayerMask.GetMask(IgnoreRaycast);
            public const string Water = "Water";
            public static int GetWaterIndex() => LayerMask.NameToLayer(Water);
            public static int GetWaterMask() => LayerMask.GetMask(Water);
            public const string UI = "UI";
            public static int GetUIIndex() => LayerMask.NameToLayer(UI);
            public static int GetUIMask() => LayerMask.GetMask(UI);
        }

#if UNITY_EDITOR
        public static partial class LoadSceneButtons
        {

            [UnityEditor.MenuItem("Load Scene / TimelineSample")]
            public static void LoadTimelineSample()
            {
                UnityEditor.SceneManagement.EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
                UnityEditor.SceneManagement.EditorSceneManager.OpenScene(@"Assets\AutSoft.UnitySupplements.Samples\TimelineSamples\TimelineSample.unity");
            }
            [UnityEditor.MenuItem("Load Scene / CreatePrefab")]
            public static void LoadCreatePrefab()
            {
                UnityEditor.SceneManagement.EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
                UnityEditor.SceneManagement.EditorSceneManager.OpenScene(@"Assets\AutSoft.UnitySupplements.Samples\ResourceGeneratorSamples\Scenes\CreatePrefab.unity");
            }
            [UnityEditor.MenuItem("Load Scene / LoadSceneInitial")]
            public static void LoadLoadSceneInitial()
            {
                UnityEditor.SceneManagement.EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
                UnityEditor.SceneManagement.EditorSceneManager.OpenScene(@"Assets\AutSoft.UnitySupplements.Samples\ResourceGeneratorSamples\Scenes\LoadSceneInitial.unity");
            }
            [UnityEditor.MenuItem("Load Scene / LoadSceneNext")]
            public static void LoadLoadSceneNext()
            {
                UnityEditor.SceneManagement.EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
                UnityEditor.SceneManagement.EditorSceneManager.OpenScene(@"Assets\AutSoft.UnitySupplements.Samples\ResourceGeneratorSamples\Scenes\LoadSceneNext.unity");
            }
            [UnityEditor.MenuItem("Load Scene / BillboardTest")]
            public static void LoadBillboardTest()
            {
                UnityEditor.SceneManagement.EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
                UnityEditor.SceneManagement.EditorSceneManager.OpenScene(@"Assets\AutSoft.UnitySupplements.Samples\VitaminsSamples\Scenes\BillboardTest.unity");
            }
            [UnityEditor.MenuItem("Load Scene / Binding")]
            public static void LoadBinding()
            {
                UnityEditor.SceneManagement.EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
                UnityEditor.SceneManagement.EditorSceneManager.OpenScene(@"Assets\AutSoft.UnitySupplements.Samples\VitaminsSamples\Scenes\Binding.unity");
            }
            [UnityEditor.MenuItem("Load Scene / GeneratePolygon")]
            public static void LoadGeneratePolygon()
            {
                UnityEditor.SceneManagement.EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
                UnityEditor.SceneManagement.EditorSceneManager.OpenScene(@"Assets\AutSoft.UnitySupplements.Samples\VitaminsSamples\Scenes\GeneratePolygon.unity");
            }

            [UnityEditor.MenuItem("Play Scene / TimelineSample")]
            public static void PlayTimelineSample()
            {
                if (UnityEditor.EditorApplication.isPlaying)
                {
                    UnityEditor.EditorApplication.isPlaying = false;
                    return;
                }

                UnityEditor.SceneManagement.EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
                UnityEditor.SceneManagement.EditorSceneManager.OpenScene(@"Assets\AutSoft.UnitySupplements.Samples\TimelineSamples\TimelineSample.unity");
                UnityEditor.EditorApplication.isPlaying = true;
            }
        }
#endif

    }
}