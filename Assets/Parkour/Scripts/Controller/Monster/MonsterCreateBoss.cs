using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using System.Collections;

public class MonsterCreateBoss : SimpleCommand {

	public new const string NAME = "MonsterCreateBoss";

	public override void Execute(INotification notification)
	{
//		MonsterProxy monster = (MonsterProxy)Facade.RetrieveProxy(MonsterProxy.NAME);
//		monster.OnCreateBoss (1);
	}
}
