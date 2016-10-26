using UnityEngine;
using System.Collections;
using System;

public class TortoiseInformation : IBlology {
	public int ID{get;set;}
    public int damage{get;set;}
    public int HP{get;set;}
    public int normalAttackDistance { get; set; }
    //public Transform trans { get; set; }
    public TortoiseInformation(float time)
    {
		this.HP = MonsterParameber.highHP*(int)time;
		this.damage = MonsterParameber.lowdamage*(int)time;
        normalAttackDistance = 8;
		ID = 2;
        //this.trans = trans;
    }
}
