using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AI;
using UnityRoyale;


public partial class MyPlaceable //partial：部分类
{
    public Placeable.Faction faction = Placeable.Faction.None;
    public MyPlaceable Clone() {
        //克隆一个类，与创建对象不同的是，对于非静态的字段，克隆对象会保持这些数据，new对象则不会
        return this.MemberwiseClone() as MyPlaceable;
    }
}

/// <summary>
/// 所以具有AI逻辑角色的控制类
/// </summary>
public class MyPlacebleMgr : MonoBehaviour
{
    public static MyPlacebleMgr instance;
    public List<MyPlacebleView> mine = new List<MyPlacebleView>(); //所有己方单位的View脚本
    public List<MyPlacebleView> his = new List<MyPlacebleView>();//所有敌方单位的View脚本


    public Transform trHisTower,trMyTower;//敌人防御塔的位置

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        his.Add(trHisTower.GetComponent<MyPlacebleView>());
        mine.Add(trMyTower.GetComponent<MyPlacebleView>());
        
    }
    private void Update()
    {
        //游戏AI
        //游戏己方所有投掷物

        //游戏己方所以单位AI
        UpdatePlaceble(mine);
        UpdatePlaceble(his);


    }

    

    //游戏单位AI逻辑
    public void UpdatePlaceble(List<MyPlacebleView> pViews)
    {
        for (int i = 0; i < pViews.Count; i++)
        {
            MyPlacebleView view = pViews[i];  //游戏单位view脚本
            MyPlaceable data = view.data;
            MyAIBase ai = view.GetComponent<MyAIBase>();//游戏单位ai脚本
            NavMeshAgent nav = ai.GetComponent<NavMeshAgent>();
            Animator animator = ai.GetComponent<Animator>();
            NavMeshObstacle navMeshObstacle = ai.GetComponent<NavMeshObstacle>();
            //简单的状态机实现
            switch (ai.state)
            {
                case AIState.Idle:
                    {
                        if (ai is MyBuildingAI) 
                            break;
                        //查找场景内最近的敌人
                        ai.target = FindNearstenemy(transform.position, data.faction);
                        if (ai.target != null)
                        {
                            ai.state = AIState.Seek;
                            nav.enabled = true;
                            if (navMeshObstacle)
                            {
                                // navMeshObstacle.enabled = false;
                            }
                            animator.SetBool("IsMoving", true);
                        }
                        else
                        { animator.SetBool("IsMoving", false); }
                        //检测是否有敌人在范围
                    }
                    break;
                case AIState.Seek:
                    {
                       //出现同个目标多个游戏单位共同攻击的情况，会出现目标被其他游戏单位击杀的情况
                        if (ai.target == null)
                        {
                            ai.state = AIState.Idle;
                            break;
                        }
                        //查找场景内最近的敌人
                        //ai.target = FindNearstenemy(transform.position, data.faction);
                        nav.enabled = true;
                        //向敌人方向前进
                        nav.destination = ai.target.transform.position;
                        //判定是否进入攻击范围
                        if (IsInAttackRanage(view.transform.position, ai.target.transform.position, data.attackRange))
                        {         
                            nav.enabled = false;
                            ai.state = AIState.Attack;
                            animator.SetBool("IsMoving", false);
                            if (navMeshObstacle)
                            {
                                // navMeshObstacle.enabled = true;
                            }
                         
                        }
                    }
                    break;
                case AIState.Attack:
                    {
                        //出现同个目标多个游戏单位共同攻击的情况，会出现目标被其他游戏单位击杀的情况
                        if (ai.target == null)
                        {
                            ai.state = AIState.Idle;
                            break;
                        }
                        //判定是否进入攻击范围
                        if (IsInAttackRanage(view.transform.position, ai.target.transform.position, data.attackRange) == false)
                        {
                            ai.state = AIState.Idle;
                            break;
                        }
                        //攻击间隔
                        if (Time.time < ai.lastBlowTime + data.attackRatio)
                        {                 
                            break;
                        }
                        //攻击敌人
                        animator.SetBool("IsMoving", false);
                        animator.SetTrigger("Attack");
                        nav.enabled = false;
                        ai.lastBlowTime = Time.time;
                        ai.transform.LookAt(ai.target.transform);

                        var myPlacebleView = ai.target.GetComponent<MyPlacebleView>();
                        if (myPlacebleView.data.hitPoints <= 0)
                        {
                            OnEnterDie(ai.target);
                            ai.target = null;
                            ai.state = AIState.Idle;
                        }
                    }
                    break;
                case AIState.Die:
                    {
                        if (ai is MyBuildingAI)
                            break;
               
                        var rds = ai.GetComponentsInChildren<Renderer>();
                        view.dieProgress += Time.deltaTime * (1/view.dieDuration);
                        foreach (var rd in rds)
                        {
                            rd.material.SetFloat("_DissolveFactor", view.dieProgress);
                        }
                    }
                    break;
            }
        }
    }

    //角色死亡
    public  void OnEnterDie(MyAIBase target)
    {
        var myPlacebleView = target.GetComponent<MyPlacebleView>();
        print(target.gameObject.name + "死亡了");
        if (target.state == AIState.Die) //防止重复进入死亡状态
            return;
        var nav = target.GetComponent<NavMeshAgent>();
        if (nav)
            nav.enabled = false;

      
        target.GetComponent<MyAIBase>().state = AIState.Die;
        myPlacebleView.data.hitPoints = 0;
        if (target.GetComponent<Animator>())
        {
            target.GetComponent<Animator>().SetTrigger("IsDead");
        }

        //死亡溶解,设置Shader的参数
        //查找target的所有子节点
        var rds = target.GetComponentsInChildren<Renderer>();
        var view = target.GetComponent<MyPlacebleView>();
        var color = view.data.faction == Placeable.Faction.Player ? Color.red : Color.blue;
        view.dieProgress = 0;
        foreach (var rd in rds)
        {
         
            rd.material.SetColor("_EdgeColor", color * 8);
            rd.material.SetFloat("_EdgeWidth",0.1f);
            rd.material.SetFloat("_DissolveFactor",0f);
        }

        //设置延迟溶解
       Destroy(target.gameObject,view.dieDuration);

    }

    /// <summary>
    /// 是否进入攻击距离
    /// </summary>
    /// <param name="position1"></param>
    /// <param name="position2"></param>
    /// <param name="attackRange"></param>
    /// <returns></returns>
    private bool IsInAttackRanage(Vector3 position1, Vector3 position2, float attackRange)
    {
        return attackRange >= Vector3.Distance(position1, position2);
    }

    /// <summary>
    /// 查找离当前游戏单位最近的敌人
    /// </summary>
    /// <param name="position"></param>
    /// <param name="faction"></param>
    private MyAIBase FindNearstenemy(Vector3 position, Placeable.Faction faction)
    {
        List<MyPlacebleView> units = faction == Placeable.Faction.Player ? his : mine;
        float tempValue = float.MaxValue;
        MyAIBase nearUnit = null;
        foreach (MyPlacebleView unit in units)
        {
            float distance = Vector3.Distance(position,unit.transform.position);
            if (distance < tempValue && unit.data.hitPoints > 0)
            {
                tempValue = distance;
                nearUnit = unit.GetComponent<MyAIBase>();
            }
        }
        return nearUnit;
    }
}
