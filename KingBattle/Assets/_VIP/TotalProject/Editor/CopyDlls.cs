using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;


//拷贝dll文件
public static class CopyDlls 
{
    public static string src = "Library/ScriptAssemblies";
    public static string dest = "Assets/_VIP/TotalProject/Resources_moved/MyDlls";
    public static string[] files = new[]{ "HelloDll.dll","HelloDll.pdb"}; 

    [MenuItem("Tools/Cpoy Dlls")]
    public static void DoCopyDlls() {
        Directory.CreateDirectory(dest);
        foreach (var f in files)
        {
            Debug.Log($"{Path.Combine(src,f)} => {Path.Combine(dest,f + ".bytes")}");
            File.Copy(Path.Combine(src,f),Path.Combine(dest,f + ".bytes"),true);
        }

        AssetDatabase.Refresh();
    }
}
