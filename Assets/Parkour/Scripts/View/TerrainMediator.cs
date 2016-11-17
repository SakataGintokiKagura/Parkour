using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using System.Collections.Generic;

public class TerrainMediator : Mediator, ITerrainMediator{

	public new const string NAME = "TerrainMediator";
		
	public Terrain terrain;
	    
	private static TerrainMediator terrainMediator;

	private Queue<GameObject>  oldJelly = new Queue<GameObject> ();
		
	private List<GameObject>  newTerrainList = new List<GameObject> ();

	private List<GameObject>  newCoinList = new List<GameObject> ();

	private Queue<List<GameObject>> oldTerrain = new Queue<List<GameObject>>();
	  
	private Queue<List<GameObject>> oldCoin = new Queue<List<GameObject>>();
	    
	private TerrainMediator() : base(NAME){
	    
	}
	    
	public static TerrainMediator OnGetTerrainMediator(){
	        
		if (terrainMediator == null){
				
			terrainMediator = new TerrainMediator ();
	            
			return terrainMediator;
	        
		}    
		else{
	            
			return terrainMediator;
	        
		}
	    
	}
	    
	public void OnCreateTerrain(){
	        
		SendNotification(EventsEnum.terrainCreate);
	    
	}
	    
	public override IList<string> ListNotificationInterests(){
	        
		IList<string> list = new List<string>();
	        
		list.Add(EventsEnum.terrainCreateSuccess);
	       
		return list;
	    
	}

	    
	public override void HandleNotification(INotification notification){
			
		switch (notification.Name){

			
		case EventsEnum.terrainCreateSuccess:
				
				
			TerrainCreateInfor infor = notification.Body as TerrainCreateInfor;
	               
				
			ReadTable temp = ReadTable.getTable;

			GameObject newJelly = null;

			if (infor.OnGetJellyEnum () != 0) {
				newJelly = MemoryController.instance.OnFindGameObjectByName (
					                      
					temp.OnFind ("JellyDate", infor.OnGetJellyEnum ().ToString (), "Name"),
					                      
					7,
					                      
					temp.OnFind ("JellyDate", infor.OnGetJellyEnum ().ToString (), "Path"),
					                      
					infor.OnGetJellyEnum ().ToString ()
				                      
				);

				newJelly.transform.position = new Vector3 (
					(terrain.getN ()+1) * TerrainParameter.mapSize-3,
					newJelly.transform.position.y+0.2f,
					newJelly.transform.position.z
				);
			} 

			Dictionary<int,List<Coin>> terrainInfo = infor.OnGetTerrainInfo ();

			foreach (KeyValuePair<int,List<Coin>> item in terrainInfo) {
				
				GameObject newTerrain = MemoryController.instance.OnFindGameObjectByName (
					                        temp.OnFind ("terrainDate", item.Key.ToString (), "terrainName"),
					                        MemoryParameter.TerrainPriority,
					                        temp.OnFind ("terrainDate", item.Key.ToString (), "path"),
					                        item.Key.ToString ()
				                        );

				newTerrain.transform.position = new Vector3 (
					(terrain.getN () + 1) * TerrainParameter.mapSize,
					newTerrain.transform.position.y,
					newTerrain.transform.position.z
				);

				newTerrainList.Add (newTerrain);

				foreach (Coin coin in item.Value) {
					
					GameObject CoinTemp = MemoryController.instance.OnFindGameObjectByName (
						                      temp.OnFind ("coinDate", coin.OnGetName (), "name"), 
						                      MemoryParameter.CoinsPriority,
						                      temp.OnFind ("coinDate", coin.OnGetName (), "path"),
						                      coin.OnGetName ()
					                      );

					CoinTemp.SetActiveRecursively (true);

					CoinTemp.transform.position = new Vector3 (
						coin.OnGetStart () + (terrain.getN () + 1) * TerrainParameter.mapSize,
						coin.OnGetHigh (),
						coin.OnGetLength ()
					);
					newCoinList.Add (CoinTemp);
				}
		
			}

			oldTerrain.Enqueue (newTerrainList);

			oldCoin.Enqueue (newCoinList);

			newTerrainList = new List<GameObject> ();

			newCoinList = new List<GameObject> ();


			if (terrain.getN () >= 2) {

				if (oldJelly.Count != 0) {
					GameObject clearJelly = oldJelly.Dequeue ();
					MemoryController.instance.OnListAddObject (clearJelly, 7);
				}

				if (newJelly != null) 
					oldJelly.Enqueue (newJelly);

				List<GameObject> clearTerrain = oldTerrain.Dequeue ();
				foreach(GameObject item in clearTerrain){
					if(item)
					MemoryController.instance.OnListAddObject (item,MemoryParameter.TerrainPriority);
				}
				List<GameObject> clearCoin = oldCoin.Dequeue ();
				foreach(GameObject item in clearCoin){
					if(item)
					MemoryController.instance.OnListAddObject (item,MemoryParameter.CoinsPriority);
				}
					
			}

	
	          
			break;
	            
		default:
   
			break;
	        
		}   
	    
	}

}