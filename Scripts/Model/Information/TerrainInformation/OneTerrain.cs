using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class OneTerrain : ITerrain
{
    public const TerrainEnum terrain = TerrainEnum.One;
    public Dictionary<float, float>[] pit = new Dictionary<float, float>[4];
    public OneTerrain()
    {
        pit[0].Add(24f, 30f);
		pit[1].Add(54f, 60f);
		pit[2].Add(84f, 88f);
		pit[3].Add(96f, 100f);
    }

    public Dictionary<float, float>[] OnGetPit()
    {
        return pit;
    }
}
