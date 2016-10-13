using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using System.Collections.Generic;

public class TerrainMediator : Mediator,ITerrainMediator {

    public new const string NAME = "TerrainMediator";
    private Terrain terrain;
    public TerrainMediator(Terrain terrain) : base(NAME)
    {
        this.terrain = terrain;
        terrain.OnSetTerrain(this);
    }
    public void OnCreateTerrain()
    {
        SendNotification(EventsEnum.terrainCreate);
    }
    public override IList<string> ListNotificationInterests()
    {
        IList<string> list = new List<string>();
        list.Add(EventsEnum.terrainCreateSuccess);
        return list;
    }
    public override void HandleNotification(INotification notification)
    {
        base.HandleNotification(notification);
    }
}