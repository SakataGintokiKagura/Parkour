using UnityEngine;
using System.Collections;
/// <summary>
/// 朱科锦
/// 构造龙类，实现Iblology接口
/// 怪物属性随事件提升
/// </summary>
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
