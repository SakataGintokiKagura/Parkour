using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PureMVC.Patterns;
using PureMVC.Interfaces;
/// <summary>
/// 卢平原 地形生成算法
/// </summary>
public class TerrainCreate : SimpleCommand
{

    public new const string NAME = "TerrainCreate";

    public override void Execute(INotification notification)
    {
        //base.Execute(notification);

        TerrainEnum terrain = (TerrainEnum)Random.Range(0, TerrainParameter.terrainEnumNum);
        Dictionary<float, GoldEnum> coin = new Dictionary<float, GoldEnum>();

        Dictionary<float, float> tempCoin = OneTerrain.Pit;
        switch (terrain)
        {
            case TerrainEnum.One:
                tempCoin = OneTerrain.Pit;
                break;
            case TerrainEnum.Two:
                tempCoin = TwoTerrain.Pit;
                break;
            case TerrainEnum.Three:
                tempCoin = ThreeTerrain.Pit;
                break;
            default:
                break;
        }

        foreach (KeyValuePair<float, float> item in tempCoin)
        {
            for (float i = item.Key; i < item.Value - TerrainParameter.coinBuffer; i = i + TerrainParameter.coinZone)
            {
                if (Random.Range(0, TerrainParameter.coinCreateDenominator) <= TerrainParameter.coinCreateNumerator)
                {
                    coin.Add(i, (GoldEnum)Random.Range(0, TerrainParameter.coinEnumNum));
                }
            }
        }

        TerrainProxy proxy = (TerrainProxy)Facade.RetrieveProxy(TerrainProxy.NAME);
        proxy.OnCreateTerrain(terrain, coin);
    }
}
