using UnityEngine;
using System.Collections;

public class GasInformation : IBlology {
	public int ID{get;set;}
	public int damage{get;set;}
	public int HP{get;set;}
    public int normalAttackDistance { get; set; }
    public bool hasAttack { get; set; }
    //public Transform trans { get; set; }
    public GasInformation(float time)
	{
		this.HP = MonsterParameber.lowHP*(int)time;
		this.damage = MonsterParameber.highdamage*(int)time;
        normalAttackDistance = 3;
        ID = 3;

	    hasAttack = false;
	

    }
}
