﻿using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class PlayerGetSource : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        PlayerProxy player = (PlayerProxy)Facade.RetrieveProxy(PlayerProxy.NAME);
        int temp = (int)notification.Body;
        player.OnGetScoure(temp);
    }

}
