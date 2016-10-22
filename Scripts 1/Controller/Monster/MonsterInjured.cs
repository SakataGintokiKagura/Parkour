using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;
/// <summary>
/// 唐耀 怪物受伤
/// </summary>
public class MonsterInjured : SimpleCommand
{

    public new const string NAME = "MonsterInjured";

    public override void Execute(INotification notification)
    {
        MonsterProxy monster = (MonsterProxy)Facade.RetrieveProxy(MonsterProxy.NAME);
        MonsterInjuredInfor temp = (MonsterInjuredInfor)notification.Body;
        monster.OnInjured(temp.monster, temp.skill.damage);
    }
}
