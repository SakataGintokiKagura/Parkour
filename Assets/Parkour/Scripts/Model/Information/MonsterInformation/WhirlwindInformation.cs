using UnityEngine;
using System.Collections;

public class WhirlwindInformation : IBlology {
    public int ID { get; set; }
    public int HP { get; set; }
    public int damage { get; set; }
    public int normalAttackDistance { get; set; }
    public void OnInView(Transform tran)
    {
        tran.gameObject.SetActive(true);
    }

    public void OnAttack(Transform tran)
    {
        tran.position += new Vector3(0.05f, 0, 0);
    }

    public void OnOutOfAttack(Transform tran)
    {
        
    }

    public void OnOutView(Transform tran)
    {
        tran.gameObject.SetActive(false);
    }
    public WhirlwindInformation(float time)
    {
        ID = 30;
        ReadTable monsterchomper = ReadTable.getTable;
        //Type t;
        //t=Type.GetType(monsterchomper.OnFind("monsterParameber",monster.ToString(),"class"));
        this.HP = int.Parse(monsterchomper.OnFind("monsterDate", ID.ToString(), "HP"));
        this.damage = int.Parse(monsterchomper.OnFind("monsterDate", ID.ToString(), "damage"));
        normalAttackDistance = int.Parse(monsterchomper.OnFind("monsterDate", ID.ToString(), "range"));
        //this.trans = trans;
    }
}
