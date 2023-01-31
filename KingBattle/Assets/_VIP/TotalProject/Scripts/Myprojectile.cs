using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 投掷物脚本
/// </summary>

public class Myprojectile : MonoBehaviour
{
    public MyAIBase caster;//投掷物释放者
    public MyAIBase target;//投掷物释放者
    public float porgress = 0;//投掷物距离目标点的距离进度（百分比）
    public float speed = 1f;//投掷物飞行速度


}
