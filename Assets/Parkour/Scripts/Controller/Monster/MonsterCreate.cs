using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class MonsterCreate : SimpleCommand
{

    public const string NAME = "MonsterCreate";

    public override void Execute(INotification notification)
    {
        if (Random.Range(0, MonsterParameber.GeneratingprobabilityMax) < MonsterParameber.GeneratingprobabilityMin)
        {
            MonsterProxy monster = (MonsterProxy)Facade.RetrieveProxy(MonsterProxy.NAME);
            int a = Random.Range(1, MonsterParameber.SpeciesNumber + 1);
            if (a>5)
            {
                Debug.Log(111);
            }
            if (a == 6)
            {
                Debug.LogError("怪物不够");
            }
            monster.OnCreatMonster(a, 1);
        }
    }
}
