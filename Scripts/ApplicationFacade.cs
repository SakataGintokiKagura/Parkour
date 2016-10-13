using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
public class ApplicationFacade :Facade {

	public ApplicationFacade(Player player,UI ui,Terrain terrain,Monster monster)
    {
        RegisterMediator(new PlayerMediator(player, ui));
        RegisterMediator(new TerrainMediator(terrain));
        RegisterMediator(new MonsterMediator(monster,ui));

        RegisterProxy(new PlayerProxy());
        RegisterProxy(new TerrainProxy());
        RegisterProxy(new MonsterProxy());

        RegisterCommand(EventsEnum.playerUseSkill, typeof(PlayerUseSkill));
        RegisterCommand(EventsEnum.playerInjured, typeof(playerInjured));
        RegisterCommand(EventsEnum.monsterCreatMonster, typeof(MonsterCreate));
        RegisterCommand(EventsEnum.monsterDestroy, typeof(MonsterDestroy));
        RegisterCommand(EventsEnum.monsterInjured, typeof(MonsterInjured));
        RegisterCommand(EventsEnum.terrainCreate, typeof(TerrainCreate));
    }
}
