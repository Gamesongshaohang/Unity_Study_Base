using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 角色控制，具有AI逻辑的角色,数据动画等数据
/// </summary>
public class MyPlacebleView : MonoBehaviour
{
    public MyPlaceable data;

    public float dieDuration = 10f;   //死亡总时长
    public float dieProgress = 0f; //当前死亡进度


    //单位死亡时
    private void OnDestroy()
    {
        MyPlacebleMgr.instance.mine.Remove(this);
        MyPlacebleMgr.instance.his.Remove(this);
    }
}
