using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class PropDestroy : SimpleCommand
{

    public new const string NAME_Prop = "PropDestroy";

    public override void Execute(INotification notification)
    {
       /// MonsterProxy prop = (MonsterProxy)Facade.RetrieveProxy(MonsterProxy.NAME);
      //  GameObject temp = (GameObject)notification.Body;
      //  prop.OnDestroy(temp);
    }
}
