using UnityEngine;
using System.Collections;

public class EventsEnum {
    /// <summary>
    /// 人物使用技能
    /// </summary>
    public const string playerUseSkill = "PlayerUseSkill";
    /// <summary>
    /// 人物使用技能成功
    /// </summary>
    public const string playerUseSkillSuccess = "PlayerUseSkillSuccess";
    /// <summary>
    /// 人物受伤
    /// </summary>
    public const string playerInjured = "PlayerInjured";
    /// <summary>
    /// 人物血量发生变化
    /// </summary>
    public const string playerHPChange = "PlayerHPChange";
    /// <summary>
    /// 人物MP发生变化
    /// </summary>
    public const string playerMPChange = "PlayerMPChange";
    /// <summary>
    /// 人物死亡
    /// </summary>
    public const string playerDie = "PlayerDie";
    /// <summary>
    /// 人物得分
    /// </summary>
    public const string playerGetScoure = "PlayerGetScoure";
    /// <summary>
    /// 人物得分成功
    /// </summary>
    public const string playerGetScoureSuccess = "PlayerGetScoureSuccess";
    /// <summary>
    /// 人物掉坑
    /// </summary>
    public const string playerDropOutPit = "PlayerDropOutPit";
    /// <summary>
    /// 人物掉坑没有死亡
    /// </summary>
    public const string playerDropOutNoDie = "PlayerDropOutNoDie";
    /// <summary>
    /// 人物信息初始化
    /// </summary>
    public const string playerInitizal = "PlayerInitizal";
    /// <summary>
    /// 人物飞行
    /// </summary>
    public const string playerFly = "PlayerFly";
    /// <summary>
    /// 产生怪物
    /// </summary>
    public const string monsterCreateMonster = "MonsterCreateMonster";
    /// <summary>
    /// 怪物产生成功
    /// </summary>
    public const string monsterCreateMonsterSuccess = "MonsterCreateMonsterSuccess";
    /// <summary>
    /// 怪物产生的实例
    /// </summary>
    public const string monsterCreateGameObject = "MonsterCreateGameObject";
    /// <summary>
    /// 怪物受伤
    /// </summary>
    public const string monsterInjured = "MonsterInjured";
    /// <summary>
    /// 怪物血量发生变化
    /// </summary>
    public const string monsterHPChange = "MonsterHPChange";
    /// <summary>
    /// 怪物死亡
    /// </summary>
    public const string monsterDie = "MonsterDie";
    /// <summary>
    /// 怪物消失于屏幕
    /// </summary>
    public const string monsterDestroy = "MonsterDestroy";
    /// <summary>
    /// 产生Boss
    /// </summary>
    public const string monsterCreateBoss = "MonsterCreateBoss";

    /// <summary>
    /// 产生地形
    /// </summary>
    public const string terrainCreate = "TerrainCreate";
    /// <summary>
    /// 地形产生成功
    /// </summary>
    public const string terrainCreateSuccess = "TerrainCreateSuccess";
    //public const string prop = "Prop";
    /// <summary>
    /// 产生物品
    /// </summary>
    public const string propCreate = "PropCreate";
    /// <summary>
    /// 物品被拾取
    /// </summary>
    public const string propPickUpProp = "PropPickUpProp";

}
