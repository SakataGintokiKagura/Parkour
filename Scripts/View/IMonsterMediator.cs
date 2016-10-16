using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IMonsterMediator {
    Dictionary<IBlology, GameObject> monster { get; }
    void OnCreateMonster();
    void OnDestroyMonster(GameObject monster);
    void OnInjured(GameObject monster, ISkill skill);

}
