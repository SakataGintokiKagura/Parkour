using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class MonsterInjured : SimpleCommand
{

    public new const string NAME = "MonsterInjured";

    public override void Execute(INotification notification)
    {
        base.Execute(notification);
    }
}
