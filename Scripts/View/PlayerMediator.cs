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
        if(PlayerState.Instance.skillState is Run)
        {
            if(PlayerState.Instance.jumpState is Run)
            {
                player.OnStartSkill(skill);
                //SendNotification(EventsEnum.playerUseSkill, skill);
            }
            else
            {
                if(skill is IEnbaleAirSkill)
                {
                    player.OnStartSkill(skill);
                    //SendNotification(EventsEnum.playerUseSkill, skill);
                }
            }
        }  
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
        list.Add(EventsEnum.playerGetScoureSuccess);
        list.Add(EventsEnum.playerDropOutNoDie);
        return list;
    }
    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case EventsEnum.playerDropOutNoDie:
                player.OnDropOut();
                break;
        }
    }

    public void OnJump()
    {
        player.OnJump();
    }
    public void OnGetScoure(int scoure)
    {
        SendNotification(EventsEnum.playerGetScoure, scoure);
    }
    public void OnDropOutPit()
    {
        SendNotification(EventsEnum.playerDropOutPit);
    }
}
