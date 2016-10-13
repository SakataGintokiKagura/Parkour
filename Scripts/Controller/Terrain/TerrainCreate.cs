using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class TerrainCreate : SimpleCommand
{

    public new const string NAME = "TerrainCreate";

    public override void Execute(INotification notification)
    {
        base.Execute(notification);
    }
}
