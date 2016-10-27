using UnityEngine;
using System.Collections;

public class EventsEnum {
    public const string playerUseSkill = "PlayerUseSkill";
    public const string playerUseSkillSuccess = "PlayerUseSkillSuccess";
    public const string playerInjured = "PlayerInjured";
    public const string playerHPChange = "PlayerHPChange";
    public const string playerDie = "PlayerDie";
    public const string playerGetScoure = "PlayerGetScoure";
    public const string playerGetScoureSuccess = "PlayerGetScoureSuccess";
    public const string playerDropOutPit = "PlayerDropOutPit";
    public const string playerDropOutNoDie = "PlayerDropOutNoDie";
    //public const string playerPickUpItem = "PlayerPickUpItem";
    public const string monsterCreateMonster = "MonsterCreateMonster";
    public const string monsterCreateMonsterSuccess = "MonsterCreateMonsterSuccess";
    public const string monsterCreateGameObject = "MonsterCreateGameObject";
    public const string monsterInjured = "MonsterInjured";
    public const string monsterHPChange = "MonsterHPChange";
    public const string monsterDie = "MonsterDie";
    public const string monsterDestroy = "MonsterDestroy";

    public const string terrainCreate = "TerrainCreate";
    public const string terrainCreateSuccess = "TerrainCreateSuccess";
}
