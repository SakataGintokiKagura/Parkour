using PureMVC.Patterns;
using PureMVC.Interfaces;
using UnityEngine;
/// <summary>
/// 唐耀 同步数据
/// </summary>
class MonsterCreateGameObject : SimpleCommand
{

    public new const string NAME = "MonsterCreateGameObject";

    public override void Execute(INotification notification)
    {
        MonsterProxy monster = (MonsterProxy)Facade.RetrieveProxy(MonsterProxy.NAME);
		//Debug.Log (notification.Body);
        monster.OnGetMonster((GameObject)notification.Body);
    }
}
