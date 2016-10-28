﻿using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using System.Collections.Generic;
using PureMVC.Interfaces;
using System;

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
    private Vector3 position;
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
    public void OnCreateProp()
    {
        SendNotification(EventsEnum.propCreate);
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
        list.Add(EventsEnum.propCreate);
        return list;
    }
    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
		case EventsEnum.monsterCreateMonsterSuccess:
                //Debug.Log(33333);
			IBlology monsterSpecies = (IBlology)notification.Body;
			//monsterSpecies.ID

			ReadTable temp_01 = ReadTable.getTable;

            GameObject monster = MemoryController.instance.OnFindMonsterByName(
                    temp_01.OnFind("monsterDate", monsterSpecies.ID.ToString(), "name"), monsterCreatePosition.position);
			SendNotification (EventsEnum.monsterCreateGameObject, monster);
			this.monster[monsterSpecies]= monster;
                break;
            case EventsEnum.monsterHPChange:
                Debug.Log(((float)notification.Body));
                break;
            case EventsEnum.monsterDie:
                
                //Debug.Log((IBlology)notification.Body);
                IBlology blology = (IBlology)notification.Body;
                GameObject temp = this.monster[blology];
                position = temp.transform.position;

                if (this.monster.ContainsKey(blology))
                {
                    this.monster.Remove(blology);
                }
                //this.monster.Remove((IBlology)notification.Body);

                temp.SetActive(false);
                MemoryController.instance.OnAddMonster(temp);
//                GameObject.Destroy(temp);
                //Debug.Log(((IBlology)notification.Body));
                break;
            case EventsEnum.propCreate:
                //IBlology propSpecies = (IBlology)notification.Body;
                //  ReadTable temp_01 = ReadTable.getTable;
                string prop_name = notification.Body.ToString();
                //生成道具
                GameObject prop = MemoryController.instance.OnFindPropByName(prop_name, position);
                MemoryController.instance.propInViewList.Add(prop);
//                GameObject.Instantiate(Resources.Load("Prop/"+prop_name), position, Quaternion.identity);
                break;


        }
    }
}
