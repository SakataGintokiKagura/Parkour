using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class MonsterCreate : SimpleCommand
{

    public new const string NAME = "MonsterCreate";

    public override void Execute(INotification notification)
    {
        base.Execute(notification);

    }
}
