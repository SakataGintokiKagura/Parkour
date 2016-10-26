using UnityEngine;
using System.Collections;


public class MonsterParameber  {

	private static bool initial=true;

	private static float damageShowTimeRecord;
	private static int lowHPRecord;
	private static int lowdamageRecord;
	private static int midHPRecord;
	private static int middamageRecord;
	private static int highHPRecord;
	private static int highdamageRecord;
	private static int GeneratingprobabilityMaxRecord;
	private static int GeneratingprobabilityMinRecord;
	private static int SpeciesNumberRecord;

	private MonsterParameber(){
		ReadTable temp = ReadTable.getTable;
		damageShowTimeRecord=float.Parse(temp.OnFind("monsterParameber","1","Value"));
		lowHPRecord=int.Parse(temp.OnFind("monsterParameber","2","Value"));
		lowdamageRecord=int.Parse(temp.OnFind("monsterParameber","3","Value"));
		midHPRecord=int.Parse(temp.OnFind("monsterParameber","4","Value"));
		middamageRecord=int.Parse(temp.OnFind("monsterParameber","5","Value"));
		highHPRecord=int.Parse(temp.OnFind("monsterParameber","6","Value"));
		highdamageRecord=int.Parse(temp.OnFind("monsterParameber","7","Value"));
		GeneratingprobabilityMaxRecord=int.Parse(temp.OnFind("monsterParameber","8","Value"));
		GeneratingprobabilityMinRecord=int.Parse(temp.OnFind("monsterParameber","9","Value"));
		SpeciesNumberRecord=int.Parse(temp.OnFind("monsterParameber","10","Value"));
		initial = false;
	}

	public static float damageShowTime {
		get{
			if (initial)
				new MonsterParameber ();
			return damageShowTimeRecord;
		}
	}

	public static int lowHP {
		get{
			if (initial)
				new MonsterParameber ();
			return lowHPRecord;
		}
	}

	public static int lowdamage {
		get{
			if (initial)
				new MonsterParameber ();
			return lowdamageRecord;
		}
	}

	public static int midHP {
		get{
			if (initial)
				new MonsterParameber ();
			return midHPRecord;
		}
	}

	public static int middamage{
		get{
			if (initial)
				new MonsterParameber ();
			return middamageRecord;
		}
	}

	public static int highHP{
		get{
			if (initial)
				new MonsterParameber ();
			return highHPRecord;
		}
	}

	public static int highdamage {
		get{
			if (initial)
				new MonsterParameber ();
			return highdamageRecord;
		}
	}

	public static int GeneratingprobabilityMax {
		get{
			if (initial)
				new MonsterParameber ();
			return GeneratingprobabilityMaxRecord;
		}
	}

	public static int GeneratingprobabilityMin{
		get{
			if (initial)
				new MonsterParameber ();
			return GeneratingprobabilityMinRecord;
		}
	}

	public static int SpeciesNumber{
		get{
			if (initial)
				new MonsterParameber ();
			return SpeciesNumberRecord;
		}
	}
}
