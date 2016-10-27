using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;
//using System;

public class PropCreate : SimpleCommand
{
    public new const string prop = "propCreate";
    public override void Execute(INotification notification)
    {
            //MonsterProxy monster = (MonsterProxy)Facade.RetrieveProxy(MonsterProxy.NAME);
            //monster.OnCreatMonster(Random.Range(1, MonsterParameber.SpeciesNumber + 1), 1);

    }
}