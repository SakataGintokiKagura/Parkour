using UnityEngine;
using System.Collections;

public interface IPlayerMediator {

    void OnUseSkill(ISkill skill);
    void OnInjured(GameObject monster);
    void OnJump();
}
