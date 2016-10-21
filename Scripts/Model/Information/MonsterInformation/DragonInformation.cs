using UnityEngine;
using System.Collections;
//龙
public class DragonInformation : IBlology {

	public int damage{get;set;}//攻击力
	public int HP{get;set;}//生命值
    public int normalAttackDistance { get; set; }
    //public Transform trans { get; set; }
	public DragonInformation(float time)//根据时间提升怪物属性
	{
		this.HP = MonsterParameber.highHP*(int)time;
		this.damage = MonsterParameber.lowdamage*(int)time;
        normalAttackDistance = 6;
        //this.trans = trans;
    }
}
