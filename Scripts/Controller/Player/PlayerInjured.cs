using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class playerInjured : SimpleCommand
{

    public new const string NAME = "PlayerInjured";

    public override void Execute(INotification notification)
    {
        base.Execute(notification);
    }
}
