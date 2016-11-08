using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using System.Collections.Generic;

public class TerrainMediator : Mediator, ITerrainMediator
{

    public new const string NAME = "TerrainMediator";
    private Terrain terrain;
    private static TerrainMediator terrainMediator;
	private Vector3 lastPosition;
	private List<GameObject> newCoinList = new List<GameObject> ();

    private Queue<GameObject> oldTerrain = new Queue<GameObject>();
    private Queue<List<GameObject>> oldCoin = new Queue<List<GameObject>>();

    private TerrainMediator(Terrain terrain) : base(NAME)
    {
        this.terrain = terrain;
        terrain.OnSetTerrain(this);
    }
    public static TerrainMediator OnGetTerrainMediator(Terrain terrain)
    {
        if (terrainMediator == null)
        {
            terrainMediator = new TerrainMediator(terrain);
            return terrainMediator;
        }
        else
        {
            return terrainMediator;
        }
    }
    public static TerrainMediator OnGetTerrainMediator()
    {
        if (terrainMediator == null)
        {
            Debug.Log("terrainMediator为空");
            return terrainMediator;
        }
        else
        {
            return terrainMediator;
        }
    }
    public void OnCreateTerrain()
    {
        SendNotification(EventsEnum.terrainCreate);
    }
    public override IList<string> ListNotificationInterests()
    {
        IList<string> list = new List<string>();
        list.Add(EventsEnum.terrainCreateSuccess);
        return list;
    }
    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name){  
		case EventsEnum.terrainCreateSuccess:
                
			TerrainCreateInfor infor = notification.Body as TerrainCreateInfor;

			ReadTable temp = ReadTable.getTable;

			GameObject newTerrain = MemoryController.instance.OnFindGameObjectByName (
				                        temp.OnFind ("terrainDate", infor.OnGetTerrain ().ToString (), "terrainName"),
				                        new Vector3 ((terrain.getN () + 1) * TerrainParameter.mapSize, 0, 0),
				                        temp.OnFind ("terrainDate", infor.OnGetTerrain ().ToString (), "memoryID")
			                        );

<<<<<<< HEAD
			if (newTerrain != null)
				OnEnqueueOldTerrain (newTerrain);
=======
			if (newTerrain != null) { 
				OnEnqueueOldTerrain (newTerrain);
			}
>>>>>>> origin/dev

			List<Coin> coin = infor.OnGetCoin ();
			lastPosition = new Vector3 (coin[coin.Count-1].OnGetStart () + ((terrain.getN () + 1) * TerrainParameter.mapSize), coin[coin.Count-1].OnGetHigh (), 0);
			foreach (Coin item in infor.OnGetCoin()) {
				GameObject CoinTemp = MemoryController.instance.OnFindGameObjectByName (
					temp.OnFind ("coinDate", item.OnGetKind ().ToString (), "name"), 
					new Vector3 (item.OnGetStart () + ((terrain.getN () + 1) * TerrainParameter.mapSize), item.OnGetHigh (), 0),
					temp.OnFind ("coinDate", item.OnGetKind ().ToString (), "memoryID")
				);
<<<<<<< HEAD
				if (CoinTemp) 
=======
				if (CoinTemp) { 
>>>>>>> origin/dev
					OnEnqueueOldCoin (CoinTemp);
			}

			if (terrain.getN() >= 2)       
			{  
				GameObject deleteTerrain = oldTerrain.Dequeue(); 
				deleteTerrain.SetActive (false);
				MemoryController.instance.OnAddObject(deleteTerrain,ReadTable.getTable.OnFind("memoryObjectParameter","4","priority"));
				if (oldCoin.Count > 0) {
					List<GameObject> deleteCoin = oldCoin.Dequeue ();    
					foreach (GameObject elem in deleteCoin) {
						if (elem)
							elem.SetActive (false);
						MemoryController.instance.OnAddObject (elem, ReadTable.getTable.OnFind ("memoryObjectParameter", "3", "priority"));
					}
				}
			}
			break;
            
		default:
                
			break;
		}
    }

	public void OnEnqueueOldTerrain(GameObject terrain){
<<<<<<< HEAD
		this.oldTerrain.Enqueue(terrain);
=======
		oldTerrain.Enqueue(terrain);
>>>>>>> origin/dev
	}

	public void OnEnqueueOldCoin(GameObject coin){
        coin.SetActiveRecursively(true);
		newCoinList.Add (coin);
		if (coin.transform.position == lastPosition) {
			oldCoin.Enqueue (newCoinList);
			newCoinList = new List<GameObject> ();
		}
	}
		
}