using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using PureMVC.Patterns;

public class TerrainCreateInfor
{
	private Dictionary<int,List<Coin>> terrainInfo;

	private int jellyEnum;

	public TerrainCreateInfor(Dictionary<int,List<Coin>> terrainInfo,int jellyEnum){

		this.terrainInfo = terrainInfo;

		this.jellyEnum = jellyEnum;
	}

	public Dictionary<int,List<Coin>> OnGetTerrainInfo(){
		
		return terrainInfo;

	}

	public int OnGetJellyEnum(){

		return jellyEnum;

	}
}

public class Coin{
	
	private float start;
	private float high;
	private string name;
	private float length;

	public Coin(float start,int kind,float high,float length){
		this.start = start;
		this.high = high;
		this.name = kind.ToString();
		this.length = length;
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

	public float OnGetLength(){
		return length;
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
	public void OnCreateTerrain(Dictionary<int,List<Coin>> terrainInfo,int jellyEnum)
    {
		
		TerrainCreateInfor terrainCreateInfor = new TerrainCreateInfor(terrainInfo,jellyEnum);

		SendNotification(EventsEnum.terrainCreateSuccess, terrainCreateInfor);

    }
}
