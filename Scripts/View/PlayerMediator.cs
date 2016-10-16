using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using System.Collections.Generic;
using PureMVC.Interfaces;
using System;

public class PlayerMediator : Mediator,IPlayerMediator {
    public new const string NAME = "PlayerMediator";
    private Player player;
    private UI ui;
    private static PlayerMediator playerMediator;
    private PlayerMediator(Player player,UI ui):base(NAME)
    {
        this.player = player;
        this.ui = ui;
        player.OnSetPlayerMediator(this);
        ui.OnSetPlayerMediator(this);
    }
    public static PlayerMediator OnGetPlayerMediator(Player player, UI ui)
    {
        if (playerMediator == null)
        {
            playerMediator = new PlayerMediator(player, ui);
            return playerMediator;
        }
        else
        {
            return playerMediator;
        }
    }
    public static PlayerMediator OnGetPlayerMediator()
    {
        if (playerMediator == null)
        {
            Debug.Log("playerMediator为空");
            return playerMediator;
        }
        else
        {
            return playerMediator;
        }
    }
    public void OnUseSkill(ISkill skill)
    {
        player.OnSetSkill(skill);
        SendNotification(EventsEnum.playerUseSkill,skill);
    }
    public void OnInjured(GameObject monster)
    {
        SendNotification(EventsEnum.playerInjured, monster);
    }
    public override IList<string> ListNotificationInterests()
    {
        IList<string> list = new List<string>();
        list.Add(EventsEnum.playerUseSkillSuccess);
        list.Add(EventsEnum.playerHPChange);
        list.Add(EventsEnum.playerDie);
        return list;
    }
    public override void HandleNotification(INotification notification)
    {
        base.HandleNotification(notification);
        
    }

    public void OnJump()
    {
        player.OnJump();
    }
}
