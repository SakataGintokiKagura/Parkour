using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class OneTerrain : ITerrain
{
    public const TerrainEnum terrain = TerrainEnum.One;
    public Dictionary<float, float>[] pit = new Dictionary<float, float>[1];
    public OneTerrain()
    {
        pit[0].Add(24f, 7f);
    }

    public Dictionary<float, float>[] OnGetPit()
    {
        return pit;
    }
}
