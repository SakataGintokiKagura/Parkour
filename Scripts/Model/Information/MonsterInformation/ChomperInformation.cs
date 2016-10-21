using UnityEngine;
using System.Collections;
//食人花
public class ChomperInformation : IBlology {

	public int damage{get;set;}//攻击力
	public int HP{get;set;}//生命值
    public int normalAttackDistance { get; set; }
    //public Transform trans { get; set; }
    public ChomperInformation(float time)//根据时间提升怪物属性
	{
		this.HP = MonsterParameber.lowHP*(int)time;
		this.damage = MonsterParameber.highdamage*(int)time;
        normalAttackDistance = 6;
        //this.trans = trans;
    }
}
