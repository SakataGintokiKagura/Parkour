using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using PureMVC.Patterns;
using System.Collections.Generic;

public class TerrainCreateInfor
{
    private int terrain;
	private List<Coin> coin;
	public TerrainCreateInfor(int terrain, List<Coin> coin)
    {
        this.terrain = terrain;
        this.coin = coin;
    }

	public List<Coin> OnGetCoin()
    {
        return coin;
    }

	public int OnGetTerrain()
	{
		return terrain;
	}
}

public class Coin{
	
	private float start;
	private int kind;
	private float high;

	public Coin(float start,int kind,float high){
		this.start = start;
		this.kind = kind;
		this.high = high;
	}

	public float OnGetStart(){
		return start;
	}

	public int OnGetKind(){
		return kind;
	}

	public float OnGetHigh(){
		return high;
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
	public void OnCreateTerrain(int terrain, List<Coin> coin)
    {
		
        TerrainCreateInfor terrainCreateInfor = new TerrainCreateInfor(terrain, coin);

		SendNotification(EventsEnum.terrainCreateSuccess, terrainCreateInfor);

    }
}
