using UnityEngine;
using System.Collections;
using System;

public class ChomperInformation : IBlology {

	public int damage{get;set;}
	public int HP{get;set;}
    public int normalAttackDistance { get; set; }
    public bool hasAttack { get; set; }
  

    //public Transform trans { get; set; }
    public ChomperInformation(float time)
	{
		this.HP = MonsterParameber.lowHP*(int)time;
		this.damage = MonsterParameber.highdamage*(int)time;
        normalAttackDistance = 6;
	    hasAttack = false;
	    //this.trans = trans;
	}
}
