using UnityEngine;
using System.Collections;

public interface ISkill {
	float damage { get; }
    int MP { get; }
    float time { get; }
    void OnStartSkillAnimation(Transform transform, Animator anim,PlayerState state);
    void OnMiddleSkillAnimation(Transform transform, Animator anim, PlayerState state);
    int OnMiddleSkillAnimation();
    void OnEndSkillAnimation(Transform transform, Animator anim, PlayerState state);
}
