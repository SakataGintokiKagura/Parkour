
using System.Collections.Generic;

public class OneTerrain : ITerrain
{
	//地形一
    public const TerrainEnum terrain = TerrainEnum.One;
    public static Dictionary<float, float> pit = new Dictionary<float, float>();
    public static Dictionary<float, float> Pit//记录坑的位置
    {
        get
        {
            if (pit.Count == 0)
            {
                pit.Add(0f, 24f);
                pit.Add(30f, 54f);
                pit.Add(60f, 84f);
                pit.Add(88f, 96f);
            }
            return pit;
        }
    }
    public OneTerrain()
    {
    }

    public TerrainEnum getTerrain()
    {
        return terrain;
    }
}
