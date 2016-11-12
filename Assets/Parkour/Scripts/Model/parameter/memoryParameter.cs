using UnityEngine;
using System.Collections;

public class MemoryParameter {
	
	private static bool initial = true;

	private static int thresholdRecord ;
	private static int objectTypeRecord;
	private static int PropPriorityRecord;
	private static int MonsterPriorityRecord;
	private static int CoinsPriorityRecord;
	private static int TerrainPriorityRecord;
	private static int FlyItemPriorityRecord;
	private static int PetPriorityRecord;

	private MemoryParameter()
	{
		
		ReadTable temp = ReadTable.getTable;

		thresholdRecord = int.Parse(temp.OnFind("memoryParameter", "1", "value"));
		objectTypeRecord = int.Parse(temp.OnFind("memoryParameter","2","value"));
		PropPriorityRecord = int.Parse(temp.OnFind("memoryParameter","3","value"));
		MonsterPriorityRecord = int.Parse(temp.OnFind("memoryParameter","4","value"));
		CoinsPriorityRecord = int.Parse(temp.OnFind("memoryParameter","5","value"));
		TerrainPriorityRecord = int.Parse(temp.OnFind("memoryParameter","6","value"));
		FlyItemPriorityRecord = int.Parse(temp.OnFind("memoryParameter","7","value"));
		PetPriorityRecord = int.Parse(temp.OnFind("memoryParameter","8","value"));

		initial = false;
	}

	public static int threshold
	{
		get
		{
			if (initial)
			{
				new MemoryParameter();
			}
			return thresholdRecord;
		}
	}

	public static int objectType
	{
		get
		{
			if (initial)
			{
				new MemoryParameter();
			}
			return objectTypeRecord;
		}
	}

	public static int PropPriority
	{
		get
		{
			if (initial)
			{
				new MemoryParameter();
			}
			return PropPriorityRecord;
		}
	}

	public static int MonsterPriority
	{
		get
		{
			if (initial)
			{
				new MemoryParameter();
			}
			return MonsterPriorityRecord;
		}
	}

	public static int CoinsPriority
	{
		get
		{
			if (initial)
			{
				new MemoryParameter();
			}
			return CoinsPriorityRecord;
		}
	}

	public static int TerrainPriority
	{
		get
		{
			if (initial)
			{
				new MemoryParameter();
			}
			return TerrainPriorityRecord;
		}
	}

	public static int FlyItemPriority
	{
		get
		{
			if (initial)
			{
				new MemoryParameter();
			}
			return FlyItemPriorityRecord;
		}
	}

	public static int PetPriority
	{
		get
		{
			if (initial)
			{
				new MemoryParameter();
			}
			return PetPriorityRecord;
		}
	}
}
