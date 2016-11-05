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
		//player.HP -= 0;
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
            player.HP += 100;
            SendNotification(EventsEnum.playerHPChange, player);
            // ui.HP.fillAmount = ui.HP.fillAmount + ui.HP.fillAmount / 3;
        }
        else if (propName == "prop_MP(Clone)")
        {
            Debug.Log("prop_MP");
            //PLayerInformation player4 = (PLayerInformation)notification.Body;
            //Debug.Log(player2.HP);
            // ui.MP.fillAmount = ui.MP.fillAmount + ui.MP.fillAmount / 3;
            player.MP += 100;
            SendNotification(EventsEnum.playerUseSkillSuccess, player);
        }
        else if (propName == "prop_score(Clone)")
        {
            Debug.Log("prop_score");
            player.score+=100;
            SendNotification(EventsEnum.playerGetScoureSuccess, player);
        }
    }


}
