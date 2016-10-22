using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
/// <summary>
/// name 朱科锦
/// 完成有关玩家角色的各种信息处理
/// </summary>
public class PlayerProxy : Proxy {
    public new const string NAME = "PlayerProxy";
    public PLayerInformation player { get; set; }
    public PlayerProxy() : base(NAME)
    {
        player = new PLayerInformation();
    }
	/// <summary>
	/// 当人物释放技能时，判断能否释放，之后传输数据
	/// </summary>
	/// <param name="skill">Skill.</param>
    public void OnUseSkill(ISkill skill)
    {
		if(skill.MP<player.MP){
			player.MP -= skill.MP;
			SendNotification(EventsEnum.playerUseSkillSuccess,skill);
            SendNotification(EventsEnum.playerUseSkillSuccess, player);
		}
    }
	/// <summary>
	/// 受伤数据传输，判断被哪只怪物伤害，改变player的HP，当HP小于等于0，人物死亡
	/// </summary>
	/// <param name="game">Game.</param>
    public void OnInjured(GameObject game)
    {
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
