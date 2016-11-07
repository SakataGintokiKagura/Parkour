using UnityEngine;
using System.Collections;

public class DragonInformation : IBlology
{
    public int ID { get; set; }
    public int damage { get; set; }
    public int HP { get; set; }
    public int normalAttackDistance { get; set; }
    public void OnInView(Transform tran)
    {
        tran.gameObject.SetActive(true);

    }

    public void OnAttack(Transform tran)
    {

        tran.FindChild("Mount_Dragon@skin/ef_GQ_long_chongci").gameObject.SetActive(true);
        tran.FindChild("Collider_Dragon").gameObject.SetActive(true);
    }

    public void OnOutOfAttack(Transform tran)
    {
        tran.FindChild("Mount_Dragon@skin/ef_GQ_long_chongci").gameObject.SetActive(false);
        tran.FindChild("Collider_Dragon").gameObject.SetActive(false);
    }

    public void OnOutView(Transform tran)
    {
        tran.FindChild("Mount_Dragon@skin/ef_GQ_long_chongci").gameObject.SetActive(false);
        tran.gameObject.SetActive(false);
    }

    
    //public Transform trans { get; set; }
    public DragonInformation(float time)
    {
        ID = 1;
        ReadTable monsterchomper = ReadTable.getTable;
        this.HP = int.Parse(monsterchomper.OnFind("monsterDate", ID.ToString(), "HP"));
        this.damage = int.Parse(monsterchomper.OnFind("monsterDate", ID.ToString(), "damage"));
        normalAttackDistance = int.Parse(monsterchomper.OnFind("monsterDate", ID.ToString(), "range"));
    }
}
