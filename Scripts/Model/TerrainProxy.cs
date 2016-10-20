using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using System.Collections.Generic;

public class TerrainCreateInfor
{
    public ITerrain terrain;
    public Dictionary<float, GoldEnum> coin;
    public TerrainCreateInfor(ITerrain terrain, Dictionary<float, GoldEnum> coin)
    {
        this.terrain = terrain;
        this.coin = coin;
    }
}
public class TerrainProxy : Proxy {

    public new const string NAME = "terrainProxy";
    public ITerrain terrain;
    Queue<ITerrain> terrainQueue = new Queue<ITerrain>(3);
    public TerrainProxy() : base(NAME)
    {
    }
    public void OnCreateTerrain(TerrainEnum terrain,Dictionary<float,GoldEnum> coin)
    {
        ITerrain newTerrain = new OneTerrain();
        TerrainCreateInfor terrainCreateInfor = new TerrainCreateInfor(newTerrain, coin);
        SendNotification(EventsEnum.terrainCreateSuccess,terrainCreateInfor);
    }
}
