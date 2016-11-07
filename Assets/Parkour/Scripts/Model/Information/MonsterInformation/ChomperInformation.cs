using UnityEngine;
using System.Collections;
using System;

public class ChomperInformation : IBlology {
	public int ID{get;set;}
	public int damage{get;set;}
	public int HP{get;set;}
    public int normalAttackDistance { get; set; }

    public void OnInView(Transform tran)
    {
        tran.gameObject.SetActive(true);
    }

    public void OnAttack(Transform tran)
    {
        tran.GetComponent<Animator>().SetBool("Attack", true);
    }

    public void OnOutOfAttack(Transform tran)
    {
        tran.GetComponent<Animator>().SetBool("Attack", false);
    }

    public void OnOutView(Transform tran)
    {
        tran.gameObject.SetActive(false);
    }

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
        //this.trans = trans;
    }
}
