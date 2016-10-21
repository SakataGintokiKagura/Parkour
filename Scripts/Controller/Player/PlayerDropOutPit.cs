using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;
/// <summary>
/// 唐耀 人掉坑
/// </summary>
public class PlayerDropOutPit : SimpleCommand {

    public override void Execute(INotification notification)
    {
        PlayerProxy player = (PlayerProxy)Facade.RetrieveProxy(PlayerProxy.NAME);

        player.OnDropOutPit();
    }
}
