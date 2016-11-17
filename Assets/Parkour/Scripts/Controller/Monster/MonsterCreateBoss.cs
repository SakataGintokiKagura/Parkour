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
        if (true)
        {
            int temp = Random.Range(1, 3);
            if (temp == 2)
            {
                gameStates.OnCreateMonster();
            }
            monster.OnCreateBoss(temp);
            gameStates.OnCreateBoss();
        }
       
    }
}
