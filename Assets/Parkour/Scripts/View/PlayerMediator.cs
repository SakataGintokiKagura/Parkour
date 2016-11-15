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
	public UI ui;
    private static PlayerMediator playerMediator;
    private PlayerMediator():base(NAME)
    {
    }
    public static PlayerMediator OnGetPlayerMediator()
    {
        if (playerMediator == null)
			playerMediator = new PlayerMediator ();
        return playerMediator;
        
    }
    public void OnUseSkill(ISkill skill)
    {
        if (player.Isfly)
            return;
        if(PlayerState.Instance.sharedStates[0] == null)
        {
            if(PlayerState.Instance.singletonState is Run)
            {
                SendNotification(EventsEnum.playerUseSkill, skill);
            }
            else
            {
                if(skill is IEnbaleAirSkill)
                {
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
        list.Add(EventsEnum.playerFly);
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
            case EventsEnum.playerFly:
                player.OnFly(float.Parse(ReadTable.getTable.OnFind("propDate", "4", "prop")));
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
		MemoryController.instance.OnListAddObject(temp,MemoryParameter.PropPriority);
        SendNotification(EventsEnum.propPickUpProp,temp);
    }
}
