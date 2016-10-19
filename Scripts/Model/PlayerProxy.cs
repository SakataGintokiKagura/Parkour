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
        SendNotification(EventsEnum.playerUseSkillSuccess,skill);
    }
    public void OnInjured(GameObject game)
    { 
        SendNotification(EventsEnum.playerHPChange,player);
    }
    public void OnGetScoure(int scoure)
    {
        SendNotification(EventsEnum.playerGetScoureSuccess,player);
    }
    private void OnDie()
    {
        SendNotification(EventsEnum.playerDie);
    }
    public void OnDropOutPit()
    {
        SendNotification(EventsEnum.playerDropOutNoDie,player);
    }
    //public void OnPickUpItem(int value)
    //{
    //    SendNotification(EventsEnum.playerPickUpItem);   
    //}
}
