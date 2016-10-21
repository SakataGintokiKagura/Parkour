﻿using UnityEngine;
using System.Collections;
//瓦斯
public class GasInformation : IBlology {

	public int damage{get;set;}//攻击力
	public int HP{get;set;}//生命值
    public int normalAttackDistance { get; set; }
    //public Transform trans { get; set; }
	public GasInformation(float time)//根据时间提升怪物属性
	{
		this.HP = MonsterParameber.lowHP*(int)time;
		this.damage = MonsterParameber.highdamage*(int)time;
        normalAttackDistance = 3;
        //this.trans = trans;
    }
}
