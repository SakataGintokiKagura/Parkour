using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
public class ApplicationFacade :Facade {

	public ApplicationFacade(Player player,UI ui,Terrain terrain,Monster monster)
    {
        RegisterMediator(PlayerMediator.OnGetPlayerMediator(player, ui));
        RegisterMediator(TerrainMediator.OnGetTerrainMediator(terrain));
        RegisterMediator(MonsterMediator.OnGetMonsterMediator(monster,ui));

        RegisterProxy(new PlayerProxy());
        RegisterProxy(new TerrainProxy());
        RegisterProxy(new MonsterProxy());

        RegisterCommand(EventsEnum.playerUseSkill, typeof(PlayerUseSkill));
        RegisterCommand(EventsEnum.playerInjured, typeof(playerInjured));
        RegisterCommand(EventsEnum.monsterCreateMonster, typeof(MonsterCreate));
        RegisterCommand(EventsEnum.monsterCreateGameObject, typeof(MonsterCreateGameObject));
        RegisterCommand(EventsEnum.monsterDestroy, typeof(MonsterDestroy));
        RegisterCommand(EventsEnum.monsterInjured, typeof(MonsterInjured));
        RegisterCommand(EventsEnum.terrainCreate, typeof(TerrainCreate));
    }
}
