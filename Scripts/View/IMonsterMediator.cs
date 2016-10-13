using UnityEngine;
using System.Collections;

public interface IMonsterMediator {

    void OnCreateMonster();
    void OnDestroyMonster(GameObject monster);
    void OnInjured(GameObject monster, ISkill skill);
}
