using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class ThreeTerrain : ITerrain {
	public const TerrainEnum terrain = TerrainEnum.One;
	public Dictionary<float, float>[] pit = new Dictionary<float, float>[5];
	public ThreeTerrain()
	{
		pit[0].Add(24f, 30f);
		pit[1].Add(42f, 46f);
		pit[2].Add(50f, 54f);
		pit[3].Add(58f, 64f);
		pit[4].Add(96f, 100f);
	}

	public Dictionary<float, float>[] OnGetPit()
	{
		return pit;
	}
}

