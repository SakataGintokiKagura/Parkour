using UnityEngine;
using System.Collections;

public class DragonInformation : IBlology {

	public int damage{get;set;}
	public int HP{get;set;}
	//public Transform trans { get; set; }
	public DragonInformation(float time)
	{
		this.HP = MonsterParameber.highHP*(int)time;
		this.damage = MonsterParameber.lowdamage*(int)time;
		//this.trans = trans;
	}
}
