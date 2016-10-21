﻿using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using System.Collections.Generic;
using PureMVC.Interfaces;
using System;
/// <summary>
/// 怪物跑出屏幕控制   张子庆
/// </summary>
public class MonsterInjuredInfor
{
    public GameObject monster;
    public ISkill skill;
    public MonsterInjuredInfor(GameObject monster, ISkill skill)
    {
        this.monster = monster;
        this.skill = skill;
    }
}
public class MonsterMediator : Mediator,IMonsterMediator {

    public new const string NAME = "MonsterMediator";
    Dictionary<IBlology, GameObject> monster = new Dictionary<IBlology, GameObject>();
    private Monster monsterControl;
    public UI ui;
    public Transform monsterCreatePosition;
    private static MonsterMediator monsterMediator;

    Dictionary<IBlology, GameObject> IMonsterMediator.monster
    {
        get
        {
            return monster;
        }
    }

    private MonsterMediator(Monster monsterControl,UI ui) : base(NAME)
    {
        this.monsterControl = monsterControl;
        this.ui = ui;
        monsterControl.OnSetMonsterMediator(this);
    }
    public static MonsterMediator OnGetMonsterMediator(Monster monsterControl, UI ui)
    {
        if (monsterMediator == null)
        {
            monsterMediator = new MonsterMediator(monsterControl, ui);
            return monsterMediator;
        }
        else {
            return monsterMediator;
        }
    }
    public static MonsterMediator OnGetMonsterMediator()
    {
        if (monsterMediator == null)
        {
            Debug.Log("MonsterMediator为空");
            return monsterMediator;
        }
        else
        {
            return monsterMediator;
        }
    }
	public void OnCreateMonster()
    {
		SendNotification(EventsEnum.monsterCreateMonster);
		//Debug.Log (1111);
    }
    /// <summary>
    /// view层创造的怪物传给后台
    /// </summary>
    public void OnDestroyMonster(GameObject monster)
    {
        SendNotification(EventsEnum.monsterDestroy, monster);
    }
    public void OnInjured(GameObject monster,ISkill skill)
    {
        MonsterInjuredInfor monsterTemp = new MonsterInjuredInfor(monster, skill);
        SendNotification(EventsEnum.monsterInjured,monsterTemp);
    }
    public override IList<string> ListNotificationInterests()
    {
        IList<string> list = new List<string>();
        list.Add(EventsEnum.monsterCreateMonsterSuccess);
        list.Add(EventsEnum.monsterHPChange);
        list.Add(EventsEnum.monsterDie);

        return list;
    }
    /// <summary>
    /// 处理怪物通知信息
    /// </summary>
    /// <param name="notification"></param>
    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case EventsEnum.monsterCreateMonsterSuccess:
                //Debug.Log(33333);
                IBlology monsterSpecies = (IBlology)notification.Body;
                GameObject monster;
                if(monsterSpecies is ChomperInformation)
                {
                    monster = GameObject.Instantiate(monsterControl.monsterPrefabs[0],monsterCreatePosition.position,Quaternion.identity) as GameObject;
                }
                else if(monsterSpecies is GasInformation)
                {
                    monster = GameObject.Instantiate(monsterControl.monsterPrefabs[1], monsterCreatePosition.position, Quaternion.identity) as GameObject;
                }
                else if(monsterSpecies is DragonInformation)
                {
                    monster = GameObject.Instantiate(monsterControl.monsterPrefabs[2], monsterCreatePosition.position, Quaternion.identity) as GameObject;
                }
                else
                {
                    monster = GameObject.Instantiate(monsterControl.monsterPrefabs[3], monsterCreatePosition.position, Quaternion.identity) as GameObject;
                } 
                SendNotification(EventsEnum.monsterCreateGameObject, monster);
                this.monster.Add(monsterSpecies, monster);
                //foreach (var item in this.monster)
                //{
                //    Debug.Log(item.Key);
                //    Debug.Log(item.Value);
                //}
                break;
            case EventsEnum.monsterHPChange:
                Debug.Log(((int)notification.Body));
                break;

                //销毁怪物
            case EventsEnum.monsterDie:
                //Debug.Log((IBlology)notification.Body);
                GameObject temp = this.monster[(IBlology)notification.Body];
                this.monster.Remove((IBlology)notification.Body);
                GameObject.Destroy(temp);
                //Debug.Log(((IBlology)notification.Body));
                break;
        }
    }
}
