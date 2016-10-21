using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
//地形二
public class TwoTerrain : ITerrain
{
    public const TerrainEnum terrain = TerrainEnum.Two;
    public static Dictionary<float, float> pit = new Dictionary<float, float>();
    public static Dictionary<float, float> Pit//记录坑的坐标
    {
        get
        {
            if (pit.Count == 0)
            {
                pit.Add(0f, 54f);
                pit.Add(60f, 84f);
                pit.Add(88f, 96f);
            }
            return pit;
        }
    }
    public TwoTerrain()
    {
    }

    public TerrainEnum getTerrain()
    {
        return terrain;
    }
}
