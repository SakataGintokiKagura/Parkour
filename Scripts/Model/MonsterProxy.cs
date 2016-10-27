using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using System.Collections.Generic;
using System;
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
    public void OnCreatMonster(int monster,float time)
    {
		ReadTable temp = ReadTable.getTable;
		Type t=Type.GetType(temp.OnFind("monsterDate",monster.ToString(),"class"));
		object obj = System.Activator.CreateInstance (t,time);

		MonsterQueue.Enqueue((IBlology)obj);
		SendNotification(EventsEnum.monsterCreateMonsterSuccess, (IBlology)obj);

    }

    public void OnGetMonster(GameObject monster)
    {
        AllMonster[monster] = MonsterQueue.Dequeue();
        //AllMonster.Add (monster,MonsterQueue.Dequeue());
        
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
		//AllMonster.Remove(monster);
    }
}