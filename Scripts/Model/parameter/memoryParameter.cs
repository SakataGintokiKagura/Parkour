using UnityEngine;
using System.Collections;

public class MemoryParameter {
	
	private static bool initial = true;

	private static int thresholdRecord ;
	private static int objectTypeRecord;

	private MemoryParameter()
	{
		
		ReadTable temp = ReadTable.getTable;

		thresholdRecord = int.Parse(temp.OnFind("memoryParameter", "1", "value"));
		objectTypeRecord = int.Parse(temp.OnFind("memoryParameter","2","value"));

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

}
