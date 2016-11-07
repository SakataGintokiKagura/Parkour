using UnityEngine;
using System.Collections;
using System;

public class TortoiseInformation : IBlology {
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

        Transform transform = tran.FindChild("Monster_GuikeBlue@skin");

        float time = 0;
        if (transform.localPosition.y <= 0)
        {
            time += Time.deltaTime;
            if (time < 0.25f)
            {
                tran.FindChild("ef_monster_guike").gameObject.SetActive(true);
                transform.localPosition += new Vector3(0, time * 4f, 0);
            }
        }
    }

    public void OnOutOfAttack(Transform tran)
    {
        
    }

    public void OnOutView(Transform tran)
    {
        tran.FindChild("Monster_GuikeBlue@skin").localPosition = new Vector3(0, -1, 0);
        tran.FindChild("ef_monster_guike").gameObject.SetActive(false);
    }


    public TortoiseInformation(float time)
    {
        ID = 2;
        ReadTable monsterchomper = ReadTable.getTable;
        this.HP = int.Parse(monsterchomper.OnFind("monsterDate", ID.ToString(), "HP"));
        this.damage = int.Parse(monsterchomper.OnFind("monsterDate", ID.ToString(), "damage"));
        normalAttackDistance = int.Parse(monsterchomper.OnFind("monsterDate", ID.ToString(), "range"));
    }
}
