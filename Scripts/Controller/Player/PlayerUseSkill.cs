using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class PlayerUseSkill : SimpleCommand {
    public new const string NAME = "PlayerUseSkill";

    public override void Execute(INotification notification)
    {
        PlayerProxy player = (PlayerProxy)Facade.RetrieveProxy(PlayerProxy.NAME);
        ISkill temp = (ISkill)notification.Body;
        if (player.player.MP > temp.MP)
        {
            player.OnUseSkill(temp);
        }     
    }
}
