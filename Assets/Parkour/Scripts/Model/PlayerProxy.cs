using System;
using UnityEngine;
using System.Collections;
using PureMVC.Patterns;

public class PlayerProxy : Proxy {
    private UI ui;

    public new const string NAME = "PlayerProxy";
    public PLayerInformation player { get; set; }
    public PlayerProxy() : base(NAME)
    {
        player = new PLayerInformation();
        SendNotification(EventsEnum.playerInitizal,player);
    }
    public void OnUseSkill(ISkill skill)
    {
		//技能
		if(skill.MP<player.MP){
			player.MP -= skill.MP;
			SendNotification(EventsEnum.playerUseSkillSuccess,skill);
            SendNotification(EventsEnum.playerUseSkillSuccess, player);
		}
    }
    public void OnInjured(GameObject game)
    {
        //判断哪个怪
        IBlology monster = MonsterProxy.AllMONSTER[game];

		//player.HP -= monster.damage;
        SendNotification(EventsEnum.playerHPChange,player);

		if(player.HP<=0){
			OnDie ();
		}
    }
    private void OnDie()
    {
		SendNotification(EventsEnum.playerDie);

    }
    public void OnGetScoure(int scoure)
    {
       // Debug.Log(22222);
        player.score += scoure;
        SendNotification(EventsEnum.playerGetScoureSuccess,player);
    }
    public void OnDropOutPit()
    {

        //player.HP -= SkillParameber.dropOutHurt;

        SendNotification(EventsEnum.playerHPChange, player);
        //SendNotification(EventsEnum.playerDropOutNoDie, player);
        if (player.HP <= 0)
        {
            OnDie();
        }
         SendNotification(EventsEnum.playerDropOutNoDie, player);
    }
  
    public void OnPickUpItem(string propName)
    {
        if (propName == "prop_HP(Clone)")
        {
            Debug.Log("PROP_hp");
//            player.HP += 100;
            player.HP += Int32.Parse(ReadTable.getTable.OnFind("propDate", "1", "priority"));
            SendNotification(EventsEnum.playerHPChange, player);
            // ui.HP.fillAmount = ui.HP.fillAmount + ui.HP.fillAmount / 3;
        }
        else if (propName == "prop_MP(Clone)")
        {
            Debug.Log("prop_MP");
//            player.MP += 100;
            player.MP += Int32.Parse(ReadTable.getTable.OnFind("propDate", "2", "priority"));
            SendNotification(EventsEnum.playerUseSkillSuccess, player);
        }
        else if (propName == "prop_score(Clone)")
        {
            Debug.Log("prop_score");
//            player.score+=100;
            player.score+= Int32.Parse(ReadTable.getTable.OnFind("propDate", "3", "priority"));
            SendNotification(EventsEnum.playerGetScoureSuccess, player);
        }else if (propName == "prop_fly(Clone)")
        {
            Debug.Log("prop_fly");
            SendNotification(EventsEnum.playerFly, float.Parse(ReadTable.getTable.OnFind("propDate", "4", "priority")));
        }
    }


}
