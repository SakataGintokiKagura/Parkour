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
    private Vector3 position;
	public Vector3 monsterCreatePosition;
    private static MonsterMediator monsterMediator;
    private Queue<IBlology> blology = new Queue<IBlology>();

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

			IBlology monsterSpecies = (IBlology)notification.Body;

			ReadTable temp_01 = ReadTable.getTable;

            GameObject monster=
			MemoryController.instance.OnFindGameObjectByName(    
				temp_01.OnFind("monsterDate", monsterSpecies.ID.ToString(), "name"),
				monsterCreatePosition,
				MemoryParameter.MonsterPriority,
				temp_01.OnFind("monsterDate", monsterSpecies.ID.ToString(), "path"),
				temp_01.OnFind("monsterDate", monsterSpecies.ID.ToString(), "load"),
				monsterSpecies.ID.ToString(),
				new ReturnObject(OnAddMonster)
			);
                // this.blology.Enqueue(monsterSpecies);
                if (monster == null)
                {
                    this.blology.Enqueue(monsterSpecies);
                }
                else
                {
                    SendNotification(EventsEnum.monsterCreateGameObject, monster);
                    this.monster[monsterSpecies] = monster;
                }

                break;
            case EventsEnum.monsterHPChange:
                Debug.Log(((int)notification.Body));
                break;
		    case EventsEnum.monsterDie:     
			    IBlology blology = (IBlology)notification.Body;
			    GameObject temp = this.monster [blology];
			    position = temp.transform.position;
			    if (this.monster.ContainsKey (blology)) {
				        this.monster.Remove (blology);
			    }
			MemoryController.instance.OnListAddObject (temp,MemoryParameter.MonsterPriority);    
			    break;
           
		    case EventsEnum.propCreate:
                Debug.Log("生成道具");
			    string id = notification.Body.ToString ();
            
			    ReadTable reatable = ReadTable.getTable;

			    GameObject prop = MemoryController.instance.OnFindGameObjectByName (
				    reatable.OnFind("propDate", id,"name"),
				    position,  
				    MemoryParameter.PropPriority, 
				    reatable.OnFind("propDate", id,"path"),
				    reatable.OnFind("propDate", id,"load"),
				    id,
				    new ReturnObject(MemoryController.instance.emptyDelegate)
			    );
                //下面的话注释掉，要不然不能生成道具
			    //MemoryController.instance.OnListAddObject (prop,ReadTable.getTable.OnFind("memoryObjectParameter","1","priority")); 

			    break;
        }
    }

    public void OnCreateBoss()
    {
        SendNotification(EventsEnum.monsterCreateBoss);
    }
    public void OnAddMonster(GameObject monster)
    {
        if (monster.name == "100")
        {
            string temp = ReadTable.getTable.OnFind("bossDate", UnityEngine.Random.Range(1, 4).ToString(), "classname");
            monster.AddComponent(Type.GetType(temp));
        }
        SendNotification(EventsEnum.monsterCreateGameObject, monster);
        this.monster[blology.Dequeue()]= monster;
    }
}
