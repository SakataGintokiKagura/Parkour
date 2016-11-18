using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using System.Collections;
using CammerState;
public class MonsterCreateBoss : SimpleCommand {

	public const string NAME = "MonsterCreateBoss";
    GameStates gameStates = GameStates.getInstance;
	public override void Execute(INotification notification)
	{
        MonsterProxy monster = (MonsterProxy)Facade.RetrieveProxy(MonsterProxy.NAME);
        ReadTable table = ReadTable.getTable;
        int num = int.Parse(table.OnFind("monsterParameber", "14", "Value"));
        int GeneratingprobabilityMax = int.Parse(table.OnFind("monsterParameber", "15", "Value"));
        int GeneratingprobabilityMin = int.Parse(table.OnFind("monsterParameber", "16", "Value"));
        if (Random.Range(0,GeneratingprobabilityMax*3) <GeneratingprobabilityMin)
        {
            int temp = Random.Range(1, num);
            monster.OnCreateBoss(temp);
            gameStates.OnCreateBoss();
        }
       
    }
}
