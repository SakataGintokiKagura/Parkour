using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using System.Collections.Generic;
public class MonsterProxy : Proxy {
    public new const string NAME = "MonsterProxy";
    public Dictionary<GameObject, IBlology> AllMonster = new Dictionary<GameObject, IBlology>();
	public Queue<IBlology> MonsterQueue = new Queue<IBlology> ();
    public MonsterProxy() : base(NAME)
    {
    }
    public void OnCreatMonster(MonsterEnum monster,float time)
    {
		switch(monster){//判断生成怪物
		case MonsterEnum.Chomper:
			MonsterQueue.Enqueue (new ChomperInformation (time));
			SendNotification (EventsEnum.monsterCreateMonsterSuccess, new ChomperInformation (time));
			//Debug.Log ("Chomper");
			//AllMonster.Add ();
			break;
		case MonsterEnum.Dragon:
			MonsterQueue.Enqueue (new DragonInformation (time));
			SendNotification (EventsEnum.monsterCreateMonsterSuccess, new DragonInformation (time));
			break;
			//AllMonster.Add ();
		case MonsterEnum.Gas:
			MonsterQueue.Enqueue (new GasInformation (time));
			SendNotification (EventsEnum.monsterCreateMonsterSuccess, new GasInformation (time));
			break;
			//AllMonster.Add ();
		case MonsterEnum.Tortoise:
			MonsterQueue.Enqueue (new TortoiseInformation (time));
			SendNotification (EventsEnum.monsterCreateMonsterSuccess, new TortoiseInformation (time));
			break;
			//AllMonster.Add ();
		}


    }
    public void OnGetMonster(GameObject monster)
    {
		AllMonster.Add (monster,MonsterQueue.Dequeue());
		//Debug.Log (111122);
    }
    public void OnInjured(GameObject monster,float hurt)
    {
		if (this.AllMonster [monster].HP - hurt > 0) {
			SendNotification (EventsEnum.monsterHPChange, hurt);
		} else {
			OnDie(monster);
		}
    }
    private void OnDie(GameObject monster)
    {
		//hp小于0
        SendNotification(EventsEnum.monsterDie, monster);
		AllMonster.Remove(monster);
    }
    public void OnDestroy(GameObject monster)
    {
		SendNotification(EventsEnum.monsterDie, monster);
		AllMonster.Remove(monster);
    }
}