using System.IO;
using UnityEngine;
using XLua;

public class LuaManager
{
    private static LuaManager instance;
    public static LuaManager Instance
    {
        get
        {
            if (instance == null)
                instance = new LuaManager();
            instance.Init();
            return instance;
        }
    }
    public void Init()
    {
        if (luaEnv != null)
            return;

        luaEnv = new LuaEnv();
        luaEnv.AddLoader(CustomLoaderLocal);
        luaEnv.AddLoader(CustomLoaderAssetBundle);
    }

    private LuaEnv luaEnv;
    public LuaTable Global => luaEnv.Global;

    /// <summary>
    /// Lua闂備浇娉曢崰鏇㈠礈婵傜ǹ绠熼悗锝庡亜椤忓爼姊虹捄銊ユ瀾闁哄顭烽獮蹇涙倻閼恒儲娅㈤梺鍝勫€堕崐鏍偓姘秺閺屻劑鎮㈢粙璺ㄥ姷闁荤姳娴囬～澶屸偓姘秺閺屻劑鎮㈤崨濠勪紕闂佺懓鍤栭幏锟�
    /// </summary>
    /// <param name="filepath"></param>
    /// <returns></returns>
    private byte[] CustomLoaderLocal(ref string filepath)
    {
        string path = Application.dataPath + "/Scripts/Lua/" + filepath + ".lua";

        if (File.Exists(path))
            return File.ReadAllBytes(path);

        Debug.LogWarning("Lua閺傚洣娆㈡径閫涚瑓娑撳秴鐡ㄩ崷鈫檜a閼存碍婀�: " + filepath);

        return null;
    }
    /// <summary>
    /// Lua闂備浇娉曢崰鏇㈠礈婵傜ǹ绠熼悗锝庡亜椤忓爼姊虹捄銊ユ瀾闁哄顭烽獮蹇涙倻閼恒儲娅㈤梺鍝勫€堕崐鏍偓姘秺閺屻劑鎮㈢粙璺ㄥ姷闁荤姳娴囬～澶屸偓姘秺閺屻劑鎮㈤崨濠勪紕闂佺懓鍤栭幏锟�
    /// </summary>
    /// <param name="filepath"></param>
    /// <returns></returns>
    private byte[] CustomLoaderAssetBundle(ref string filepath)
    {
        TextAsset luaText = ABManager.Instance.LoadAsset<TextAsset>("lua", filepath + ".lua");

        if(luaText!=null)
            return luaText.bytes;

        Debug.LogWarning("AB閸栧懍绗夌€涙ê婀狶ua閼存碍婀�: " + filepath);

        return null;
    }

    /// <summary>
    /// 濞戞捁妗ㄧ划鍫熺▕閸喐笑濞戞棁浜悥婊堟晬閻旂厧绠ョ憸鏃堝极閹捐鐭楁い鎰╁劚婢规牠鏌熼幓鎺濆剱閻庢熬鎷�/闂備浇娉曢崰鎰板几婵犳艾绠柣鎴ｅГ閺呮悂鏌ㄩ悤鍌涘
    /// </summary>
    /// <param name="chunk"></param>
    /// <param name="chunkName"></param>
    /// <param name="env"></param>
    public void DoString(string chunk, string chunkName = "chunk", LuaTable env = null)
    {
        luaEnv.DoString(chunk, chunkName, env);
    }

    /// <summary>
    /// 闂備浇娉曢崰鎰板几婵犳艾绠柣鎴ｅГ閺呮悂鏌￠崒妯衡偓鏍偓姘秺閺屻劑鎮㈤崨濠勪紕闂佸綊顥撻崗姗€寮幘璇叉闁靛牆妫楅锟�
    /// </summary>
    public void Tick()
    {
        luaEnv.Tick();
    }

    /// <summary>
    /// 闂備浇娉曢崰鎰板几婵犳艾绠柣鎴ｅГ閺呮悂鏌￠崒妯衡偓鏍偓姘辩搲ua闂備浇娉曢崰鎰板几婵犳艾绠柣鎴ｅГ閺呮悂鏌￠崒妯衡偓鏍偓姘秺閺屻劑鎮㈤崨濠勪紕闂佺懓鍤栭幏锟�
    /// </summary>
    public void Dispose()
    {
        luaEnv.Dispose();
        luaEnv = null;
    }
    /// <summary>
    /// 闂備浇娉曢崰鎰板几婵犳艾绠柣鎴ｅГ閺呮悂鏌￠崒妯衡偓鏍偓姘辩搲ua闂備浇娉曢崰鎰板几婵犳艾绠柣鎴ｅГ閺呮悂鏌￠崒妯衡偓鏍偓姘秺閺屻劑鎮㈤崨濠勪紕闂佺懓鍤栭幏锟�
    /// </summary>
    public void Dispose(bool dispose)
    {
        luaEnv.Dispose(dispose);
        luaEnv = null;
    }

}
