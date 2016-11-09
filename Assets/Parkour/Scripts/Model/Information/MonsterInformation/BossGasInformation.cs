using UnityEngine;
using System.Collections;

public class BossGasInformation : IBlology {

	public int ID{get;set;}
	public int damage{get;set;}
	public int HP{get;set;}
	public int normalAttackDistance { get; set; }
    public void OnInView(Transform tran)
    {
        return;
    }

    public void OnAttack(Transform tran)
    {
        return;
    }

    public void OnOutOfAttack(Transform tran)
    {
        return;
    }

    public void OnOutView(Transform tran)
    {
        return;
    }

	//public Transform trans { get; set; }
	public BossGasInformation(float time)
	{
		ID = 100;
		ReadTable monsterchomper = ReadTable.getTable;
		this.HP = int.Parse (monsterchomper.OnFind ("monsterDate", ID.ToString (), "HP"));
		this.damage = int.Parse (monsterchomper.OnFind ("monsterDate", ID.ToString (), "damage"));
		normalAttackDistance = int.Parse (monsterchomper.OnFind ("monsterDate", ID.ToString (), "range"));
	}
}
