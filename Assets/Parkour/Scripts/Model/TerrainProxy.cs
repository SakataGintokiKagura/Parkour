using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using PureMVC.Patterns;

public class TerrainCreateInfor
{
	private List<Coin> coin;
	private string name;
	public TerrainCreateInfor(int terrain, List<Coin> coin)
    {
        this.coin = coin;
		this.name = terrain.ToString();
    }

	public List<Coin> OnGetCoin()
    {
        return coin;
    }

	public string OnGetName(){
		return name;
	}
}

public class Coin{
	
	private float start;
	private float high;
	private string name;

	public Coin(float start,int kind,float high){
		this.start = start;
		this.high = high;
		this.name = kind.ToString();
	}

	public float OnGetStart(){
		return start;
	}

	public float OnGetHigh(){
		return high;
	}

	public string OnGetName(){
		return name;
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
