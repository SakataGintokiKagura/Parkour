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
		}
    }

    public void OnInjured(GameObject game)
    { 
		//判断哪个怪
		IBlology monster = MonsterProxy.AllMonster.TryGetValue(game);
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
    //public void OnPickUpItem(int value)
    //{
    //    SendNotification(EventsEnum.playerPickUpItem);   
    //}
}
