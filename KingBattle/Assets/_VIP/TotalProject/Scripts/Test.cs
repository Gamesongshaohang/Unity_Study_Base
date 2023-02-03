using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
        print("-----1----------");
        await 创建卡牌到预览区(3f);
        print("-----2----------");
   
    }

    public async Task 创建卡牌到预览区(float delayTime)
    {
        await Task.Run(()=> {
            for (int i = 0; i < 100; i++)
            {
                print("创建卡牌到预览区");
            }
        });
       

    }

}
