using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using CammerState;
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

    public const string NAME = "TerrainCreate";

    public override void Execute(INotification notification)
    {
        //base.Execute(notification);
		Dictionary<int,List<Coin>> terrainInfo=new Dictionary<int, List<Coin>>();

		int jellyEnum = 0;

		AbsGameState gameState = GameStates.getInstance.singleGameState;

        AbsGameState gameState2 = GameStates.getInstance.shareGameStates[0];


		if (gameState is MidCammerState) {
			int terrain = Random.Range (1, 5);
			List<Coin> coin = createCoin (terrain,0);
			terrainInfo.Add (terrain,coin);
		}
		else if(gameState is FarCammerState){
			int terrain = Random.Range (8,11);
			List<Coin> coin = createCoin (terrain,40);
			terrainInfo.Add (terrain,coin);
		}
		else if(gameState is NearCammerState){
			int terrain = Random.Range (5,8);
			List<Coin> coin = createCoin (terrain,-40);
			terrainInfo.Add (terrain,coin);
		}

		if (Random.Range (0, 5) <= 2) {
			Debug.Log (GameStates.getInstance.singleGameState.ToString());
			if (gameState is MidCammerState) {
				if (Random.Range (0, 2) == 1) {
					jellyEnum = 1;
					int terrain = Random.Range (8, 11);
					List<Coin> coin = createCoin (terrain,40);
					terrainInfo.Add (terrain, coin);
				} else {
					jellyEnum = 2;
					int terrain = Random.Range (5,8);
					List<Coin> coin = createCoin (terrain,-40);
					terrainInfo.Add (terrain,coin);
				}


			}
			else if(gameState is FarCammerState){
				jellyEnum = 3;
				int terrain = Random.Range (1, 5);
				List<Coin> coin = createCoin (terrain,0);
				terrainInfo.Add (terrain,coin);
			}
			else if(gameState is NearCammerState&&gameState2 is WithOutBossState ){
				jellyEnum = 4;
				int terrain = Random.Range (1, 5);
				List<Coin> coin = createCoin (terrain,0);
				terrainInfo.Add (terrain,coin);
			}
		}

        TerrainProxy proxy = (TerrainProxy)Facade.RetrieveProxy(TerrainProxy.NAME);

		proxy.OnCreateTerrain(terrainInfo, jellyEnum);

    }

	private List<Coin> createCoin(int terrain,float length){
		List<Coin> fin = new List<Coin> ();
		ReadTable temp = ReadTable.getTable;
		List<string[]> tempCoin = pitDictionaryTool.Parse (temp.OnFind("terrainDate",terrain.ToString(),"noPitRoad"));

		foreach (string[] item in tempCoin)
		{
			for (float i = float.Parse (item [0]); i < float.Parse (item [1]) ; i = i + TerrainParameter.coinZone) {//+ TerrainParameter.coinBuffer

				if (Random.Range(0, TerrainParameter.coinCreateDenominator) <= TerrainParameter.coinCreateNumerator)
				{
					Coin temp_02=new Coin(i,(int)Random.Range(1, TerrainParameter.coinEnumNum+1),float.Parse(item[2]),length);
					fin.Add (temp_02);
				}
			}
		}

		return fin;
	}

}
