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

        ReadTable prop=ReadTable.getTable;
        float temp = UnityEngine.Random.Range(0, 100)/(float)100;
        
        int num=Int32.Parse(prop.OnFind("propDate", "1000", "name"));
        List<float> proba=new List<float>();
        for (int i = 1; i <= num; i++)
        {
            proba.Add(float.Parse(prop.OnFind("propDate", i.ToString(), "probability")));
        }
        
        int a = 100;
        float pro = 0;
        for (int i = 1; i <= num; i++)
        {
            pro += proba[i - 1];
            if (temp < pro)
            {
                a = i;
                break;
            }
        }
        if (a != 100)
        {
            Debug.Log("生成道具的ID："+a);
            string str = a.ToString();
            SendNotification(EventsEnum.propCreate, str);
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