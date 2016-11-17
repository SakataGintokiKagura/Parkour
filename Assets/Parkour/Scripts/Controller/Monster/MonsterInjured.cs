using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class MonsterInjured : SimpleCommand
{

    public const string NAME = "MonsterInjured";

    public override void Execute(INotification notification)
    {
        MonsterProxy monster = (MonsterProxy)Facade.RetrieveProxy(MonsterProxy.NAME);
        MonsterInjuredInfor temp = (MonsterInjuredInfor)notification.Body;
        monster.OnInjured(temp.monster, temp.skill.damage);
    }
}
