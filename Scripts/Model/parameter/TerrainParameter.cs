using UnityEngine;
using System.Collections;

public class TerrainParameter{
    private static bool initial = true;

    private static float mapSizeRecord ;
    private static float mapDistanceRecord;
    private static int terrainEnumNumRecord;
    private static int coinEnumNumRecord;
    private static int coinCreateDenominatorRecord;
    private static int coinCreateNumeratorRecord;
    private static float coinZoneRecord;
    private static float coinBufferRecord;

    private TerrainParameter()
    {
        ReadTable temp = ReadTable.getTable;
        mapSizeRecord = float.Parse(temp.OnFind("terrainParamber", "1", "dateValue"));
        mapDistanceRecord = float.Parse(temp.OnFind("terrainParamber","2","dateValue"));
        terrainEnumNumRecord = int.Parse(temp.OnFind("terrainParamber", "3", "dateValue"));
        coinEnumNumRecord = int.Parse(temp.OnFind("terrainParamber", "4", "dateValue"));
        coinCreateDenominatorRecord = int.Parse(temp.OnFind("terrainParamber", "5", "dateValue"));
        coinCreateNumeratorRecord = int.Parse(temp.OnFind("terrainParamber", "6", "dateValue"));
        coinZoneRecord = float.Parse(temp.OnFind("terrainParamber", "7", "dateValue"));
        coinBufferRecord = float.Parse(temp.OnFind("terrainParamber", "8", "dateValue"));

		initial = false;
    }

    public static float mapSize
    {
        get
        {
            if (initial)
            {
                new TerrainParameter();
            }
            return mapSizeRecord;
        }
    }

    public static float mapDistance
    {
        get
        {
            if (initial)
            {
                new TerrainParameter();
            }
            return mapDistanceRecord;
        }
    }

    public static int terrainEnumNum
    {
        get
        {
            if (initial)
            {
                new TerrainParameter();
            }
            return terrainEnumNumRecord;
        }
    }

    public static int coinEnumNum
    {
        get
        {
            if (initial)
            {
                new TerrainParameter();
            }
            return coinEnumNumRecord;
        }
    }

    public static int coinCreateDenominator
    {
        get
        {
            if (initial)
            {
                new TerrainParameter();
            }
            return coinCreateDenominatorRecord;
        }
    }

    public static int coinCreateNumerator
    {
        get
        {
            if (initial)
            {
                new TerrainParameter();
            }
			return coinCreateNumeratorRecord;
        }
    }

    public static float coinZone
    {
        get
        {
            if (initial)
            {
                new TerrainParameter();
            }
            return coinZoneRecord;
        }
    }

    public static float coinBuffer
    {
        get
        {
            if (initial)
            {
                new TerrainParameter();
            }
            return coinBufferRecord;
        }
    }

}
