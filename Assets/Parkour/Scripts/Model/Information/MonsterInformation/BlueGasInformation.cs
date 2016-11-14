using UnityEngine;
using System.Collections;
using System;

public class BlueGasInformation : IBlology {
	public int ID{get;set;}
	public int damage{get;set;}
	public int HP{get;set;}
	public int normalAttackDistance { get; set; }
    public void OnInView(Transform tran)
    {
        tran.gameObject.SetActive(true);
        tran.GetComponent<Animator>().SetBool("InView", true);
    }

    public void OnAttack(Transform tran)
    {
        tran.FindChild("Monster_Wasi@skin").gameObject.SetActive(false);
        tran.FindChild("Boom").gameObject.SetActive(true);
        this.HP = 1000;
    }

    public void OnOutOfAttack(Transform tran)
    {

    }

    public void OnOutView(Transform tran)
    {
        ReadTable monsterchomper = ReadTable.getTable;
        this.HP = int.Parse(monsterchomper.OnFind("monsterDate", ID.ToString(), "HP"));
        tran.FindChild("Monster_Wasi@skin").gameObject.SetActive(true);
        tran.FindChild("Boom").gameObject.SetActive(false);
        tran.gameObject.SetActive(false);
    }
    public BlueGasInformation(float time)
	{
		ID = 20;
		ReadTable monsterchomper = ReadTable.getTable;
		this.HP = int.Parse (monsterchomper.OnFind ("monsterDate", ID.ToString (), "HP"));
		this.damage = int.Parse (monsterchomper.OnFind ("monsterDate", ID.ToString (), "damage"));
		normalAttackDistance = int.Parse (monsterchomper.OnFind ("monsterDate", ID.ToString (), "range"));
	}

    
}
