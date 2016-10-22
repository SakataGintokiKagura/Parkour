using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class playerInjured : SimpleCommand
{


    public new const string NAME = "PlayerInjured";

    public override void Execute(INotification notification)
    {
        PlayerProxy player = (PlayerProxy)Facade.RetrieveProxy(PlayerProxy.NAME);
        //MonsterProxy monster = (MonsterProxy)Facade.RetrieveProxy(MonsterProxy.NAME);
        GameObject temp = (GameObject)notification.Body;
        //float hurt = monster.monster[temp].damage;
        player.OnInjured(temp);
    }
}
