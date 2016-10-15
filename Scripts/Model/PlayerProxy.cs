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
        SendNotification(EventsEnum.playerDie);
    }
    //public void OnPickUpItem(int value)
    //{
    //    SendNotification(EventsEnum.playerPickUpItem);   
    //}
}
