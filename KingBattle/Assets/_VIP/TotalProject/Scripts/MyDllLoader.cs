using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class MyDllLoader : MonoBehaviour
{
    private async void Start()
    {
        TextAsset dll =  await Addressables.LoadAssetAsync<TextAsset>("HelloDll.dll").Task;
        TextAsset pdb = await Addressables.LoadAssetAsync<TextAsset>("HelloDll.pdb").Task;

        var ass = Assembly.Load(dll.bytes,pdb.bytes);
        foreach (var item in ass.GetTypes())
        {
            print(item);
        }

        Addressables.Release<TextAsset>(dll);
        Addressables.Release<TextAsset>(pdb);
    }
}
