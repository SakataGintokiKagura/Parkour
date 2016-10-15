using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using System.Collections.Generic;
public class MonsterProxy : Proxy {

    public new const string NAME = "MonsterProxy";
    public Dictionary<GameObject, IBlology> monster = new Dictionary<GameObject, IBlology>();
    public MonsterProxy() : base(NAME)
    {
    }
    public void OnCreatMonster(MonsterEnum monster,float time)
    {
        IBlology monsterTemp = new TortoiseInformation(time);
        SendNotification(EventsEnum.monsterCreateMonsterSuccess,monsterTemp);
    }
    public void OnGetMonster(GameObject monster)
    {

    }
    public void OnInjured(GameObject monster,int hurt)
    {
        IBlology monsterTemp = this.monster[monster];
        SendNotification(EventsEnum.monsterHPChange, hurt);
    }
    private void OnDie(GameObject monster)
    {
        SendNotification(EventsEnum.monsterDie, monster);
    }
    public void OnDestroy(GameObject mosnter)
    {
        SendNotification(EventsEnum.monsterDie, monster);
    }
}