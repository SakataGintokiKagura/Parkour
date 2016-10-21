using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using System.Collections.Generic;
public class MonsterProxy : Proxy {
    public new const string NAME = "MonsterProxy";
    private static Dictionary<GameObject, IBlology> AllMonster = new Dictionary<GameObject, IBlology>();
    public static Dictionary<GameObject, IBlology> AllMONSTER
    {
        get
        {
            return AllMonster;
        }
    }

    public Queue<IBlology> MonsterQueue = new Queue<IBlology> ();
    public MonsterProxy() : base(NAME)
    {
    }
    public void OnCreatMonster(MonsterEnum monster,float time)
    {
        IBlology temp = new ChomperInformation(time);
		switch(monster){//判断生成怪物
		case MonsterEnum.Chomper:
                temp = new ChomperInformation(time);
			//Debug.Log ("Chomper");
			//AllMonster.Add ();
			    break;
		case MonsterEnum.Dragon:
                temp = new DragonInformation(time);
			    break;
			//AllMonster.Add ();
		case MonsterEnum.Gas:
                temp = new GasInformation(time);
                break;
			//AllMonster.Add ();
		case MonsterEnum.Tortoise:
                temp = new TortoiseInformation(time);
                break;
			//AllMonster.Add ();
		}
        MonsterQueue.Enqueue(temp);
        SendNotification(EventsEnum.monsterCreateMonsterSuccess, temp);
        //Debug.Log(monster);
        //Debug.Log(MonsterQueue);
        //MonsterMediator.OnGetMonsterMediator().OnCreat()
    }
    public void OnGetMonster(GameObject monster)
    {
		AllMonster.Add (monster,MonsterQueue.Dequeue());
        
    }
    public void OnInjured(GameObject monster,float hurt)
    {
       // Debug.Log(monster);
        PlayerProxy player = (PlayerProxy)Facade.RetrieveProxy(PlayerProxy.NAME);
        if (AllMonster[monster].HP - player.player.damage*hurt > 0)
        {
            
            SendNotification (EventsEnum.monsterHPChange, hurt);
        }
        else
        {
            //AllMonster.Remove(monster);
            player.player.MP += SkillParameber.reply;
            OnDie(AllMonster[monster]);
            //AllMonster.Remove(monster);
        }
    }
    private void OnDie(IBlology monster)
    {
        
        SendNotification(EventsEnum.monsterDie, monster);
        
    }
    public void OnDestroy(GameObject monster)
    {
		SendNotification(EventsEnum.monsterDie, AllMonster[monster]);
		AllMonster.Remove(monster);
    }
}