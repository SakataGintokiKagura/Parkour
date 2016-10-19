using UnityEngine;
using System.Collections;

public interface ISkill {
	float damage { get; }
    int MP { get; }
    float time { get; }
    bool OnSkillAnimation(ref Vector3 velocity, Animator anim,PlayerState state);
}
