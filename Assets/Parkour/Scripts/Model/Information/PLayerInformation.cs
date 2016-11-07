using UnityEngine;
using System.Collections;
using System;

public class PLayerInformation : IBlology
{
	public int ID{get;set;}
    public int damage{get;set;}
    public int HP{get;set;}
    public int MP { get; set; }
    public int score { get; set; }

    public int normalAttackDistance { get; set; }
    public void OnInView(Transform tran)
    {
        throw new NotImplementedException();
    }

    public void OnAttack(Transform tran)
    {
        throw new NotImplementedException();
    }

    public void OnOutOfAttack(Transform tran)
    {
        throw new NotImplementedException();
    }

    public void OnOutView(Transform tran)
    {
        throw new NotImplementedException();
    }


    //public Transform trans { get; set; }

    public PLayerInformation()
    {
        this.HP = 100;
        this.damage = 30;
        this.MP = 100;
        this.score = 0;
    }
}
