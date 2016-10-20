using UnityEngine;
using System.Collections;
using System;

public class TortoiseInformation : IBlology {
    public int damage{get;set;}
    public int HP{get;set;}
    //public Transform trans { get; set; }
    public TortoiseInformation(float time)
    {
		this.HP = MonsterParameber.highHP*(int)time;
		this.damage = MonsterParameber.lowdamage*(int)time;
        //this.trans = trans;
    }
}
