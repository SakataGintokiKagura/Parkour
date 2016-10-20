using UnityEngine;
using System.Collections;

public class GasInformation : IBlology {

	public int damage{get;set;}
	public int HP{get;set;}
	//public Transform trans { get; set; }
	public GasInformation(float time)
	{
		this.HP = MonsterParameber.lowHP*(int)time;
		this.damage = MonsterParameber.highdamage*(int)time;
		//this.trans = trans;
	}
}
