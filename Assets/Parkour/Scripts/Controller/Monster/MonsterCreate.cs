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
            monster.OnCreatMonster(Random.Range(1, MonsterParameber.SpeciesNumber+1), 1);
        }
    }
}
