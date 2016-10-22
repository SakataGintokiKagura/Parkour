﻿using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using System.Collections.Generic;
/// <summary>
/// name 朱科锦
/// 地形相关的数据处理
/// </summary>
public class TerrainCreateInfor
{
    public ITerrain terrain;
    public Dictionary<float, GoldEnum> coin;
    public TerrainCreateInfor(ITerrain terrain, Dictionary<float, GoldEnum> coin)
    {
        this.terrain = terrain;
        this.coin = coin;
    }

    public Dictionary<float, GoldEnum> OnGetCoin()
    {
        return coin;
    }
}

public class TerrainProxy : Proxy
{

    public new const string NAME = "terrainProxy";
    public ITerrain terrain;
    Queue<ITerrain> terrainQueue = new Queue<ITerrain>(2);
    public TerrainProxy() : base(NAME)
    {
    }
	/// <summary>
	/// 生成地形与金币
	/// </summary>
	/// <param name="terrain">Terrain.</param>
	/// <param name="coin">Coin.</param>
    public void OnCreateTerrain(TerrainEnum terrain, Dictionary<float, GoldEnum> coin)
    {
        TerrainCreateInfor terrainCreateInfor;
        switch (terrain)
        {
            case TerrainEnum.One:
                terrainCreateInfor = new TerrainCreateInfor(new OneTerrain(), coin);
                SendNotification(EventsEnum.terrainCreateSuccess, terrainCreateInfor);
                break;
            case TerrainEnum.Two:
                terrainCreateInfor = new TerrainCreateInfor(new TwoTerrain(), coin);
                SendNotification(EventsEnum.terrainCreateSuccess, terrainCreateInfor);
                break;
            case TerrainEnum.Three:
                terrainCreateInfor = new TerrainCreateInfor(new ThreeTerrain(), coin);
                SendNotification(EventsEnum.terrainCreateSuccess, terrainCreateInfor);
                break;
            default:
                break;
        }
    }
}
