using UnityEngine;
using System.Collections;
using System;
//龟
public class TortoiseInformation : IBlology {
    public int damage{get;set;}//攻击力
    public int HP{get;set;}//生命值
    public int normalAttackDistance { get; set; }
    //public Transform trans { get; set; }
	public TortoiseInformation(float time)//根据时间提升怪物属性
    {
		this.HP = MonsterParameber.highHP*(int)time;
		this.damage = MonsterParameber.lowdamage*(int)time;
        normalAttackDistance = 8;
        //this.trans = trans;
    }
}
