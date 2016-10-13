using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using System.Collections.Generic;

public class TerrainProxy : Proxy {

    public new const string NAME = "terrainProxy";
    public ITerrain terrain;
    Queue<ITerrain> terrainQueue = new Queue<ITerrain>(2);
    public TerrainProxy() : base(NAME)
    {
    }
    public void OnCreateTerrain(TerrainEnum terrain)
    {
        ITerrain newTerrain = new OneTerrain();
        SendNotification(EventsEnum.terrainCreateSuccess,newTerrain);
    }
}
