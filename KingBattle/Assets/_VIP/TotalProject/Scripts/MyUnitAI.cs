using UnityEngine;
using System.Collections;

public class MyUnitAI : MyAIBase
{
    //投掷物预制体
    public GameObject projectilePerfab;
    //投掷角色的手部位置
    public Transform firePos;

    //动画播放触发伤害计算
    public void OnDealDamage() {
        //攻击伤害结算
        if (this.target)
        {
            this.target.GetComponent<MyPlacebleView>().data.hitPoints -= this.GetComponent<MyPlacebleView>().data.damagePerAttack;
            if (this.target.GetComponent<MyPlacebleView>().data.hitPoints < 0)
            {
                this.target.GetComponent<MyPlacebleView>().data.hitPoints = 0;
                this.target = null;
            }
        }
      
       
    }

    //投掷物逻辑出来
    public void OnFireProjectile() {

        GameObject gameObject =  Instantiate(projectilePerfab, firePos.position, Quaternion.identity);
        gameObject.GetComponent<Myprojectile>().caster = this;
        gameObject.GetComponent<Myprojectile>().target = this.target;
        //投掷物在PlacbleMgr统一管理
        MyPlacebleMgr.instance.myprojectiles.Add(gameObject.GetComponent<Myprojectile>());
    }
}
