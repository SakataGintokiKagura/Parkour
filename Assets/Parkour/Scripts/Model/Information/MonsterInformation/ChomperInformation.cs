using UnityEngine;
using System.Collections;
using System;

public class ChomperInformation : IBlology {
	public int ID{get;set;}
	public int damage{get;set;}
	public int HP{get;set;}
    public int normalAttackDistance { get; set; }
    public bool hasAttack { get; set; }
  

    //public Transform trans { get; set; }
    public ChomperInformation(float time)
	{
        ID = 4;
        ReadTable monsterchomper = ReadTable.getTable;
        //Type t;
        //t=Type.GetType(monsterchomper.OnFind("monsterParameber",monster.ToString(),"class"));
        this.HP = int.Parse(monsterchomper.OnFind("monsterDate", ID.ToString(), "HP"));
        this.damage = int.Parse(monsterchomper.OnFind("monsterDate", ID.ToString(), "damage"));
        normalAttackDistance = int.Parse(monsterchomper.OnFind("monsterDate", ID.ToString(), "range"));
        hasAttack = false;
        //this.trans = trans;
    }

	
}
