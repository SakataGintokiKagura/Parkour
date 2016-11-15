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

		player.HP -= monster.damage;
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

        player.HP -= SkillParameber.dropOutHurt;

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
        ReadTable table = ReadTable.getTable;
        string result = table.OnFind("propDate", propName, "property");
        string value = table.OnFind("propDate", propName, "prop");
        if (result.Contains("HP"))
        {
<<<<<<< HEAD
            player.HP += Int32.Parse(ReadTable.getTable.OnFind("propDate", "1", "prop"));
            SendNotification(EventsEnum.playerHPChange, player);
        }
        else if (propName == "prop_MP(Clone)")
        {
            player.MP += Int32.Parse(ReadTable.getTable.OnFind("propDate", "2", "prop"));
=======
            player.HP += int.Parse(value);
            SendNotification(EventsEnum.playerHPChange, player);
        }else if (result.Contains("MP"))
        {
            player.MP += int.Parse(value);
>>>>>>> origin/dev
            SendNotification(EventsEnum.playerUseSkillSuccess, player);
        }else if (result.Contains("Scoure"))
        {
<<<<<<< HEAD
            player.score+= Int32.Parse(ReadTable.getTable.OnFind("propDate", "3", "prop"));
=======
            player.score += int.Parse(value);
>>>>>>> origin/dev
            SendNotification(EventsEnum.playerGetScoureSuccess, player);
        }else if (result.Contains("Fly"))
        {
            SendNotification(EventsEnum.playerFly, float.Parse(value));
        }
}


}
