using PureMVC.Patterns;
using PureMVC.Interfaces;
using UnityEngine;

class MonsterCreateGameObject : SimpleCommand
{

    public const string NAME = "MonsterCreateGameObject";

    public override void Execute(INotification notification)
    {
        MonsterProxy monster = (MonsterProxy)Facade.RetrieveProxy(MonsterProxy.NAME);
        monster.OnGetMonster((GameObject)notification.Body);
    }
}
