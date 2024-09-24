using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class ABManager : SingletonAutoMono<ABManager>
{
    private AssetBundle mainAB = null;
    private AssetBundleManifest manifest = null;

    private Dictionary<string, AssetBundle> abDict = new Dictionary<string, AssetBundle>();

    /// <summary>
    /// AB包路径
    /// </summary>
    private string PathUrl
    {
        get
        {
            return Application.streamingAssetsPath + "/";
        }
    }

    /// <summary>
    /// 不同平台主包名
    /// </summary>
    private string MainABName
    {
        get
        {
#if UNITY_IOS
                return "IOS";
#elif UNITY_ANDROID
                return "Android";
#else
            return "PC";
#endif
        }
    }


    /// <summary>
    /// 同步加载AB包
    /// </summary>
    /// <param name="abName"></param>
    /// <returns></returns>
    private AssetBundle LoadLoadAssetBundle(string abName)
    {
        if (mainAB == null)
        {
            mainAB = AssetBundle.LoadFromFile(PathUrl + MainABName);
            manifest = mainAB.LoadAsset("AssetBundleManifest", typeof(AssetBundleManifest)) as AssetBundleManifest;
        }
        string[] dependencies = manifest.GetAllDependencies(abName);
        foreach (string dependency in dependencies)
        {
            if (!abDict.ContainsKey(dependency))
                abDict.Add(dependency, AssetBundle.LoadFromFile(Path.Combine(PathUrl, dependency)));
        }
        if (!abDict.ContainsKey(abName))
            abDict.Add(abName, AssetBundle.LoadFromFile(Path.Combine(PathUrl, abName)));
        return abDict[abName];
    }

    /// <summary>
    /// 同步加载AB包资源
    /// </summary>
    /// <param name="abName"></param>
    /// <param name="resName"></param>
    /// <returns></returns>
    public Object LoadAsset(string abName, string resName)
    {
        AssetBundle assetBundle = LoadLoadAssetBundle(abName);

        return assetBundle.LoadAsset(resName);
    }
    /// <summary>
    /// 同步加载AB包资源
    /// </summary>
    /// <param name="abName"></param>
    /// <param name="assetName"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public Object LoadAsset(string abName, string assetName, System.Type type)
    {
        AssetBundle assetBundle = LoadLoadAssetBundle(abName);
        return assetBundle.LoadAsset(assetName, type);
    }
    /// <summary>
    /// 同步加载AB包资源
    /// </summary>
    /// <param name="abName"></param>
    /// <param name="resName"></param>
    /// <returns></returns>
    public T LoadAsset<T>(string abName, string resName) where T : Object
    {
        AssetBundle assetBundle = LoadLoadAssetBundle(abName);

        return assetBundle.LoadAsset<T>(resName);
    }

    /// <summary>
    /// 异步加载AB包资源
    /// </summary>
    /// <param name="abName"></param>
    /// <param name="AssetName"></param>
    /// <param name="CallBack"></param>
    public void LoadAssetAsync(string abName, string AssetName, UnityAction<Object> CallBack)
    {
        StartCoroutine(LoadAssetRoutine(abName, AssetName, CallBack));
    }
    IEnumerator LoadAssetRoutine(string abName, string resName, UnityAction<Object> CallBack)
    {
        AssetBundle assetBundle = LoadLoadAssetBundle(abName);
        AssetBundleRequest assetBundleRequest = assetBundle.LoadAssetAsync(resName);
        yield return assetBundleRequest;
        CallBack(assetBundleRequest.asset);
    }
    /// <summary>
    /// 异步加载AB包资源
    /// </summary>
    /// <param name="abName"></param>
    /// <param name="assetName"></param>
    /// <param name="type"></param>
    /// <param name="CallBack"></param>
    public void LoadAssetAsync(string abName, string assetName, System.Type type, UnityAction<Object> CallBack)
    {
        StartCoroutine(LoadAssetRoutine(abName, assetName, type, CallBack));
    }
    IEnumerator LoadAssetRoutine(string abName, string assetName, System.Type type, UnityAction<Object> CallBack)
    {
        AssetBundle assetBundle = LoadLoadAssetBundle(abName);
        AssetBundleRequest assetBundleRequest = assetBundle.LoadAssetAsync(assetName, type);
        yield return assetBundleRequest;
        CallBack(assetBundleRequest.asset);
    }
    /// <summary>
    /// 异步加载AB包资源
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="abName"></param>
    /// <param name="assetName"></param>
    /// <param name="CallBack"></param>
    public void LoadAssetAsync<T>(string abName, string assetName, UnityAction<T> CallBack) where T : Object
    {
        StartCoroutine(LoadAssetRoutine(abName, assetName, CallBack));
    }
    IEnumerator LoadAssetRoutine<T>(string abName, string assetName, UnityAction<T> CallBack) where T : Object
    {
        AssetBundle assetBundle = LoadLoadAssetBundle(abName);
        AssetBundleRequest assetBundleRequest = assetBundle.LoadAssetAsync<T>(assetName);
        yield return assetBundleRequest;
        CallBack(assetBundleRequest.asset as T);
    }

    public void UnLoadAB(string abName)
    {
        if (abDict.ContainsKey(abName))
        {
            abDict[abName].Unload(false);
            abDict.Remove(abName);
        }
    }

    public void UnLoadAllAB()
    {
        AssetBundle.UnloadAllAssetBundles(false);
        mainAB = null;
        manifest = null;
    }
}
