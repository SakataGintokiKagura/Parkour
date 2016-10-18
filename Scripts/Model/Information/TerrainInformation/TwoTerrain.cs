using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class TwoTerrain : ITerrain {
	public const TerrainEnum terrain = TerrainEnum.One;
	public Dictionary<float, float>[] pit = new Dictionary<float, float>[3];
	public TwoTerrain()
	{
		pit[0].Add(54f, 60f);
		pit[1].Add(84f, 88f);
		pit[2].Add(96f, 100f);
	}

	public Dictionary<float, float>[] OnGetPit()
	{
		return pit;
	}
}
