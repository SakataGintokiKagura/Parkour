using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using System.Collections.Generic;
public class MonsterProxy : Proxy {
    public new const string NAME = "MonsterProxy";
    private static Dictionary<GameObject, IBlology> AllMonster = new Dictionary<GameObject, IBlology>();//所有怪物用一个字典类存储
    public static Dictionary<GameObject, IBlology> AllMONSTER
    {
        get
        {
            return AllMonster;
        }
    }

    public Queue<IBlology> MonsterQueue = new Queue<IBlology> ();//创造怪物，用队列存储起来
    public MonsterProxy() : base(NAME)
    {
    }
    public void OnCreatMonster(MonsterEnum monster,float time)
    {
        IBlology temp = new ChomperInformation(time);
		switch(monster){//判断生成那中国怪物
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
	//怪物受伤
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
	//怪物死亡
    private void OnDie(IBlology monster)
    {
        
        SendNotification(EventsEnum.monsterDie, monster);
        
    }
	//怪物移出屏幕
    public void OnDestroy(GameObject monster)
    {
		SendNotification(EventsEnum.monsterDie, AllMonster[monster]);
		AllMonster.Remove(monster);
    }
}