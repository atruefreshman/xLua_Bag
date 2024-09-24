using UnityEngine;

public class Main : MonoBehaviour
{
    /// <summary>
    /// hello
    /// </summary>
    private void Awake()
    {
        
        LuaManager.Instance.DoString("require('Main')");

        
    }
}
