using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class MonsterDestroy : SimpleCommand
{

    public new const string NAME = "MonsterDestroy";

    public override void Execute(INotification notification)
    {
        MonsterProxy monster = (MonsterProxy)Facade.RetrieveProxy(MonsterProxy.NAME);
        GameObject temp = (GameObject)notification.Body;
        monster.OnDestroy(temp);
    }
}
