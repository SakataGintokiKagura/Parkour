using UnityEngine;
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
    }
    /// <summary>
    /// view层创造的怪物传给后台
    /// </summary>
    private void OnGetMonster()
    {
        SendNotification(EventsEnum.monsterCreateGameObject);
    }
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
    public override void HandleNotification(INotification notification)
    {
        base.HandleNotification(notification);
    }
}
