using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using System.Collections.Generic;
/// <summary>
/// name朱科锦 
/// 构造onsterProxy类，处理怪物相关数据
/// </summary>
public class MonsterProxy : Proxy {
    public new const string NAME = "MonsterProxy";
	/// <summary>
	/// All monster.怪物用一个字典类存储
	/// </summary>
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
	/// <summary>
	/// 判断是哪种怪物，然后创造怪物
	/// </summary>
	/// <param name="monster">Monster.</param>
	/// <param name="time">Time.</param>
    public void OnCreatMonster(MonsterEnum monster,float time)
    {
        IBlology temp = new ChomperInformation(time);
		switch(monster){
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
	/// <summary>
	/// Raises the injured event.传递怪物受伤信息，当怪物HP降到0或以下传递死亡信息
	/// </summary>
	/// <param name="monster">Monster.</param>
	/// <param name="hurt">Hurt.</param>
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
	/// <summary>
	/// Raises the die event.怪物死亡 
	/// </summary>
	/// <param name="monster">Monster.</param>
    private void OnDie(IBlology monster)
    {
        
        SendNotification(EventsEnum.monsterDie, monster);
        
    }
	/// <summary>
	/// 当怪物移出屏幕时销毁
	/// </summary>
	/// <param name="monster">Monster.</param>
    public void OnDestroy(GameObject monster)
    {
		SendNotification(EventsEnum.monsterDie, AllMonster[monster]);
		AllMonster.Remove(monster);
    }
}