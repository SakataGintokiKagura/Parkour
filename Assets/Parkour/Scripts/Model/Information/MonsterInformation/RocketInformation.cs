using UnityEngine;
using System.Collections;
using System;

public class RocketInformation : IBlology
{
    public int ID { get; set; }
    public int damage { get; set; }
    public int HP { get; set; }
    public int normalAttackDistance { get; set; }
    public void OnInView(Transform tran)
    {
        tran.gameObject.SetActive(true);
        tran.position += new Vector3(-0.2f, 0, 0);
    }

    public void OnAttack(Transform tran)
    {
        
    }

    public void OnOutOfAttack(Transform tran)
    {
        
    }

    public void OnOutView(Transform tran)
    {
        tran.gameObject.SetActive(false);
    }

    public RocketInformation(float time)
    {
        ID = 5;
        ReadTable monsterrocket = ReadTable.getTable;
        this.HP = int.Parse(monsterrocket.OnFind("monsterDate", ID.ToString(), "HP"));
        this.damage = int.Parse(monsterrocket.OnFind("monsterDate", ID.ToString(), "damage"));
        normalAttackDistance = int.Parse(monsterrocket.OnFind("monsterDate", ID.ToString(), "range"));
    }
}