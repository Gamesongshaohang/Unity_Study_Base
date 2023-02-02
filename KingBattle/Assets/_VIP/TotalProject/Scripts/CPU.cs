using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityRoyale;

//
//敌方自动出兵的脚本
public class CPU : MonoBehaviour
{
    public float interval = 10f;//出兵间隔时间
    public Transform[] range = new Transform[2];

    private void Start()
    {
        StartCoroutine(CardOut());
    }

    IEnumerator CardOut() {
        while (true) {
            yield return new WaitForSeconds(interval);
            var cartList = MyCardModel.instance.list;
            var cardData = cartList[Random.Range(0, cartList.Count)];
            var viewList = myCardView.CreatePlaceble(
                cardData,
                new Vector3(Random.Range(range[0].position.x, range[1].position.x),0,Random.Range(range[0].position.y, range[1].position.y)),  //随机出兵范围
                MyPlacebleMgr.instance.transform,
                Placeable.Faction.Opponent);

            foreach (var item in viewList)
            {
                MyPlacebleMgr.instance.his.Add(item);
            }
        }
        
    }
}
