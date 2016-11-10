using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using System.Collections.Generic;
using PureMVC.Interfaces;
using System;
using NPlayerState;

public class PlayerMediator : Mediator,IPlayerMediator {
    public new const string NAME = "PlayerMediator";
    public Player player;
    private UI ui;
   // private PlayerProxy playerProxy;
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
        if (player.Isfly)
            return;
        if(PlayerState.Instance.sharedStates[0] == null)
        {
            if(PlayerState.Instance.singletonState is Run)
            {
                //player.OnStartSkill(skill);
                SendNotification(EventsEnum.playerUseSkill, skill);
            }
            else
            {
                if(skill is IEnbaleAirSkill)
                {
                    //player.OnStartSkill(skill);
                    SendNotification(EventsEnum.playerUseSkill, skill);
                }
            }
        }  
    }
    public void OnInjured(GameObject monster)
    {
        if (player.Isfly)
            return;
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
        list.Add(EventsEnum.propPickUpProp);
        list.Add(EventsEnum.playerInitizal);
        return list;
    }
    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case EventsEnum.playerDropOutNoDie:
                player.OnDropOut();

                break;
            case EventsEnum.playerUseSkillSuccess:
                if(notification.Body is PLayerInformation)
                {
                    PLayerInformation playerMp = (PLayerInformation)notification.Body;
                    ui.MP.fillAmount = (float)playerMp.MP / ui.MPInitizal;
                }
                else
                {
                    player.OnStartSkill((ISkill)notification.Body);
                }
                break;
            case EventsEnum.playerHPChange:
                PLayerInformation player2 = (PLayerInformation)notification.Body;
                //Debug.Log(player2.HP);
                ui.HP.fillAmount = (float)player2.HP / ui.HPInitizal;
                break;
            case EventsEnum.playerGetScoureSuccess:
                PLayerInformation playerScores = (PLayerInformation)notification.Body;
                ui.allCoin.text = "金币数： " + playerScores.score;
                break;
            case EventsEnum.playerDie:
                player.OnDie();
                break;
            case EventsEnum.playerInitizal:
                PLayerInformation playerTemp = (PLayerInformation)notification.Body;
                ui.HPInitizal = playerTemp.HP;
                ui.MPInitizal = playerTemp.MP;
                break;
        }
    }

    public void OnJump()
    {
        if (player.Isfly)
            return;
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

    public void OnPickUpProp(GameObject temp) {
		MemoryController.instance.OnListAddObject(temp,ReadTable.getTable.OnFind("memoryObjectParameter","1","priority"));
        SendNotification(EventsEnum.propPickUpProp,temp);
    }
}
