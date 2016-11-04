using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class pitDictionaryTool{
	
	public static List<string[]>  Parse(string temp_01){
		List<string[]> fin = new List<string[]> ();
		string[] temp_02 = temp_01.Split ('/');
		foreach (string item in temp_02) {
			string[] temp03 = item.Split (',');
			fin.Add (temp03);
		}
		return fin;
	}
}



public class TerrainCreate : SimpleCommand
{

    public new const string NAME = "TerrainCreate";

    public override void Execute(INotification notification)
    {
        //base.Execute(notification);

		int terrain=Random.Range(1, TerrainParameter.terrainEnumNum+1);
		List<Coin> coin = new List<Coin> ();

		ReadTable temp = ReadTable.getTable;

		List<string[]> tempCoin = pitDictionaryTool.Parse (temp.OnFind("terrainDate",terrain.ToString(),"noPitRoad"));

		foreach (string[] item in tempCoin)
        {
			for (float i = float.Parse (item [0]); i < float.Parse (item [1]) - TerrainParameter.coinBuffer; i = i + TerrainParameter.coinZone) {
	
				if (Random.Range(0, TerrainParameter.coinCreateDenominator) <= TerrainParameter.coinCreateNumerator)
				{
					Coin temp_02=new Coin(i,(int)Random.Range(1, TerrainParameter.coinEnumNum+1),float.Parse(item[2]));
					coin.Add (temp_02);
				}
			}
        }

        TerrainProxy proxy = (TerrainProxy)Facade.RetrieveProxy(TerrainProxy.NAME);
        proxy.OnCreateTerrain(terrain, coin);
    }
}
