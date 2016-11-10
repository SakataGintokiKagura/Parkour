using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class PlayerPickUpProp : SimpleCommand
{

    public override void Execute(INotification notification)
    {
        PlayerProxy player = (PlayerProxy)Facade.RetrieveProxy(PlayerProxy.NAME);
        player.OnPickUpItem(((GameObject)notification.Body).name);
    }
}
