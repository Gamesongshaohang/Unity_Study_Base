using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AIState
{
    Idle,
    Seek,
    Attack,
    Die
}
/// <summary>
/// AI单位的基类
/// </summary>
public class MyAIBase : MonoBehaviour
{
    public MyAIBase target = null;//攻击目标，MyAIBase
    public AIState state = AIState.Idle;
    public float lastBlowTime = 0;

    public virtual void OnIdle() { }
    public virtual void OnSeek() { }
    public virtual void OnAttack() { }
    public virtual void OnDie() { }

}
