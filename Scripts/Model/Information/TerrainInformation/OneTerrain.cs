
using System.Collections.Generic;
/// <summary>
/// 朱科锦
/// 构造地形一并将坑的坐标记录下来
/// </summary>
public class OneTerrain : ITerrain
{
    public const TerrainEnum terrain = TerrainEnum.One;
    public static Dictionary<float, float> pit = new Dictionary<float, float>();
    public static Dictionary<float, float> Pit
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
