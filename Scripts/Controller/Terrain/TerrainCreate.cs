using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class pitDictionaryTool{
	public static Dictionary<float,float> Parse(string temp_01){
		Dictionary<float,float> fin = new Dictionary<float, float> ();
		string[] temp_02 = temp_01.Split ('/');
		foreach (string item in temp_02) {
			string[] temp03 = item.Split (',');
			fin.Add (float.Parse(temp03[0]),float.Parse(temp03[1]));
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
		Dictionary<float, int> coin = new Dictionary<float, int>();

		ReadTable temp = ReadTable.getTable;

		Dictionary<float, float> tempCoin = pitDictionaryTool.Parse (temp.OnFind("terrainDate",terrain.ToString(),"noPitRoad"));

        foreach (KeyValuePair<float, float> item in tempCoin)
        {
			
            for (float i = item.Key; i < item.Value - TerrainParameter.coinBuffer; i = i + TerrainParameter.coinZone)
            {
                if (Random.Range(0, TerrainParameter.coinCreateDenominator) <= TerrainParameter.coinCreateNumerator)
                {
					coin.Add(i, (int)Random.Range(1, TerrainParameter.coinEnumNum+1));
                }
            }
        }

        TerrainProxy proxy = (TerrainProxy)Facade.RetrieveProxy(TerrainProxy.NAME);
        proxy.OnCreateTerrain(terrain, coin);
    }
}
