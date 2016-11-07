using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using PureMVC.Patterns;
using System.Collections.Generic;

public class TerrainCreateInfor
{
    private int terrain;
    private Dictionary<float, int> coin;
    public TerrainCreateInfor(int terrain, Dictionary<float, int> coin)
    {
        this.terrain = terrain;
        this.coin = coin;
    }

    public Dictionary<float, int> OnGetCoin()
    {
        return coin;
    }

	public int OnGetTerrain()
	{
		return terrain;
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
    public void OnCreateTerrain(int terrain, Dictionary<float,int> coin)
    {
		
        TerrainCreateInfor terrainCreateInfor = new TerrainCreateInfor(terrain, coin);

		SendNotification(EventsEnum.terrainCreateSuccess, terrainCreateInfor);

    }
}
