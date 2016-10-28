using UnityEngine;
using System.Collections;

public class BlueGasInformation : IBlology {
	public int ID{get;set;}
	public int damage{get;set;}
	public int HP{get;set;}
	public int normalAttackDistance { get; set; }
	public bool hasAttack { get; set; }
	//public Transform trans { get; set; }
	public BlueGasInformation(float time)
	{
		ID = 20;
		ReadTable monsterchomper = ReadTable.getTable;
		this.HP = int.Parse (monsterchomper.OnFind ("monsterDate", ID.ToString (), "HP"));
		this.damage = int.Parse (monsterchomper.OnFind ("monsterDate", ID.ToString (), "damage"));
		normalAttackDistance = int.Parse (monsterchomper.OnFind ("monsterDate", ID.ToString (), "range"));

		hasAttack = false;


	}
}
