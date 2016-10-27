using UnityEngine;
using System.Collections;
using PureMVC.Patterns;

public class PlayerProxy : Proxy {
    public new const string NAME = "PlayerProxy";
    public PLayerInformation player { get; set; }
    public PlayerProxy() : base(NAME)
    {
        player = new PLayerInformation();
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
        //player.HP -= 100;
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
    //public void OnPickUpItem(int value)
    //{
    //    SendNotification(EventsEnum.playerPickUpItem);
    //}
}
