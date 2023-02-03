using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyprojectileMgr : MonoBehaviour
{
    public static MyprojectileMgr instance = null;


    public List<Myprojectile> myprojectiles = new List<Myprojectile>();//所有己方单位的投掷物脚本
    public List<Myprojectile> hisprojectiles = new List<Myprojectile>();//所有敌方单位的投掷物脚本

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
    
        //投掷物逻辑
        UpdateProjectiles(myprojectiles);
        UpdateProjectiles(hisprojectiles);

    }

    //投掷物逻辑
    public void UpdateProjectiles(List<Myprojectile> projectiles)
    {
        List<Myprojectile> desList = new List<Myprojectile>();
        for (int i = 0; i < projectiles.Count; i++)
        {

            var proj = myprojectiles[i];
            proj.porgress += Time.deltaTime * proj.speed;

            MyUnitAI casterAI = proj.caster as MyUnitAI;
            MyAIBase targetAI = proj.target;
            //设置投掷物的位置

            if (targetAI == null)
            {
                Destroy(proj.gameObject);
                desList.Add(proj);
                continue;
            }
            proj.transform.position = Vector3.Lerp(proj.caster.transform.position, proj.target.transform.position + Vector3.up, proj.porgress);


            //投掷物飞行结束
            if (proj.porgress >= 1f)
            {
                casterAI.OnDealDamage();//投掷物的持有者对被攻击者进行伤害判定
                if (targetAI == null) return;
                if (targetAI.GetComponent<MyPlacebleView>().data.hitPoints <= 0) //目标死亡
                {
                    MyPlacebleMgr.instance.OnEnterDie(targetAI);
                }
                Destroy(proj.gameObject);
                desList.Add(proj);
            }
        }

        foreach (var item in desList)
        {
            myprojectiles.Remove(item);
        }
    }
}
