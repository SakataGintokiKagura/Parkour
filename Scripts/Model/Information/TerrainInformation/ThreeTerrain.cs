using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class ThreeTerrain : ITerrain
{
    public const TerrainEnum terrain = TerrainEnum.Three;
    public static Dictionary<float, float> pit = new Dictionary<float, float>();
    public static Dictionary<float, float> Pit
    {
        get
        {
            if (pit.Count == 0)
            {
                pit.Add(0f, 24f);
                pit.Add(30f, 42f);
                pit.Add(46f, 50f);
                pit.Add(54f, 58f);
                pit.Add(64f, 96f);
            }
            return pit;
        }
    }

    public ThreeTerrain()
    {

    }

    public TerrainEnum getTerrain()
    {
        return terrain;
    }
}

