using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using System.Collections.Generic;

public class TerrainMediator : Mediator, ITerrainMediator
{

    public new const string NAME = "TerrainMediator";
	public Terrain terrain;
    private static TerrainMediator terrainMediator;
	private Vector3 lastPosition;
	private List<GameObject> newCoinList = new List<GameObject> ();

    private Queue<GameObject> oldTerrain = new Queue<GameObject>();
    private Queue<List<GameObject>> oldCoin = new Queue<List<GameObject>>();

    private TerrainMediator() : base(NAME)
    {
    }
    public static TerrainMediator OnGetTerrainMediator()
    {
        if (terrainMediator == null)
        {
			terrainMediator = new TerrainMediator ();
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

        switch (notification.Name)
        {
            case EventsEnum.terrainCreateSuccess:

                TerrainCreateInfor infor = notification.Body as TerrainCreateInfor;

                ReadTable temp = ReadTable.getTable;

                GameObject newTerrain = MemoryController.instance.OnFindGameObjectByName(
                    temp.OnFind("terrainDate", infor.OnGetName(), "terrainName"),
                    new Vector3((terrain.getN() + 1)*TerrainParameter.mapSize, 0, 0),
				    MemoryParameter.TerrainPriority,
				    temp.OnFind("terrainDate", infor.OnGetName(), "path"),
				    temp.OnFind("terrainDate", infor.OnGetName(), "load"),
				    infor.OnGetName().ToString()
                );


                if (newTerrain != null)
                {
                    OnEnqueueOldTerrain(newTerrain);
                }


                List<Coin> coin = infor.OnGetCoin();
                lastPosition =
                    new Vector3(coin[coin.Count - 1].OnGetStart() + ((terrain.getN() + 1)*TerrainParameter.mapSize),
                        coin[coin.Count - 1].OnGetHigh(), 0);

                foreach (Coin item in infor.OnGetCoin())
                {
                    GameObject CoinTemp = MemoryController.instance.OnFindGameObjectByName(
                        temp.OnFind("coinDate", item.OnGetName(), "name"),
                        new Vector3(item.OnGetStart() + ((terrain.getN() + 1)*TerrainParameter.mapSize),
                            item.OnGetHigh(), 0),
					    MemoryParameter.CoinsPriority,
                        temp.OnFind("coinDate", item.OnGetName(), "path"),
					    temp.OnFind("coinDate", item.OnGetName(), "load"),
					    item.OnGetName().ToString()
                    );

//                    if (CoinTemp)
//                    {
//                        OnEnqueueOldCoin(CoinTemp);
//                    }

				CoinTemp.SetActiveRecursively(true);
				newCoinList.Add (CoinTemp);
				if (CoinTemp.transform.position == lastPosition) {
					oldCoin.Enqueue (newCoinList);
					newCoinList = new List<GameObject> ();
				}

                }
                if (terrain.getN() >= 2)
                    {
                        GameObject deleteTerrain = oldTerrain.Dequeue();
                        MemoryController.instance.OnListAddObject(deleteTerrain,
					MemoryParameter.TerrainPriority);
                        if (oldCoin.Count > 0)
                        {
                            List<GameObject> deleteCoin = oldCoin.Dequeue();
                            foreach (GameObject elem in deleteCoin)
                            {
                                if (elem)
                                MemoryController.instance.OnListAddObject(elem,
								MemoryParameter.CoinsPriority);
                            }
                        }
                    }

                    break;

            default:

                break;
        }   
    }

    public void OnEnqueueOldTerrain(GameObject terrain){

		oldTerrain.Enqueue(terrain);

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