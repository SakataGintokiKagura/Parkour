using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using System.Collections.Generic;
/// <summary>
/// 卢平原 创造地形和金币
/// </summary>
public class TerrainMediator : Mediator, ITerrainMediator
{

    public new const string NAME = "TerrainMediator";
    private Terrain terrain;
    private static TerrainMediator terrainMediator;

    private Queue<GameObject> oldTerraian = new Queue<GameObject>();
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
        //        base.HandleNotification(notification);
        //
        switch (notification.Name)
        {
            case EventsEnum.terrainCreateSuccess:

                TerrainCreateInfor infor = notification.Body as TerrainCreateInfor;
                GameObject newTerrain;
                switch (infor.terrain.getTerrain())
                {
                    case TerrainEnum.One:
                        newTerrain = GameObject.Instantiate(terrain.getTerrain(0), new Vector3((terrain.getN() + 1) * TerrainParameter.mapSize, 0, 0), Quaternion.identity) as GameObject;
                        oldTerraian.Enqueue(newTerrain);
                        break;
                    case TerrainEnum.Two:
                        newTerrain = GameObject.Instantiate(terrain.getTerrain(1), new Vector3((terrain.getN() + 1) * TerrainParameter.mapSize, 0, 0), Quaternion.identity) as GameObject;
                        oldTerraian.Enqueue(newTerrain);
                        break;
                    case TerrainEnum.Three:
                        newTerrain = GameObject.Instantiate(terrain.getTerrain(2), new Vector3((terrain.getN() + 1) * TerrainParameter.mapSize, 0, 0), Quaternion.identity) as GameObject;
                        oldTerraian.Enqueue(newTerrain);
                        break;
                }
                //
                GameObject newCoin;
                List<GameObject> newCoinList = new List<GameObject>();

                foreach (KeyValuePair<float, GoldEnum> item in infor.OnGetCoin())
                {
                    switch (item.Value)
                    {
                        case GoldEnum.Arc:
                            newCoin = GameObject.Instantiate(terrain.getCoin(0), new Vector3(item.Key + ((terrain.getN() + 1) * TerrainParameter.mapSize), 0, 0), Quaternion.identity) as GameObject;
                            newCoinList.Add(newCoin);
                            break;
                        case GoldEnum.Line:
                            newCoin = GameObject.Instantiate(terrain.getCoin(1), new Vector3(item.Key + ((terrain.getN() + 1) * TerrainParameter.mapSize), 0, 0), Quaternion.identity) as GameObject;
                            newCoinList.Add(newCoin);
                            break;
                        case GoldEnum.LinkArc:
                            newCoin = GameObject.Instantiate(terrain.getCoin(2), new Vector3(item.Key + ((terrain.getN() + 1) * TerrainParameter.mapSize), 0, 0), Quaternion.identity) as GameObject;
                            newCoinList.Add(newCoin);
                            break;
                        case GoldEnum.SecondArc:
                            newCoin = GameObject.Instantiate(terrain.getCoin(3), new Vector3(item.Key + ((terrain.getN() + 1) * TerrainParameter.mapSize), 0, 0), Quaternion.identity) as GameObject;
                            newCoinList.Add(newCoin);
                            break;
                        case GoldEnum.Star:
                            newCoin = GameObject.Instantiate(terrain.getCoin(4), new Vector3(item.Key + ((terrain.getN() + 1) * TerrainParameter.mapSize), 0, 0), Quaternion.identity) as GameObject;
                            newCoinList.Add(newCoin);
                            break;
                    }
                }

                oldCoin.Enqueue(newCoinList);

                if (terrain.getN() >= 2)
                {

                    GameObject deleterTerrain = oldTerraian.Dequeue();
                    GameObject.Destroy(deleterTerrain);

                    List<GameObject> deleterCoin = oldCoin.Dequeue();
                    foreach (GameObject elem in deleterCoin)
                        GameObject.Destroy(elem);
                }
                //
                break;
            default:
                break;
        }

    }
}