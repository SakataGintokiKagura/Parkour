using UnityEngine;
using System.Collections;

/// <summary>
/// 朱科锦
/// 怪物属性，以常量的形式写在数据类里
/// 怪物属性份三档，low，mid，high
/// </summary>
public class MonsterParameber  {
    public const float damageShowTime = 0.5f;
    public const int lowHP = 1;
	public const int lowdamage = 10;
	public const int midHP = 2;
	public const int middamage = 20;
	public const int highHP = 3;
	public const int highdamage = 30;
    public const int GeneratingprobabilityMax = 2;
    public const int GeneratingprobabilityMin = 1;
    public const int SpeciesNumber = 4;
}
