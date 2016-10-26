﻿using UnityEngine;
using System.Collections;
using System;

public class TortoiseInformation : IBlology {
    public int damage{get;set;}
    public int HP{get;set;}
    public int normalAttackDistance { get; set; }
    public bool hasAttack { get; set; }
    //public Transform trans { get; set; }
    public TortoiseInformation(float time)
    {
		this.HP = MonsterParameber.highHP*(int)time;
		this.damage = MonsterParameber.lowdamage*(int)time;
        normalAttackDistance = 8;
        hasAttack = false;
        //this.trans = trans;
    }
}
