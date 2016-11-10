using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using System.Collections.Generic;
using System;
public class MonsterProxy : Proxy {
    private bool isboss = false;
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
    public void OnCreatMonster(int monster, float time)
    {
        ReadTable temp = ReadTable.getTable;
        Type t;
        if (isboss)
        {
            if (monster > 2)
                monster -= 2;
            if (monster>5)
            {
                Debug.Log("fuck");
            }
            t = Type.GetType(temp.OnFind("monsterDate", (monster * 10).ToString(), "class"));
        }
        else
        {
            if (monster > 5)
            {
                Debug.Log("fuck shit");
            }
            //Debug.Log(monster.ToString());
            t = Type.GetType(temp.OnFind("monsterDate", monster.ToString(), "class"));
        }

        IBlology obj = (IBlology)System.Activator.CreateInstance(t, time);
        MonsterQueue.Enqueue((IBlology)obj);
        
        SendNotification(EventsEnum.monsterCreateMonsterSuccess, (IBlology)obj);
    }

    public void OnGetMonster(GameObject monster)
    {
        AllMonster[monster] = MonsterQueue.Dequeue();
    }
    public void OnInjured(GameObject monster,float hurt)
    {
        PlayerProxy player = (PlayerProxy)Facade.RetrieveProxy(PlayerProxy.NAME);
        float temp = ((float)player.player.damage) * hurt;
        if (AllMonster[monster].HP - ((float)player.player.damage)*hurt > 0)
        {
            AllMonster[monster].HP -=(int)(player.player.damage* hurt);
            SendNotification (EventsEnum.monsterHPChange, AllMonster[monster].HP);
        }
        else
        {
            player.player.MP += SkillParameber.reply;
            OnDie(AllMonster[monster]);
        }
    }
    private void OnDie(IBlology monster)//一个怪物死亡之后  发送产生的道具，确定是否产生某个道具
    {
        if(monster is BossGasInformation)
        {
            isboss = false;
        }
        SendNotification(EventsEnum.monsterDie, monster);
        int temp = UnityEngine.Random.Range(0, 100);
        Debug.Log(temp);
        int a = 100;
        if (temp < 10)
        {
            a = 1;
        }
        else if(temp<25)
        {
            a = 2;
        }
        else if(temp<50)
        {
            a = 3;
        }
        else if (temp < 55)
        {
            a = 4;
        }
        if (a != 100)
        {
            string str = a.ToString();
                String prop_name = ReadTable.getTable.OnFind("propDate", str, "propName");
            if (prop_name != "1111")
            {
                SendNotification(EventsEnum.propCreate, prop_name);
            }
        }
		

    }
    public void OnDestroy(GameObject monster)
    {
		SendNotification(EventsEnum.monsterDie, AllMonster[monster]);
		//AllMonster.Remove(monster);

    }
    public void OnDestroyProp(GameObject prop)
    {
        SendNotification(EventsEnum.propPickUpProp, prop);
    }
    public void OnCreateBoss(int id)
    {
        isboss = true;
        ReadTable temp = ReadTable.getTable;
        Type t;
        t = Type.GetType(temp.OnFind("monsterDate", (id * 100).ToString(), "class"));
        object obj = System.Activator.CreateInstance(t, 1);
        MonsterQueue.Enqueue((IBlology)obj);
        SendNotification(EventsEnum.monsterCreateMonsterSuccess, (IBlology)obj);
    }
}